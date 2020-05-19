namespace Karuta___wersja_anime
{
    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wybierzPlikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wybierzFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgranieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.AnimeListBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AnimeInfoBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PlayerName1 = new System.Windows.Forms.TextBox();
            this.PlayerName2 = new System.Windows.Forms.TextBox();
            this.PlayerName3 = new System.Windows.Forms.TextBox();
            this.PlayerName4 = new System.Windows.Forms.TextBox();
            this.PlayerName5 = new System.Windows.Forms.TextBox();
            this.PlayerName6 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SettingsOP = new System.Windows.Forms.CheckBox();
            this.SettingsED = new System.Windows.Forms.CheckBox();
            this.SettingsIN = new System.Windows.Forms.CheckBox();
            this.PlayButton = new System.Windows.Forms.Button();
            this.RefreshAnimeListBox = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.SettingsFromStart = new System.Windows.Forms.RadioButton();
            this.SettingsRandom = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.pomocToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(724, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wybierzPlikToolStripMenuItem,
            this.wybierzFolderToolStripMenuItem});
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // wybierzPlikToolStripMenuItem
            // 
            this.wybierzPlikToolStripMenuItem.Name = "wybierzPlikToolStripMenuItem";
            this.wybierzPlikToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.wybierzPlikToolStripMenuItem.Text = "Wybierz plik";
            this.wybierzPlikToolStripMenuItem.Click += new System.EventHandler(this.WybierzPlikToolStripMenuItem_Click);
            // 
            // wybierzFolderToolStripMenuItem
            // 
            this.wybierzFolderToolStripMenuItem.Name = "wybierzFolderToolStripMenuItem";
            this.wybierzFolderToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.wybierzFolderToolStripMenuItem.Text = "Wybierz folder";
            this.wybierzFolderToolStripMenuItem.Click += new System.EventHandler(this.WybierzFolderToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logToolStripMenuItem,
            this.oProgranieToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.logToolStripMenuItem.Text = "Log";
            this.logToolStripMenuItem.Click += new System.EventHandler(this.LogToolStripMenuItem_Click);
            // 
            // oProgranieToolStripMenuItem
            // 
            this.oProgranieToolStripMenuItem.Name = "oProgranieToolStripMenuItem";
            this.oProgranieToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.oProgranieToolStripMenuItem.Text = "O progranie";
            this.oProgranieToolStripMenuItem.Click += new System.EventHandler(this.OProgranieToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.TestToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 664);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(724, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // AnimeListBox
            // 
            this.AnimeListBox.Enabled = false;
            this.AnimeListBox.Location = new System.Drawing.Point(12, 49);
            this.AnimeListBox.Name = "AnimeListBox";
            this.AnimeListBox.Size = new System.Drawing.Size(600, 20);
            this.AnimeListBox.TabIndex = 3;
            this.AnimeListBox.TextChanged += new System.EventHandler(this.AnimeListBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Karty biorące udział w grze (np. 1,5,48,65,123)";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.ColumnWidth = 300;
            this.checkedListBox1.Enabled = false;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 88);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(600, 349);
            this.checkedListBox1.TabIndex = 6;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lista wczytanych kart z pliku";
            // 
            // AnimeInfoBox
            // 
            this.AnimeInfoBox.Enabled = false;
            this.AnimeInfoBox.Location = new System.Drawing.Point(15, 456);
            this.AnimeInfoBox.Multiline = true;
            this.AnimeInfoBox.Name = "AnimeInfoBox";
            this.AnimeInfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.AnimeInfoBox.Size = new System.Drawing.Size(597, 200);
            this.AnimeInfoBox.TabIndex = 8;
            this.AnimeInfoBox.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 440);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Informacje o anime";
            // 
            // PlayerName1
            // 
            this.PlayerName1.Location = new System.Drawing.Point(618, 49);
            this.PlayerName1.Name = "PlayerName1";
            this.PlayerName1.Size = new System.Drawing.Size(100, 20);
            this.PlayerName1.TabIndex = 10;
            // 
            // PlayerName2
            // 
            this.PlayerName2.Location = new System.Drawing.Point(618, 75);
            this.PlayerName2.Name = "PlayerName2";
            this.PlayerName2.Size = new System.Drawing.Size(100, 20);
            this.PlayerName2.TabIndex = 11;
            // 
            // PlayerName3
            // 
            this.PlayerName3.Location = new System.Drawing.Point(618, 101);
            this.PlayerName3.Name = "PlayerName3";
            this.PlayerName3.Size = new System.Drawing.Size(100, 20);
            this.PlayerName3.TabIndex = 12;
            // 
            // PlayerName4
            // 
            this.PlayerName4.Location = new System.Drawing.Point(618, 127);
            this.PlayerName4.Name = "PlayerName4";
            this.PlayerName4.Size = new System.Drawing.Size(100, 20);
            this.PlayerName4.TabIndex = 13;
            // 
            // PlayerName5
            // 
            this.PlayerName5.Location = new System.Drawing.Point(618, 153);
            this.PlayerName5.Name = "PlayerName5";
            this.PlayerName5.Size = new System.Drawing.Size(100, 20);
            this.PlayerName5.TabIndex = 14;
            // 
            // PlayerName6
            // 
            this.PlayerName6.Location = new System.Drawing.Point(618, 179);
            this.PlayerName6.Name = "PlayerName6";
            this.PlayerName6.Size = new System.Drawing.Size(100, 20);
            this.PlayerName6.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(615, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Gracze";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(615, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Utwory";
            // 
            // SettingsOP
            // 
            this.SettingsOP.AutoSize = true;
            this.SettingsOP.Checked = true;
            this.SettingsOP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SettingsOP.Location = new System.Drawing.Point(618, 218);
            this.SettingsOP.Name = "SettingsOP";
            this.SettingsOP.Size = new System.Drawing.Size(68, 17);
            this.SettingsOP.TabIndex = 18;
            this.SettingsOP.Text = "Openingi";
            this.SettingsOP.UseVisualStyleBackColor = true;
            // 
            // SettingsED
            // 
            this.SettingsED.AutoSize = true;
            this.SettingsED.Location = new System.Drawing.Point(618, 241);
            this.SettingsED.Name = "SettingsED";
            this.SettingsED.Size = new System.Drawing.Size(61, 17);
            this.SettingsED.TabIndex = 19;
            this.SettingsED.Text = "Endingi";
            this.SettingsED.UseVisualStyleBackColor = true;
            // 
            // SettingsIN
            // 
            this.SettingsIN.AutoSize = true;
            this.SettingsIN.Location = new System.Drawing.Point(618, 264);
            this.SettingsIN.Name = "SettingsIN";
            this.SettingsIN.Size = new System.Drawing.Size(57, 17);
            this.SettingsIN.TabIndex = 20;
            this.SettingsIN.Text = "Inserty";
            this.SettingsIN.UseVisualStyleBackColor = true;
            // 
            // PlayButton
            // 
            this.PlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayButton.Location = new System.Drawing.Point(618, 606);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(100, 50);
            this.PlayButton.TabIndex = 22;
            this.PlayButton.Text = "Graj";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // RefreshAnimeListBox
            // 
            this.RefreshAnimeListBox.Enabled = true;
            this.RefreshAnimeListBox.Interval = 50;
            this.RefreshAnimeListBox.Tick += new System.EventHandler(this.RefreshAnimeListBox_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(615, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Odtwarzanie";
            // 
            // SettingsFromStart
            // 
            this.SettingsFromStart.AutoSize = true;
            this.SettingsFromStart.Checked = true;
            this.SettingsFromStart.Location = new System.Drawing.Point(618, 300);
            this.SettingsFromStart.Name = "SettingsFromStart";
            this.SettingsFromStart.Size = new System.Drawing.Size(86, 17);
            this.SettingsFromStart.TabIndex = 24;
            this.SettingsFromStart.TabStop = true;
            this.SettingsFromStart.Text = "Od początku";
            this.SettingsFromStart.UseVisualStyleBackColor = true;
            // 
            // SettingsRandom
            // 
            this.SettingsRandom.AutoSize = true;
            this.SettingsRandom.Location = new System.Drawing.Point(618, 323);
            this.SettingsRandom.Name = "SettingsRandom";
            this.SettingsRandom.Size = new System.Drawing.Size(62, 17);
            this.SettingsRandom.TabIndex = 25;
            this.SettingsRandom.Text = "Losowo";
            this.SettingsRandom.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 686);
            this.Controls.Add(this.SettingsRandom);
            this.Controls.Add(this.SettingsFromStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.SettingsIN);
            this.Controls.Add(this.SettingsED);
            this.Controls.Add(this.SettingsOP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PlayerName6);
            this.Controls.Add(this.PlayerName5);
            this.Controls.Add(this.PlayerName4);
            this.Controls.Add(this.PlayerName3);
            this.Controls.Add(this.PlayerName2);
            this.Controls.Add(this.PlayerName1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AnimeInfoBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AnimeListBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Karuta - wersja anime";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wybierzFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wybierzPlikToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgranieToolStripMenuItem;
        private System.Windows.Forms.TextBox AnimeListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AnimeInfoBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PlayerName1;
        private System.Windows.Forms.TextBox PlayerName2;
        private System.Windows.Forms.TextBox PlayerName3;
        private System.Windows.Forms.TextBox PlayerName4;
        private System.Windows.Forms.TextBox PlayerName5;
        private System.Windows.Forms.TextBox PlayerName6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox SettingsOP;
        private System.Windows.Forms.CheckBox SettingsED;
        private System.Windows.Forms.CheckBox SettingsIN;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Timer RefreshAnimeListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton SettingsFromStart;
        private System.Windows.Forms.RadioButton SettingsRandom;
    }
}

