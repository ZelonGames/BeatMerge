﻿namespace BeatMerge
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstTimeStamps = new System.Windows.Forms.ListBox();
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
            this.btnMerge.Location = new System.Drawing.Point(134, 393);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(105, 23);
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
            this.btnAddSongPack.Click += new System.EventHandler(this.btnAddSongPack_Click);
            // 
            // listSongPacks
            // 
            this.listSongPacks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listSongPacks.FormattingEnabled = true;
            this.listSongPacks.Location = new System.Drawing.Point(6, 62);
            this.listSongPacks.Name = "listSongPacks";
            this.listSongPacks.Size = new System.Drawing.Size(372, 303);
            this.listSongPacks.TabIndex = 7;
            this.listSongPacks.SelectedIndexChanged += new System.EventHandler(this.listSongPacks_SelectedIndexChanged);
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
            this.btnDeleteSongPack.Location = new System.Drawing.Point(6, 388);
            this.btnDeleteSongPack.Name = "btnDeleteSongPack";
            this.btnDeleteSongPack.Size = new System.Drawing.Size(372, 23);
            this.btnDeleteSongPack.TabIndex = 10;
            this.btnDeleteSongPack.Text = "Delete Selected Song Pack";
            this.btnDeleteSongPack.UseVisualStyleBackColor = true;
            this.btnDeleteSongPack.Click += new System.EventHandler(this.btnDeleteSongPack_Click);
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
            this.label2.Location = new System.Drawing.Point(6, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "New BPM:";
            // 
            // txtNewBpm
            // 
            this.txtNewBpm.Location = new System.Drawing.Point(70, 395);
            this.txtNewBpm.Name = "txtNewBpm";
            this.txtNewBpm.Size = new System.Drawing.Size(58, 20);
            this.txtNewBpm.TabIndex = 13;
            this.txtNewBpm.Text = "120";
            // 
            // grpMaps
            // 
            this.grpMaps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMaps.Controls.Add(this.checkBox1);
            this.grpMaps.Controls.Add(this.label3);
            this.grpMaps.Controls.Add(this.lstTimeStamps);
            this.grpMaps.Controls.Add(this.listMap);
            this.grpMaps.Controls.Add(this.btnAdd);
            this.grpMaps.Controls.Add(this.txtNewBpm);
            this.grpMaps.Controls.Add(this.btnMerge);
            this.grpMaps.Controls.Add(this.label2);
            this.grpMaps.Controls.Add(this.btnDeleteMap);
            this.grpMaps.Location = new System.Drawing.Point(409, 12);
            this.grpMaps.Name = "grpMaps";
            this.grpMaps.Size = new System.Drawing.Size(491, 422);
            this.grpMaps.TabIndex = 14;
            this.grpMaps.TabStop = false;
            this.grpMaps.Text = "Maps";
            this.grpMaps.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(293, 388);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Use custom start times";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Start time:";
            // 
            // lstTimeStamps
            // 
            this.lstTimeStamps.FormattingEnabled = true;
            this.lstTimeStamps.Location = new System.Drawing.Point(347, 64);
            this.lstTimeStamps.Name = "lstTimeStamps";
            this.lstTimeStamps.Size = new System.Drawing.Size(132, 303);
            this.lstTimeStamps.TabIndex = 14;
            this.lstTimeStamps.Tag = "";
            this.lstTimeStamps.Visible = false;
            this.lstTimeStamps.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstTimeStamps_MouseDoubleClick);
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
            this.groupBox2.Size = new System.Drawing.Size(387, 422);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Song Packs";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 456);
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
        private System.Windows.Forms.GroupBox grpMaps;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ListBox lstTimeStamps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

