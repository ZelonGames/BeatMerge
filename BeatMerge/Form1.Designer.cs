namespace BeatMerge
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMerge = new System.Windows.Forms.Button();
            this.txtJsonBegin = new System.Windows.Forms.TextBox();
            this.txtJsonEnd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();
            this.grpMerge = new System.Windows.Forms.GroupBox();
            this.grpBPM = new System.Windows.Forms.GroupBox();
            this.txtNewBPM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJsonFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChangeBPM = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mergeSongsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeBPMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSettings = new System.Windows.Forms.TextBox();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpMerge.SuspendLayout();
            this.grpBPM.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMerge.Location = new System.Drawing.Point(21, 133);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(704, 23);
            this.btnMerge.TabIndex = 0;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // txtJsonBegin
            // 
            this.txtJsonBegin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJsonBegin.Location = new System.Drawing.Point(145, 30);
            this.txtJsonBegin.Name = "txtJsonBegin";
            this.txtJsonBegin.Size = new System.Drawing.Size(422, 20);
            this.txtJsonBegin.TabIndex = 1;
            this.txtJsonBegin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtJsonBegin_MouseClick);
            // 
            // txtJsonEnd
            // 
            this.txtJsonEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJsonEnd.Location = new System.Drawing.Point(145, 81);
            this.txtJsonEnd.Name = "txtJsonEnd";
            this.txtJsonEnd.Size = new System.Drawing.Size(422, 20);
            this.txtJsonEnd.TabIndex = 2;
            this.txtJsonEnd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtJsonEnd_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Begin Map Folder Name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "End Map Folder Name";
            // 
            // cmbDifficulty
            // 
            this.cmbDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDifficulty.FormattingEnabled = true;
            this.cmbDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard",
            "Expert",
            "ExpertPlus"});
            this.cmbDifficulty.Location = new System.Drawing.Point(604, 29);
            this.cmbDifficulty.Name = "cmbDifficulty";
            this.cmbDifficulty.Size = new System.Drawing.Size(121, 21);
            this.cmbDifficulty.TabIndex = 6;
            this.cmbDifficulty.Text = "Difficulty";
            // 
            // grpMerge
            // 
            this.grpMerge.Controls.Add(this.cmbDifficulty);
            this.grpMerge.Controls.Add(this.btnMerge);
            this.grpMerge.Controls.Add(this.txtJsonBegin);
            this.grpMerge.Controls.Add(this.label1);
            this.grpMerge.Controls.Add(this.label2);
            this.grpMerge.Controls.Add(this.txtJsonEnd);
            this.grpMerge.Location = new System.Drawing.Point(12, 53);
            this.grpMerge.Name = "grpMerge";
            this.grpMerge.Size = new System.Drawing.Size(746, 178);
            this.grpMerge.TabIndex = 9;
            this.grpMerge.TabStop = false;
            this.grpMerge.Text = "Merge Songs";
            this.grpMerge.Visible = false;
            // 
            // grpBPM
            // 
            this.grpBPM.Controls.Add(this.txtNewBPM);
            this.grpBPM.Controls.Add(this.label5);
            this.grpBPM.Controls.Add(this.txtJsonFile);
            this.grpBPM.Controls.Add(this.label4);
            this.grpBPM.Controls.Add(this.btnChangeBPM);
            this.grpBPM.Location = new System.Drawing.Point(12, 262);
            this.grpBPM.Name = "grpBPM";
            this.grpBPM.Size = new System.Drawing.Size(746, 147);
            this.grpBPM.TabIndex = 10;
            this.grpBPM.TabStop = false;
            this.grpBPM.Text = "Change BPM";
            this.grpBPM.Visible = false;
            // 
            // txtNewBPM
            // 
            this.txtNewBPM.Location = new System.Drawing.Point(104, 72);
            this.txtNewBPM.Name = "txtNewBPM";
            this.txtNewBPM.Size = new System.Drawing.Size(51, 20);
            this.txtNewBPM.TabIndex = 5;
            this.txtNewBPM.Text = "0";
            this.txtNewBPM.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox2_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "New BPM";
            // 
            // txtJsonFile
            // 
            this.txtJsonFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJsonFile.Location = new System.Drawing.Point(104, 32);
            this.txtJsonFile.Name = "txtJsonFile";
            this.txtJsonFile.Size = new System.Drawing.Size(621, 20);
            this.txtJsonFile.TabIndex = 3;
            this.txtJsonFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = ".json File";
            // 
            // btnChangeBPM
            // 
            this.btnChangeBPM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeBPM.Location = new System.Drawing.Point(21, 109);
            this.btnChangeBPM.Name = "btnChangeBPM";
            this.btnChangeBPM.Size = new System.Drawing.Size(704, 23);
            this.btnChangeBPM.TabIndex = 1;
            this.btnChangeBPM.Text = "Change BPM";
            this.btnChangeBPM.UseVisualStyleBackColor = true;
            this.btnChangeBPM.Click += new System.EventHandler(this.btnChangeBPM_click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.mergeSongsToolStripMenuItem,
            this.changeBPMToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(790, 24);
            this.menuStrip.TabIndex = 11;
            this.menuStrip.Text = "menuStrip1";
            // 
            // mergeSongsToolStripMenuItem
            // 
            this.mergeSongsToolStripMenuItem.Name = "mergeSongsToolStripMenuItem";
            this.mergeSongsToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.mergeSongsToolStripMenuItem.Text = "Merge Songs";
            this.mergeSongsToolStripMenuItem.Click += new System.EventHandler(this.mergeSongsToolStripMenuItem_Click);
            // 
            // changeBPMToolStripMenuItem
            // 
            this.changeBPMToolStripMenuItem.Name = "changeBPMToolStripMenuItem";
            this.changeBPMToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.changeBPMToolStripMenuItem.Text = "Change BPM";
            this.changeBPMToolStripMenuItem.Click += new System.EventHandler(this.changeBPMToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Base Path";
            // 
            // txtSettings
            // 
            this.txtSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettings.Location = new System.Drawing.Point(104, 44);
            this.txtSettings.Name = "txtSettings";
            this.txtSettings.Size = new System.Drawing.Size(621, 20);
            this.txtSettings.TabIndex = 13;
            this.txtSettings.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSettings_MouseClick);
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.btnSave);
            this.grpSettings.Controls.Add(this.txtSettings);
            this.grpSettings.Controls.Add(this.label3);
            this.grpSettings.Location = new System.Drawing.Point(12, 449);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(746, 124);
            this.grpSettings.TabIndex = 14;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            this.grpSettings.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(21, 95);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(704, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 629);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.grpBPM);
            this.Controls.Add(this.grpMerge);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(806, 296);
            this.Name = "Form1";
            this.Text = "Beat Merge";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpMerge.ResumeLayout(false);
            this.grpMerge.PerformLayout();
            this.grpBPM.ResumeLayout(false);
            this.grpBPM.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChangeBPM;
        private System.Windows.Forms.ToolStripMenuItem mergeSongsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBPMToolStripMenuItem;
        public System.Windows.Forms.GroupBox grpMerge;
        public System.Windows.Forms.GroupBox grpBPM;
        public System.Windows.Forms.MenuStrip menuStrip;
        public System.Windows.Forms.TextBox txtJsonBegin;
        public System.Windows.Forms.TextBox txtJsonEnd;
        public System.Windows.Forms.ComboBox cmbDifficulty;
        private System.Windows.Forms.TextBox txtNewBPM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtJsonFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSettings;
        public System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Button btnSave;
    }
}

