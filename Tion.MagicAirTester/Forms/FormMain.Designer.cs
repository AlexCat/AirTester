﻿namespace Tion.MagicAirTester.Forms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox_autotest = new System.Windows.Forms.CheckBox();
            this.button_magicAirFind = new System.Windows.Forms.Button();
            this.groupBox_testingIndicators = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox_breezerControls = new System.Windows.Forms.GroupBox();
            this.button_connectBreezer = new System.Windows.Forms.Button();
            this.button_breezerSpeedUp = new System.Windows.Forms.Button();
            this.button_breezerSpeedDown = new System.Windows.Forms.Button();
            this.button_unpairBreezer = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox_testingIndicators.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_breezerControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(285, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chineseToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // chineseToolStripMenuItem
            // 
            this.chineseToolStripMenuItem.Name = "chineseToolStripMenuItem";
            this.chineseToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.chineseToolStripMenuItem.Text = "Chinese";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.englishToolStripMenuItem.Text = "English";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // checkBox_autotest
            // 
            this.checkBox_autotest.AutoSize = true;
            this.checkBox_autotest.Checked = true;
            this.checkBox_autotest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_autotest.Location = new System.Drawing.Point(96, 40);
            this.checkBox_autotest.Name = "checkBox_autotest";
            this.checkBox_autotest.Size = new System.Drawing.Size(110, 21);
            this.checkBox_autotest.TabIndex = 1;
            this.checkBox_autotest.Text = "Automatic test";
            this.checkBox_autotest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_autotest.UseVisualStyleBackColor = true;
            // 
            // button_magicAirFind
            // 
            this.button_magicAirFind.Location = new System.Drawing.Point(13, 71);
            this.button_magicAirFind.Name = "button_magicAirFind";
            this.button_magicAirFind.Size = new System.Drawing.Size(132, 29);
            this.button_magicAirFind.TabIndex = 2;
            this.button_magicAirFind.Text = "Find new MagicAir";
            this.button_magicAirFind.UseVisualStyleBackColor = true;
            this.button_magicAirFind.Click += new System.EventHandler(this.button_magicAirFind_Click);
            // 
            // groupBox_testingIndicators
            // 
            this.groupBox_testingIndicators.Controls.Add(this.pictureBox3);
            this.groupBox_testingIndicators.Controls.Add(this.pictureBox2);
            this.groupBox_testingIndicators.Controls.Add(this.pictureBox1);
            this.groupBox_testingIndicators.Location = new System.Drawing.Point(11, 110);
            this.groupBox_testingIndicators.Name = "groupBox_testingIndicators";
            this.groupBox_testingIndicators.Size = new System.Drawing.Size(240, 128);
            this.groupBox_testingIndicators.TabIndex = 3;
            this.groupBox_testingIndicators.TabStop = false;
            this.groupBox_testingIndicators.Text = "Indicators";
            this.groupBox_testingIndicators.Enter += new System.EventHandler(this.groupBox_testingIndicators_Enter);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Tion.MagicAirTester.Properties.Resources.ok_rr;
            this.pictureBox3.Location = new System.Drawing.Point(163, 37);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(71, 59);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Tion.MagicAirTester.Properties.Resources.breezer_logo_rr;
            this.pictureBox2.Location = new System.Drawing.Point(85, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(71, 59);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox_breezerControls
            // 
            this.groupBox_breezerControls.Controls.Add(this.button_unpairBreezer);
            this.groupBox_breezerControls.Controls.Add(this.button_breezerSpeedDown);
            this.groupBox_breezerControls.Controls.Add(this.button_breezerSpeedUp);
            this.groupBox_breezerControls.Location = new System.Drawing.Point(17, 262);
            this.groupBox_breezerControls.Name = "groupBox_breezerControls";
            this.groupBox_breezerControls.Size = new System.Drawing.Size(256, 100);
            this.groupBox_breezerControls.TabIndex = 4;
            this.groupBox_breezerControls.TabStop = false;
            this.groupBox_breezerControls.Text = "Breezer controls";
            // 
            // button_connectBreezer
            // 
            this.button_connectBreezer.Location = new System.Drawing.Point(150, 71);
            this.button_connectBreezer.Name = "button_connectBreezer";
            this.button_connectBreezer.Size = new System.Drawing.Size(125, 29);
            this.button_connectBreezer.TabIndex = 5;
            this.button_connectBreezer.Text = "Connect Breezer";
            this.button_connectBreezer.UseVisualStyleBackColor = true;
            // 
            // button_breezerSpeedUp
            // 
            this.button_breezerSpeedUp.Location = new System.Drawing.Point(18, 25);
            this.button_breezerSpeedUp.Name = "button_breezerSpeedUp";
            this.button_breezerSpeedUp.Size = new System.Drawing.Size(92, 29);
            this.button_breezerSpeedUp.TabIndex = 0;
            this.button_breezerSpeedUp.Text = "Speed Up";
            this.button_breezerSpeedUp.UseVisualStyleBackColor = true;
            // 
            // button_breezerSpeedDown
            // 
            this.button_breezerSpeedDown.Location = new System.Drawing.Point(18, 61);
            this.button_breezerSpeedDown.Name = "button_breezerSpeedDown";
            this.button_breezerSpeedDown.Size = new System.Drawing.Size(92, 29);
            this.button_breezerSpeedDown.TabIndex = 1;
            this.button_breezerSpeedDown.Text = "Speed Down";
            this.button_breezerSpeedDown.UseVisualStyleBackColor = true;
            // 
            // button_unpairBreezer
            // 
            this.button_unpairBreezer.Location = new System.Drawing.Point(126, 25);
            this.button_unpairBreezer.Name = "button_unpairBreezer";
            this.button_unpairBreezer.Size = new System.Drawing.Size(115, 29);
            this.button_unpairBreezer.TabIndex = 2;
            this.button_unpairBreezer.Text = "Unpair Breezer";
            this.button_unpairBreezer.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 396);
            this.Controls.Add(this.button_connectBreezer);
            this.Controls.Add(this.groupBox_breezerControls);
            this.Controls.Add(this.groupBox_testingIndicators);
            this.Controls.Add(this.button_magicAirFind);
            this.Controls.Add(this.checkBox_autotest);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.Text = "MagicAir Tester";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox_testingIndicators.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_breezerControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chineseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_autotest;
        private System.Windows.Forms.Button button_magicAirFind;
        private System.Windows.Forms.GroupBox groupBox_testingIndicators;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupBox_breezerControls;
        private System.Windows.Forms.Button button_unpairBreezer;
        private System.Windows.Forms.Button button_breezerSpeedDown;
        private System.Windows.Forms.Button button_breezerSpeedUp;
        private System.Windows.Forms.Button button_connectBreezer;
    }
}