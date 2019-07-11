namespace MouseMoveBot
{
    partial class Form4
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.healerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cavebotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFollowMonster = new System.Windows.Forms.CheckBox();
            this.comboBoxSdKey = new System.Windows.Forms.ComboBox();
            this.cbAttackSd = new System.Windows.Forms.CheckBox();
            this.cbTarget = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.healerToolStripMenuItem,
            this.cavebotToolStripMenuItem,
            this.targetToolStripMenuItem,
            this.lootToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(571, 24);
            this.menuStrip2.TabIndex = 16;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.HomeToolStripMenuItem_Click);
            // 
            // healerToolStripMenuItem
            // 
            this.healerToolStripMenuItem.Name = "healerToolStripMenuItem";
            this.healerToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.healerToolStripMenuItem.Text = "Healer";
            this.healerToolStripMenuItem.Click += new System.EventHandler(this.HealerToolStripMenuItem_Click);
            // 
            // cavebotToolStripMenuItem
            // 
            this.cavebotToolStripMenuItem.Name = "cavebotToolStripMenuItem";
            this.cavebotToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.cavebotToolStripMenuItem.Text = "Cavebot";
            this.cavebotToolStripMenuItem.Click += new System.EventHandler(this.CavebotToolStripMenuItem_Click);
            // 
            // targetToolStripMenuItem
            // 
            this.targetToolStripMenuItem.Name = "targetToolStripMenuItem";
            this.targetToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.targetToolStripMenuItem.Text = "Target";
            // 
            // lootToolStripMenuItem
            // 
            this.lootToolStripMenuItem.Name = "lootToolStripMenuItem";
            this.lootToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.lootToolStripMenuItem.Text = "Loot";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.cbFollowMonster);
            this.groupBox1.Controls.Add(this.comboBoxSdKey);
            this.groupBox1.Controls.Add(this.cbAttackSd);
            this.groupBox1.Controls.Add(this.cbTarget);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 213);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Target";
            // 
            // cbFollowMonster
            // 
            this.cbFollowMonster.AutoSize = true;
            this.cbFollowMonster.Location = new System.Drawing.Point(17, 101);
            this.cbFollowMonster.Name = "cbFollowMonster";
            this.cbFollowMonster.Size = new System.Drawing.Size(97, 17);
            this.cbFollowMonster.TabIndex = 29;
            this.cbFollowMonster.Text = "Follow Monster";
            this.cbFollowMonster.UseVisualStyleBackColor = true;
            // 
            // comboBoxSdKey
            // 
            this.comboBoxSdKey.FormattingEnabled = true;
            this.comboBoxSdKey.Location = new System.Drawing.Point(98, 65);
            this.comboBoxSdKey.Name = "comboBoxSdKey";
            this.comboBoxSdKey.Size = new System.Drawing.Size(52, 21);
            this.comboBoxSdKey.TabIndex = 28;
            // 
            // cbAttackSd
            // 
            this.cbAttackSd.AutoSize = true;
            this.cbAttackSd.Location = new System.Drawing.Point(17, 65);
            this.cbAttackSd.Name = "cbAttackSd";
            this.cbAttackSd.Size = new System.Drawing.Size(75, 17);
            this.cbAttackSd.TabIndex = 27;
            this.cbAttackSd.Text = "Attack SD";
            this.cbAttackSd.UseVisualStyleBackColor = true;
            // 
            // cbTarget
            // 
            this.cbTarget.AutoSize = true;
            this.cbTarget.Location = new System.Drawing.Point(17, 28);
            this.cbTarget.Name = "cbTarget";
            this.cbTarget.Size = new System.Drawing.Size(57, 17);
            this.cbTarget.TabIndex = 25;
            this.cbTarget.Text = "Target";
            this.cbTarget.UseVisualStyleBackColor = true;
            this.cbTarget.CheckedChanged += new System.EventHandler(this.CbTarget_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 136);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(111, 17);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "Attack Area Rune";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(134, 132);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(52, 21);
            this.comboBox1.TabIndex = 31;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 344);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip2;
        public System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem healerToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cavebotToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem targetToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem lootToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.CheckBox cbFollowMonster;
        private System.Windows.Forms.ComboBox comboBoxSdKey;
        public System.Windows.Forms.CheckBox cbAttackSd;
        public System.Windows.Forms.CheckBox cbTarget;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.CheckBox checkBox1;
    }
}