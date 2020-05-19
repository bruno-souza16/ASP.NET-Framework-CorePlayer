#region frameworks
using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;
using CSCore.Streams.Effects;
using gTrackBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace MP3CorePlayer
{
    public partial class Form1 : Form
    {
        #region Global Variables
        const double MaxDB = 30;
        const int defVol = 5;
        const int defEq = 5;
        ISoundOut soundOut;
        IWaveSource soundSource;
        Equalizer equalizer;
        int now = 0;
        bool player_on = false;
        #endregion

        #region Main Functions
        public Form1()
        {
            InitializeComponent();
            InitialConfigs();
        }
        #endregion

        #region WindowForms Components
        private void btn_Play_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            Pause();
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            Previous();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            OpenMusic("add");
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenMusic("open");
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DeleteMusic();
        }

        private void btn_ramd_Click(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Stop();
            if (listView1.SelectedItems.Count > 0)
            {
                now = listView1.Items.IndexOf(listView1.SelectedItems[0]);
            }
            Play();
        }

        private void tbar_volume_ValueChanged(object sender, EventArgs e)
        {
            if(soundOut != null)
            {
                float vol = tbar_volume.Value * 0.1f;
                soundOut.Volume = vol;
            }            
        }

        private void trackbar_progress_ValueChanged(object sender, EventArgs e)
        {
            soundSource.SetPosition(TimeSpan.FromSeconds(trackbar_progress.Value));
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            player_on = false;
            if (soundOut != null)
            {
                soundOut.Stop();
                soundOut.Dispose();
            }
            Environment.Exit(0);
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Preset_Click(object sender, EventArgs e)
        {
            LoadPreset();
        }

        private void btn_SavePreset_Click(object sender, EventArgs e)
        {
            SavePreset();
        }
        #endregion

        #region Functions
        void InitialConfigs()
        {
            btn_pause.Visible = false;
            tbar_volume.Value = defVol;
            tb_eq1.Value = defEq;
            tb_eq2.Value = defEq;
            tb_eq3.Value = defEq;
            tb_eq4.Value = defEq;
            tb_eq5.Value = defEq;
            tb_eq6.Value = defEq;
            tb_eq7.Value = defEq;
            tb_eq8.Value = defEq;
            panelControl.Location = new Point(-284, 3);
        }

        ISoundOut SoundOut()
        {
            if (WasapiOut.IsSupportedOnCurrentPlatform)
                return new WasapiOut();
            else
                return new DirectSoundOut();
        }

        IWaveSource SoundSource(string file)
        {
            return CodecFactory.Instance.GetCodec(file);
        }

        void OpenMusic(string op)
        {
            // Instancia a janela de diálogo e define suas configurações
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = CSCore.Codecs.CodecFactory.SupportedFilesFilterEn;
            ofd.InitialDirectory = Environment.SpecialFolder.CommonMusic.ToString();

            // Recebe o resultado da ação na janela
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (op == "open")
                    listView1.Items.Clear();

                foreach (var f in ofd.FileNames)
                {
                    // Extrai o caminho completo do arquivo
                    string flname = Path.GetFullPath(f);

                    // Monta o Título do item
                    int nmblist = listView1.Items.Count + 1;
                    var file = CSCore.Tags.ID3.ID3v2.FromFile(flname.ToString());
                    string itmlist = nmblist + ". " + file.QuickInfo.LeadPerformers + " - " + file.QuickInfo.Title;

                    // Extrai e monta o tempo total de cada item
                    IWaveSource iw = CodecFactory.Instance.GetCodec(flname.ToString());
                    string len = iw.GetLength().Hours.ToString("00") + ":" +
                        iw.GetLength().Minutes.ToString("00") + ":" + iw.GetLength().Seconds.ToString("00");

                    // Adiciona o item a ListView
                    ListViewItem lvi = new ListViewItem(itmlist);
                    lvi.SubItems.Add(len);
                    lvi.SubItems.Add(flname);
                    listView1.Items.Add(lvi);
                }
            }
        }

        void DeleteMusic()
        {
            for (int count = 0; count <= listView1.SelectedItems.Count; count++)
                listView1.SelectedItems[0].Remove();

            listView1.SelectedItems[0].Remove();
        }

        void Play()
        {
            if (soundOut == null || soundOut.PlaybackState == PlaybackState.Stopped)
            {
                MakeLabels(listView1.Items[now].SubItems[2].Text);
                soundSource = SoundSource(listView1.Items[now].SubItems[2].Text);
                var source = soundSource
                    .ChangeSampleRate(32000)
                    .ToSampleSource()
                    .AppendSource(Equalizer.Create10BandEqualizer, out equalizer)
                    .ToWaveSource();
                soundOut = SoundOut();
                soundOut.Initialize(source);
                float vol = tbar_volume.Value * 0.1f;
                soundOut.Volume = vol;
                soundOut.Play();
                Play_Aux();
                listView1.Items[now].BackColor = Color.SkyBlue;
                listView1.Items[now].ForeColor = Color.DarkSlateGray;
                soundOut.Stopped += Play_Aux_2;
            }
            else if (soundOut.PlaybackState == PlaybackState.Paused)
            {
                soundOut.Resume();
                timer_ctime.Enabled = true;
            }
            btn_Play.Visible = false;
            btn_pause.Visible = true;
        }

        void Play_Aux()
        {
            float vol = soundOut.Volume * 10;
            tbar_volume.Value = int.Parse(vol.ToString());

            timer_ctime.Interval = 1000;
            timer_ctime.Start();
            timer_ctime.Enabled = true;

            double t = soundSource.GetLength().TotalSeconds;
            int i = Convert.ToInt32(t);
            trackbar_progress.MaxValue = i;

            label_title.Location = new Point(350);
            btn_Play.Visible = false;
            btn_pause.Visible = true;
        }
        
        void Play_Aux_2(object sender, EventArgs e)
        {
            if(player_on == true)
            {                         

                if (now > listView1.Items.Count)
                    now = 0;
                else
                    now = now+1;

                soundOut.Stop();
                Play();
            }
            player_on = true;    
        }

        void Pause()
        {
            if (soundOut.PlaybackState == PlaybackState.Playing)
            {
                soundOut.Pause();
                timer_ctime.Enabled = false;
                btn_Play.Visible = true;
                btn_pause.Visible = false;
            }           
        }

        void Stop()
        {
            if(soundOut != null)
            {
                if (soundOut.PlaybackState == PlaybackState.Playing)
                {
                    player_on = false;
                    soundOut.Stop();
                    soundOut = null;
                    timer_ctime.Stop();
                    timer_ctime.Enabled = false;
                    listView1.Items[now].BackColor = Color.DarkSlateGray;
                    listView1.Items[now].ForeColor = Color.SkyBlue;
                    trackbar_progress.Value = 0;
                    label_ptime.Text = "00:00:00";
                    btn_Play.Visible = true;
                    btn_pause.Visible = false;
                }
            }                    
        }

        void Next()
        {
            soundOut.Stop();
        }

        void Previous()
        {
            listView1.Items[now].BackColor = Color.Black;
            listView1.Items[now].ForeColor = Color.SkyBlue;
            if (now <= 1)
                now = -1;
            else
                now = now - 2;
            soundOut.Stop();
        }

        void MakeLabels(string flname)
        {
            var id3tag = CSCore.Tags.ID3.ID3v2.FromFile(flname.ToString());
            IWaveSource iw = CodecFactory.Instance.GetCodec(flname.ToString());
            label_title.Text = id3tag.QuickInfo.LeadPerformers.ToString() + " - " + id3tag.QuickInfo.Title;            
            label_album.Text = id3tag.QuickInfo.Album;
            label_year.Text = id3tag.QuickInfo.Year.ToString();
            label_genre.Text = id3tag.QuickInfo.Genre.ToString();
            label_freq.Text = iw.WaveFormat.BytesPerSecond.ToString();
        }

        private void timer_ctime_Tick(object sender, EventArgs e)
        {
            label_ptime.Text = soundOut.WaveSource.GetPosition().Hours.ToString("00") + ":" +
                                soundOut.WaveSource.GetPosition().Minutes.ToString("00") + ":" +
                                 soundOut.WaveSource.GetPosition().Seconds.ToString("00");
            trackbar_progress.Value += 1;
            if(label_title.Location != new Point(-350))
            {
                int pos = label_title.Location.X;
                pos = pos - 20;
                label_title.Location = new Point(pos);
            }else if(label_title.Location == new Point(-350))
            {
                int pos = 350;
                label_title.Location = new Point(pos);
            }
        }

        void LoadPreset()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Playlist Files|*.eq";
            ofd.InitialDirectory = Application.StartupPath + @"\presets\";
            ofd.Multiselect = false;
            DialogResult dr = ofd.ShowDialog();
            if(dr == DialogResult.OK)
            {
                string[] lines = System.IO.File.ReadAllLines(ofd.FileName);
                tb_eq1.Value = int.Parse(lines[0]);
                tb_eq2.Value = int.Parse(lines[1]); 
                tb_eq3.Value = int.Parse(lines[2]);
                tb_eq4.Value = int.Parse(lines[3]);
                tb_eq5.Value = int.Parse(lines[4]);
                tb_eq6.Value = int.Parse(lines[5]);
                tb_eq7.Value = int.Parse(lines[6]);
                tb_eq8.Value = int.Parse(lines[7]);
            }
        }

        void SavePreset()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Playlist Files|*.eq";
            sfd.InitialDirectory = Application.StartupPath + @"\presets\";
            DialogResult dr = sfd.ShowDialog();
            if(dr == DialogResult.OK)
            {
                string[] lines =
                    {
                        tb_eq1.Value.ToString(),
                        tb_eq2.Value.ToString(),
                        tb_eq3.Value.ToString(),
                        tb_eq4.Value.ToString(),
                        tb_eq5.Value.ToString(),
                        tb_eq6.Value.ToString(),
                        tb_eq7.Value.ToString(),
                        tb_eq8.Value.ToString()
                    };
                System.IO.File.WriteAllLines(sfd.FileName, lines);
                MessageBox.Show("Preset Salvo.");
            }
        }
        #endregion
              
        #region Equalizer Bars
        private void tb_eq1_ValueChanged(object sender, EventArgs e)
        {
            var trackbar = sender as gTrackBar.gTrackBar ;
            if (equalizer != null && trackbar != null)
            {
                double perc = (trackbar.Value / (double)trackbar.MaxValue);
                var value = (float)(perc * MaxDB);
                EqualizerFilter filter = equalizer.SampleFilters[1];
                filter.AverageGainDB = value;
            }
        }

        private void tb_eq2_ValueChanged(object sender, EventArgs e)
        {
            var trackbar = sender as gTrackBar.gTrackBar;
            if (equalizer != null && trackbar != null)
            {
                double perc = (trackbar.Value / (double)trackbar.MaxValue);
                var value = (float)(perc * MaxDB);
                EqualizerFilter filter = equalizer.SampleFilters[2];
                filter.AverageGainDB = value;
            }
        }

        private void tb_eq3_ValueChanged(object sender, EventArgs e)
        {
            var trackbar = sender as gTrackBar.gTrackBar;
            if (equalizer != null && trackbar != null)
            {
                double perc = (trackbar.Value / (double)trackbar.MaxValue);
                var value = (float)(perc * MaxDB);
                EqualizerFilter filter = equalizer.SampleFilters[3];
                filter.AverageGainDB = value;
            }
        }

        private void tb_eq4_ValueChanged(object sender, EventArgs e)
        {
            var trackbar = sender as gTrackBar.gTrackBar;
            if (equalizer != null && trackbar != null)
            {
                double perc = (trackbar.Value / (double)trackbar.MaxValue);
                var value = (float)(perc * MaxDB);
                EqualizerFilter filter = equalizer.SampleFilters[4];
                filter.AverageGainDB = value;
            }
        }

        private void tb_eq5_ValueChanged(object sender, EventArgs e)
        {
            var trackbar = sender as gTrackBar.gTrackBar;
            if (equalizer != null && trackbar != null)
            {
                double perc = (trackbar.Value / (double)trackbar.MaxValue);
                var value = (float)(perc * MaxDB);
                EqualizerFilter filter = equalizer.SampleFilters[5];
                filter.AverageGainDB = value;
            }
        }

        private void tb_eq6_ValueChanged(object sender, EventArgs e)
        {
            var trackbar = sender as gTrackBar.gTrackBar;
            if (equalizer != null && trackbar != null)
            {
                double perc = (trackbar.Value / (double)trackbar.MaxValue);
                var value = (float)(perc * MaxDB);
                EqualizerFilter filter = equalizer.SampleFilters[6];
                filter.AverageGainDB = value;
            }
        }

        private void tb_eq7_ValueChanged(object sender, EventArgs e)
        {
            var trackbar = sender as gTrackBar.gTrackBar;
            if (equalizer != null && trackbar != null)
            {
                double perc = (trackbar.Value / (double)trackbar.MaxValue);
                var value = (float)(perc * MaxDB);
                EqualizerFilter filter = equalizer.SampleFilters[7];
                filter.AverageGainDB = value;
            }
        }

        private void tb_eq8_ValueChanged(object sender, EventArgs e)
        {
            var trackbar = sender as gTrackBar.gTrackBar;
            if (equalizer != null && trackbar != null)
            {
                double perc = (trackbar.Value / (double)trackbar.MaxValue);
                var value = (float)(perc * MaxDB);
                EqualizerFilter filter = equalizer.SampleFilters[8];
                filter.AverageGainDB = value;
            }
        }

        private void tb_eq9_ValueChanged(object sender, EventArgs e)
        {
            var trackbar = sender as gTrackBar.gTrackBar;
            if (equalizer != null && trackbar != null)
            {
                double perc = (trackbar.Value / (double)trackbar.MaxValue);
                var value = (float)(perc * MaxDB);
                EqualizerFilter filter = equalizer.SampleFilters[0];
                filter.AverageGainDB = value;
            }
        }
        #endregion

        #region Control windows
        public void ControlWindowsRight()
        {
            if (panelControl.Location.X == 6)
            {
                panelControl.Location = new Point(-284, 3);
            }
            else if (panelControl.Location.X == -284) 
            {
                panelControl.Location = new Point(-574, 3);
            }
        }

        public void ControlWindowsLeft()
        {
            if (panelControl.Location.X == -574)
            {
                panelControl.Location = new Point(-284,3);
            }
            else if (panelControl.Location.X == -284)
            {
                panelControl.Location = new Point(6, 3);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ControlWindowsLeft();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ControlWindowsRight();
        }



        #endregion      
    }
}
