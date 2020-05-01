namespace MP3CorePlayer
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_ramd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label_ttime = new System.Windows.Forms.Label();
            this.label_ptime = new System.Windows.Forms.Label();
            this.label_album = new System.Windows.Forms.Label();
            this.label_artist = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_title = new System.Windows.Forms.Label();
            this.btn_Play = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_previous = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Black;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Time,
            this.Filename});
            this.listView1.Font = new System.Drawing.Font("Malgun Gothic", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.SkyBlue;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(344, 290);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 265;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Filename
            // 
            this.Filename.Text = "Filename";
            this.Filename.Width = 1;
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Malgun Gothic", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.SkyBlue;
            this.btn_add.Location = new System.Drawing.Point(3, 299);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(20, 22);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "+";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_open
            // 
            this.btn_open.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_open.Font = new System.Drawing.Font("Malgun Gothic", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_open.ForeColor = System.Drawing.Color.SkyBlue;
            this.btn_open.Location = new System.Drawing.Point(88, 299);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(20, 22);
            this.btn_open.TabIndex = 3;
            this.btn_open.Text = "^";
            this.btn_open.UseVisualStyleBackColor = false;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Malgun Gothic", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.SkyBlue;
            this.btn_delete.Location = new System.Drawing.Point(29, 299);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(20, 22);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "-";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_ramd
            // 
            this.btn_ramd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_ramd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ramd.Font = new System.Drawing.Font("Malgun Gothic", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ramd.ForeColor = System.Drawing.Color.SkyBlue;
            this.btn_ramd.Location = new System.Drawing.Point(327, 299);
            this.btn_ramd.Name = "btn_ramd";
            this.btn_ramd.Size = new System.Drawing.Size(20, 22);
            this.btn_ramd.TabIndex = 5;
            this.btn_ramd.Text = "R";
            this.btn_ramd.UseVisualStyleBackColor = false;
            this.btn_ramd.Click += new System.EventHandler(this.btn_ramd_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.btn_ramd);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.btn_open);
            this.panel1.Location = new System.Drawing.Point(438, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 326);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label_ttime);
            this.panel2.Controls.Add(this.label_ptime);
            this.panel2.Controls.Add(this.label_album);
            this.panel2.Controls.Add(this.label_artist);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.ForeColor = System.Drawing.Color.SkyBlue;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 141);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(267, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "/";
            // 
            // label_ttime
            // 
            this.label_ttime.AutoSize = true;
            this.label_ttime.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ttime.Location = new System.Drawing.Point(286, 92);
            this.label_ttime.Name = "label_ttime";
            this.label_ttime.Size = new System.Drawing.Size(39, 17);
            this.label_ttime.TabIndex = 4;
            this.label_ttime.Text = "00:00";
            // 
            // label_ptime
            // 
            this.label_ptime.AutoSize = true;
            this.label_ptime.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ptime.Location = new System.Drawing.Point(221, 92);
            this.label_ptime.Name = "label_ptime";
            this.label_ptime.Size = new System.Drawing.Size(39, 17);
            this.label_ptime.TabIndex = 3;
            this.label_ptime.Text = "00:00";
            // 
            // label_album
            // 
            this.label_album.AutoSize = true;
            this.label_album.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_album.Location = new System.Drawing.Point(27, 115);
            this.label_album.Name = "label_album";
            this.label_album.Size = new System.Drawing.Size(165, 15);
            this.label_album.TabIndex = 2;
            this.label_album.Text = "Name of Album, Play or Disc";
            // 
            // label_artist
            // 
            this.label_artist.AutoSize = true;
            this.label_artist.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_artist.Location = new System.Drawing.Point(17, 14);
            this.label_artist.Name = "label_artist";
            this.label_artist.Size = new System.Drawing.Size(96, 17);
            this.label_artist.TabIndex = 0;
            this.label_artist.Text = "Name of Artist";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.label_title);
            this.panel3.Location = new System.Drawing.Point(49, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(384, 50);
            this.panel3.TabIndex = 1;
            // 
            // label_title
            // 
            this.label_title.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.Location = new System.Drawing.Point(3, 9);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(667, 41);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "Music Title 2020";
            // 
            // btn_Play
            // 
            this.btn_Play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Play.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Play.ForeColor = System.Drawing.Color.SkyBlue;
            this.btn_Play.Location = new System.Drawing.Point(179, 150);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(42, 34);
            this.btn_Play.TabIndex = 8;
            this.btn_Play.Text = "➤";
            this.btn_Play.UseVisualStyleBackColor = false;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stop.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.ForeColor = System.Drawing.Color.SkyBlue;
            this.btn_stop.Location = new System.Drawing.Point(131, 150);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(42, 34);
            this.btn_stop.TabIndex = 9;
            this.btn_stop.Text = "■";
            this.btn_stop.UseVisualStyleBackColor = false;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_next
            // 
            this.btn_next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next.Font = new System.Drawing.Font("Bernard MT Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.ForeColor = System.Drawing.Color.SkyBlue;
            this.btn_next.Location = new System.Drawing.Point(227, 150);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(42, 34);
            this.btn_next.TabIndex = 10;
            this.btn_next.Text = "►►";
            this.btn_next.UseVisualStyleBackColor = false;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_previous
            // 
            this.btn_previous.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_previous.Font = new System.Drawing.Font("Bernard MT Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_previous.ForeColor = System.Drawing.Color.SkyBlue;
            this.btn_previous.Location = new System.Drawing.Point(83, 150);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(42, 34);
            this.btn_previous.TabIndex = 11;
            this.btn_previous.Text = "◄◄";
            this.btn_previous.UseVisualStyleBackColor = false;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pause.Font = new System.Drawing.Font("Bauhaus 93", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pause.ForeColor = System.Drawing.Color.SkyBlue;
            this.btn_pause.Location = new System.Drawing.Point(292, 151);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(42, 34);
            this.btn_pause.TabIndex = 12;
            this.btn_pause.Text = "||";
            this.btn_pause.UseVisualStyleBackColor = false;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel4.Controls.Add(this.btn_pause);
            this.panel4.Controls.Add(this.btn_previous);
            this.panel4.Controls.Add(this.btn_next);
            this.panel4.Controls.Add(this.btn_stop);
            this.panel4.Controls.Add(this.btn_Play);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Location = new System.Drawing.Point(2, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(350, 326);
            this.panel4.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader Filename;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_ramd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_ttime;
        private System.Windows.Forms.Label label_ptime;
        private System.Windows.Forms.Label label_album;
        private System.Windows.Forms.Label label_artist;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Button btn_Play;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_previous;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Panel panel4;
    }
}

