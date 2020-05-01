using CSCore;
using CSCore.Codecs;
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
        Playlist playlist;
        public Form1()
        {
            InitializeComponent();
        }

        public void OpenMusic(string op)
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
            for (int count = 0; count <= listView1.SelectedItems.Count; count++)
                listView1.SelectedItems[0].Remove();

            listView1.SelectedItems[0].Remove();
        }

        private void btn_ramd_Click(object sender, EventArgs e)
        {

        }
    }
}
