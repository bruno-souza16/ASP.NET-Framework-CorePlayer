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

        void Play()
        {
            player_on = true;
            soundSource = SoundSource(listView1.Items[now].SubItems[2].Text);
            soundOut = SoundOut();
            soundOut.Initialize(soundSource);
            soundOut.Play();
            soundOut.Stopped += VerifyState;

            listView1.Items[now].BackColor = Color.SkyBlue;
            listView1.Items[now].ForeColor = Color.Black;
        }

        void VerifyState(object sender, EventArgs e)
        {
            if(player_on == true)
            {
                if(now >= 0)
                {
                    listView1.Items[now].BackColor = Color.Black;
                    listView1.Items[now].ForeColor = Color.SkyBlue;
                }               

                if (now >= listView1.Items.Count)
                    now = 0;
                else
                    now = now+1;                
               
                soundOut.Stop();
                soundOut.Dispose();
                soundSource.Dispose();
                soundSource.Dispose();
                
                Play();
            }            
        }

        void Pause()
        {
            if (soundOut.PlaybackState == PlaybackState.Playing)
                soundOut.Pause();
            else
                soundOut.Resume();
        }

        void Stop()
        {
            player_on = false;
            soundOut.Stop();
            soundOut.Dispose();
            soundSource.Dispose();
        }

        void Next()
        {
            soundOut.Stop();
        }

        void Previous()
        {
            listView1.Items[now].BackColor = Color.Black;
            listView1.Items[now].ForeColor = Color.SkyBlue;
            now = now - 2;
            soundOut.Stop();
        }

       
    }
}
