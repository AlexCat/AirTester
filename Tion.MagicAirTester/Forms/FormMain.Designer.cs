namespace Tion.MagicAirTester.Forms
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
            this.groupBox_breezerControls = new System.Windows.Forms.GroupBox();
            this.button_unpairBreezer = new System.Windows.Forms.Button();
            this.button_breezerSpeedDown = new System.Windows.Forms.Button();
            this.button_breezerSpeedUp = new System.Windows.Forms.Button();
            this.button_connectBreezer = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.RichTextBox();
            this.breezerInfoPanel = new System.Windows.Forms.GroupBox();
            this.breezerIsConnectedValue = new System.Windows.Forms.Label();
            this.breezerIsConnected = new System.Windows.Forms.Label();
            this.breezerSpeedValue = new System.Windows.Forms.Label();
            this.breezerSpeed = new System.Windows.Forms.Label();
            this.indicatorAutotestFailed = new System.Windows.Forms.PictureBox();
            this.indicatorAutotestPassed = new System.Windows.Forms.PictureBox();
            this.indicatorBreezer3SConnected = new System.Windows.Forms.PictureBox();
            this.indicatorMagicAirConnected = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox_testingIndicators.SuspendLayout();
            this.groupBox_breezerControls.SuspendLayout();
            this.breezerInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indicatorAutotestFailed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicatorAutotestPassed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicatorBreezer3SConnected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicatorMagicAirConnected)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chineseToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // chineseToolStripMenuItem
            // 
            resources.ApplyResources(this.chineseToolStripMenuItem, "chineseToolStripMenuItem");
            this.chineseToolStripMenuItem.Name = "chineseToolStripMenuItem";
            this.chineseToolStripMenuItem.Click += new System.EventHandler(this.chineseToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            // 
            // checkBox_autotest
            // 
            resources.ApplyResources(this.checkBox_autotest, "checkBox_autotest");
            this.checkBox_autotest.Checked = true;
            this.checkBox_autotest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_autotest.Name = "checkBox_autotest";
            this.checkBox_autotest.UseVisualStyleBackColor = true;
            this.checkBox_autotest.CheckedChanged += new System.EventHandler(this.checkBox_autotest_CheckedChanged);
            // 
            // button_magicAirFind
            // 
            resources.ApplyResources(this.button_magicAirFind, "button_magicAirFind");
            this.button_magicAirFind.Name = "button_magicAirFind";
            this.button_magicAirFind.UseVisualStyleBackColor = true;
            this.button_magicAirFind.Click += new System.EventHandler(this.button_magicAirFind_Click);
            // 
            // groupBox_testingIndicators
            // 
            resources.ApplyResources(this.groupBox_testingIndicators, "groupBox_testingIndicators");
            this.groupBox_testingIndicators.Controls.Add(this.indicatorAutotestFailed);
            this.groupBox_testingIndicators.Controls.Add(this.indicatorAutotestPassed);
            this.groupBox_testingIndicators.Controls.Add(this.indicatorBreezer3SConnected);
            this.groupBox_testingIndicators.Controls.Add(this.indicatorMagicAirConnected);
            this.groupBox_testingIndicators.Name = "groupBox_testingIndicators";
            this.groupBox_testingIndicators.TabStop = false;
            this.groupBox_testingIndicators.Enter += new System.EventHandler(this.groupBox_testingIndicators_Enter);
            // 
            // groupBox_breezerControls
            // 
            resources.ApplyResources(this.groupBox_breezerControls, "groupBox_breezerControls");
            this.groupBox_breezerControls.Controls.Add(this.button_unpairBreezer);
            this.groupBox_breezerControls.Controls.Add(this.button_breezerSpeedDown);
            this.groupBox_breezerControls.Controls.Add(this.button_breezerSpeedUp);
            this.groupBox_breezerControls.Name = "groupBox_breezerControls";
            this.groupBox_breezerControls.TabStop = false;
            // 
            // button_unpairBreezer
            // 
            resources.ApplyResources(this.button_unpairBreezer, "button_unpairBreezer");
            this.button_unpairBreezer.Name = "button_unpairBreezer";
            this.button_unpairBreezer.UseVisualStyleBackColor = true;
            this.button_unpairBreezer.Click += new System.EventHandler(this.button_unpairBreezer_Click);
            // 
            // button_breezerSpeedDown
            // 
            resources.ApplyResources(this.button_breezerSpeedDown, "button_breezerSpeedDown");
            this.button_breezerSpeedDown.Name = "button_breezerSpeedDown";
            this.button_breezerSpeedDown.UseVisualStyleBackColor = true;
            this.button_breezerSpeedDown.Click += new System.EventHandler(this.button_breezerSpeedDown_Click);
            // 
            // button_breezerSpeedUp
            // 
            resources.ApplyResources(this.button_breezerSpeedUp, "button_breezerSpeedUp");
            this.button_breezerSpeedUp.Name = "button_breezerSpeedUp";
            this.button_breezerSpeedUp.UseVisualStyleBackColor = true;
            this.button_breezerSpeedUp.Click += new System.EventHandler(this.button_breezerSpeedUp_Click);
            // 
            // button_connectBreezer
            // 
            resources.ApplyResources(this.button_connectBreezer, "button_connectBreezer");
            this.button_connectBreezer.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_connectBreezer.Name = "button_connectBreezer";
            this.button_connectBreezer.UseVisualStyleBackColor = true;
            this.button_connectBreezer.Click += new System.EventHandler(this.button_connectBreezer_Click);
            // 
            // output
            // 
            resources.ApplyResources(this.output, "output");
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.TextChanged += new System.EventHandler(this.output_TextChanged);
            // 
            // breezerInfoPanel
            // 
            resources.ApplyResources(this.breezerInfoPanel, "breezerInfoPanel");
            this.breezerInfoPanel.Controls.Add(this.breezerIsConnectedValue);
            this.breezerInfoPanel.Controls.Add(this.breezerIsConnected);
            this.breezerInfoPanel.Controls.Add(this.breezerSpeedValue);
            this.breezerInfoPanel.Controls.Add(this.breezerSpeed);
            this.breezerInfoPanel.Name = "breezerInfoPanel";
            this.breezerInfoPanel.TabStop = false;
            // 
            // breezerIsConnectedValue
            // 
            resources.ApplyResources(this.breezerIsConnectedValue, "breezerIsConnectedValue");
            this.breezerIsConnectedValue.Name = "breezerIsConnectedValue";
            // 
            // breezerIsConnected
            // 
            resources.ApplyResources(this.breezerIsConnected, "breezerIsConnected");
            this.breezerIsConnected.Name = "breezerIsConnected";
            // 
            // breezerSpeedValue
            // 
            resources.ApplyResources(this.breezerSpeedValue, "breezerSpeedValue");
            this.breezerSpeedValue.Name = "breezerSpeedValue";
            // 
            // breezerSpeed
            // 
            resources.ApplyResources(this.breezerSpeed, "breezerSpeed");
            this.breezerSpeed.Name = "breezerSpeed";
            // 
            // indicatorAutotestFailed
            // 
            resources.ApplyResources(this.indicatorAutotestFailed, "indicatorAutotestFailed");
            this.indicatorAutotestFailed.Name = "indicatorAutotestFailed";
            this.indicatorAutotestFailed.TabStop = false;
            // 
            // indicatorAutotestPassed
            // 
            resources.ApplyResources(this.indicatorAutotestPassed, "indicatorAutotestPassed");
            this.indicatorAutotestPassed.Image = global::Tion.MagicAirTester.Properties.Resources.ok_rr;
            this.indicatorAutotestPassed.Name = "indicatorAutotestPassed";
            this.indicatorAutotestPassed.TabStop = false;
            // 
            // indicatorBreezer3SConnected
            // 
            resources.ApplyResources(this.indicatorBreezer3SConnected, "indicatorBreezer3SConnected");
            this.indicatorBreezer3SConnected.Image = global::Tion.MagicAirTester.Properties.Resources.breezer_logo_rr;
            this.indicatorBreezer3SConnected.Name = "indicatorBreezer3SConnected";
            this.indicatorBreezer3SConnected.TabStop = false;
            // 
            // indicatorMagicAirConnected
            // 
            resources.ApplyResources(this.indicatorMagicAirConnected, "indicatorMagicAirConnected");
            this.indicatorMagicAirConnected.Name = "indicatorMagicAirConnected";
            this.indicatorMagicAirConnected.TabStop = false;
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.breezerInfoPanel);
            this.Controls.Add(this.output);
            this.Controls.Add(this.button_connectBreezer);
            this.Controls.Add(this.groupBox_breezerControls);
            this.Controls.Add(this.groupBox_testingIndicators);
            this.Controls.Add(this.button_magicAirFind);
            this.Controls.Add(this.checkBox_autotest);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox_testingIndicators.ResumeLayout(false);
            this.groupBox_breezerControls.ResumeLayout(false);
            this.breezerInfoPanel.ResumeLayout(false);
            this.breezerInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indicatorAutotestFailed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicatorAutotestPassed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicatorBreezer3SConnected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicatorMagicAirConnected)).EndInit();
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
        private System.Windows.Forms.PictureBox indicatorMagicAirConnected;
        private System.Windows.Forms.PictureBox indicatorBreezer3SConnected;
        private System.Windows.Forms.PictureBox indicatorAutotestPassed;
        private System.Windows.Forms.GroupBox groupBox_breezerControls;
        private System.Windows.Forms.Button button_unpairBreezer;
        private System.Windows.Forms.Button button_breezerSpeedDown;
        private System.Windows.Forms.Button button_breezerSpeedUp;
        private System.Windows.Forms.Button button_connectBreezer;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.GroupBox breezerInfoPanel;
        private System.Windows.Forms.Label breezerSpeedValue;
        private System.Windows.Forms.Label breezerSpeed;
        private System.Windows.Forms.Label breezerIsConnectedValue;
        private System.Windows.Forms.Label breezerIsConnected;
        private System.Windows.Forms.PictureBox indicatorAutotestFailed;
    }
}