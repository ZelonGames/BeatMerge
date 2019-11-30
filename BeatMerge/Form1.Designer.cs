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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.listMap = new System.Windows.Forms.ListBox();
            this.btnAddSongPack = new System.Windows.Forms.Button();
            this.listSongPacks = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSongPackName = new System.Windows.Forms.TextBox();
            this.btnDeleteSongPack = new System.Windows.Forms.Button();
            this.btnDeleteMap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewBpm = new System.Windows.Forms.TextBox();
            this.grpMaps = new System.Windows.Forms.GroupBox();
            this.checkIgnoreObstacles = new System.Windows.Forms.CheckBox();
            this.checkIgnoreEvents = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpMaps.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 35);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(203, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add Map";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(134, 385);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(207, 23);
            this.btnMerge.TabIndex = 2;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // listMap
            // 
            this.listMap.FormattingEnabled = true;
            this.listMap.Location = new System.Drawing.Point(6, 64);
            this.listMap.Name = "listMap";
            this.listMap.Size = new System.Drawing.Size(335, 303);
            this.listMap.TabIndex = 3;
            this.listMap.Tag = "";
            // 
            // btnAddSongPack
            // 
            this.btnAddSongPack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSongPack.Location = new System.Drawing.Point(231, 29);
            this.btnAddSongPack.Name = "btnAddSongPack";
            this.btnAddSongPack.Size = new System.Drawing.Size(150, 23);
            this.btnAddSongPack.TabIndex = 4;
            this.btnAddSongPack.Text = "Create New Song Pack";
            this.btnAddSongPack.UseVisualStyleBackColor = true;
            // 
            // listSongPacks
            // 
            this.listSongPacks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listSongPacks.FormattingEnabled = true;
            this.listSongPacks.Location = new System.Drawing.Point(6, 62);
            this.listSongPacks.Name = "listSongPacks";
            this.listSongPacks.Size = new System.Drawing.Size(372, 290);
            this.listSongPacks.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Song Pack Name:";
            // 
            // txtSongPackName
            // 
            this.txtSongPackName.Location = new System.Drawing.Point(103, 31);
            this.txtSongPackName.Name = "txtSongPackName";
            this.txtSongPackName.Size = new System.Drawing.Size(119, 20);
            this.txtSongPackName.TabIndex = 9;
            // 
            // btnDeleteSongPack
            // 
            this.btnDeleteSongPack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteSongPack.Location = new System.Drawing.Point(6, 387);
            this.btnDeleteSongPack.Name = "btnDeleteSongPack";
            this.btnDeleteSongPack.Size = new System.Drawing.Size(372, 23);
            this.btnDeleteSongPack.TabIndex = 10;
            this.btnDeleteSongPack.Text = "Delete Selected Song Pack";
            this.btnDeleteSongPack.UseVisualStyleBackColor = true;
            // 
            // btnDeleteMap
            // 
            this.btnDeleteMap.Location = new System.Drawing.Point(215, 34);
            this.btnDeleteMap.Name = "btnDeleteMap";
            this.btnDeleteMap.Size = new System.Drawing.Size(126, 23);
            this.btnDeleteMap.TabIndex = 11;
            this.btnDeleteMap.Text = "Delete Selected Map";
            this.btnDeleteMap.UseVisualStyleBackColor = true;
            this.btnDeleteMap.Click += new System.EventHandler(this.btnDeleteMap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "New BPM:";
            // 
            // txtNewBpm
            // 
            this.txtNewBpm.Location = new System.Drawing.Point(70, 388);
            this.txtNewBpm.Name = "txtNewBpm";
            this.txtNewBpm.Size = new System.Drawing.Size(58, 20);
            this.txtNewBpm.TabIndex = 13;
            this.txtNewBpm.Text = "120";
            // 
            // grpMaps
            // 
            this.grpMaps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMaps.Controls.Add(this.checkIgnoreObstacles);
            this.grpMaps.Controls.Add(this.checkIgnoreEvents);
            this.grpMaps.Controls.Add(this.listMap);
            this.grpMaps.Controls.Add(this.btnAdd);
            this.grpMaps.Controls.Add(this.txtNewBpm);
            this.grpMaps.Controls.Add(this.btnMerge);
            this.grpMaps.Controls.Add(this.label2);
            this.grpMaps.Controls.Add(this.btnDeleteMap);
            this.grpMaps.Location = new System.Drawing.Point(412, 12);
            this.grpMaps.Name = "grpMaps";
            this.grpMaps.Size = new System.Drawing.Size(457, 421);
            this.grpMaps.TabIndex = 14;
            this.grpMaps.TabStop = false;
            this.grpMaps.Text = "Maps";
            this.grpMaps.Visible = false;
            // 
            // checkIgnoreObstacles
            // 
            this.checkIgnoreObstacles.AutoSize = true;
            this.checkIgnoreObstacles.Checked = true;
            this.checkIgnoreObstacles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkIgnoreObstacles.Location = new System.Drawing.Point(347, 87);
            this.checkIgnoreObstacles.Name = "checkIgnoreObstacles";
            this.checkIgnoreObstacles.Size = new System.Drawing.Size(106, 17);
            this.checkIgnoreObstacles.TabIndex = 18;
            this.checkIgnoreObstacles.Text = "Ignore Obstacles";
            this.checkIgnoreObstacles.UseVisualStyleBackColor = true;
            // 
            // checkIgnoreEvents
            // 
            this.checkIgnoreEvents.AutoSize = true;
            this.checkIgnoreEvents.Location = new System.Drawing.Point(347, 64);
            this.checkIgnoreEvents.Name = "checkIgnoreEvents";
            this.checkIgnoreEvents.Size = new System.Drawing.Size(92, 17);
            this.checkIgnoreEvents.TabIndex = 17;
            this.checkIgnoreEvents.Text = "Ignore Events";
            this.checkIgnoreEvents.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.listSongPacks);
            this.groupBox2.Controls.Add(this.btnAddSongPack);
            this.groupBox2.Controls.Add(this.btnDeleteSongPack);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtSongPackName);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 421);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Song Packs";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 455);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpMaps);
            this.MinimumSize = new System.Drawing.Size(806, 296);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Beat Merge";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpMaps.ResumeLayout(false);
            this.grpMaps.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnAddSongPack;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtSongPackName;
        public System.Windows.Forms.ListBox listSongPacks;
        public System.Windows.Forms.ListBox listMap;
        private System.Windows.Forms.Button btnDeleteSongPack;
        private System.Windows.Forms.Button btnDeleteMap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewBpm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkIgnoreObstacles;
        private System.Windows.Forms.CheckBox checkIgnoreEvents;
        public System.Windows.Forms.GroupBox grpMaps;
    }
}

