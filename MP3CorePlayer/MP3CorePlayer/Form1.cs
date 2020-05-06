using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3CorePlayer
{
    public partial class Form1 : Form
    {
        ISoundOut soundOut;
        IWaveSource soundSource;
        int now = 0;
        bool player_on = false;
        
        public Form1()
        {
            InitializeComponent();
            btn_pause.Visible = false;
        }



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
            float vol = tbar_volume.Value * 0.1f;
            soundOut.Volume = vol;
            Console.WriteLine(vol);
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
                soundSource = SoundSource(listView1.Items[now].SubItems[2].Text);
                MakeLabels(listView1.Items[now].SubItems[2].Text);
                soundOut = SoundOut();
                soundOut.Initialize(soundSource);
                soundOut.Play();
                Play_Aux();
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
            label_title.Text = id3tag.QuickInfo.Title;
            label_artist.Text = id3tag.QuickInfo.LeadPerformers;
            label_album.Text = id3tag.QuickInfo.Album;
            label_title.Text = id3tag.QuickInfo.Title;
            label_year.Text = id3tag.QuickInfo.Year.ToString();
            label_genre.Text = id3tag.QuickInfo.Genre.ToString();
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
                pos = pos - 10;
                label_title.Location = new Point(pos);
            }else if(label_title.Location == new Point(-350))
            {
                int pos = 350;
                label_title.Location = new Point(pos);
            }
        }

        private void trackbar_progress_ValueChanged(object sender, EventArgs e)
        {
            soundSource.SetPosition(TimeSpan.FromSeconds(trackbar_progress.Value));
        }
    }
}
