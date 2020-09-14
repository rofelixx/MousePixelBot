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
            this.cbAttackSpell = new System.Windows.Forms.ComboBox();
            this.checkAttackSpell = new System.Windows.Forms.CheckBox();
            this.cbAttackArea = new System.Windows.Forms.ComboBox();
            this.checkAttackAreaRune = new System.Windows.Forms.CheckBox();
            this.cbFollowMonster = new System.Windows.Forms.CheckBox();
            this.cbAttackMissile = new System.Windows.Forms.ComboBox();
            this.checkAttackMissileRune = new System.Windows.Forms.CheckBox();
            this.cbTarget = new System.Windows.Forms.CheckBox();
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
            this.targetToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
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
            this.groupBox1.Controls.Add(this.cbAttackSpell);
            this.groupBox1.Controls.Add(this.checkAttackSpell);
            this.groupBox1.Controls.Add(this.cbAttackArea);
            this.groupBox1.Controls.Add(this.checkAttackAreaRune);
            this.groupBox1.Controls.Add(this.cbFollowMonster);
            this.groupBox1.Controls.Add(this.cbAttackMissile);
            this.groupBox1.Controls.Add(this.checkAttackMissileRune);
            this.groupBox1.Controls.Add(this.cbTarget);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 213);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Target";
            // 
            // cbAttackSpell
            // 
            this.cbAttackSpell.FormattingEnabled = true;
            this.cbAttackSpell.Location = new System.Drawing.Point(134, 100);
            this.cbAttackSpell.Name = "cbAttackSpell";
            this.cbAttackSpell.Size = new System.Drawing.Size(52, 21);
            this.cbAttackSpell.TabIndex = 33;
            this.cbAttackSpell.SelectedIndexChanged += new System.EventHandler(this.CbAttackSpell_SelectedIndexChanged);
            // 
            // checkAttackSpell
            // 
            this.checkAttackSpell.AutoSize = true;
            this.checkAttackSpell.Location = new System.Drawing.Point(17, 102);
            this.checkAttackSpell.Name = "checkAttackSpell";
            this.checkAttackSpell.Size = new System.Drawing.Size(115, 17);
            this.checkAttackSpell.TabIndex = 32;
            this.checkAttackSpell.Text = "Attack Spell Magic";
            this.checkAttackSpell.UseVisualStyleBackColor = true;
            this.checkAttackSpell.CheckedChanged += new System.EventHandler(this.CheckAttackSpell_CheckedChanged);
            // 
            // cbAttackArea
            // 
            this.cbAttackArea.FormattingEnabled = true;
            this.cbAttackArea.Location = new System.Drawing.Point(134, 175);
            this.cbAttackArea.Name = "cbAttackArea";
            this.cbAttackArea.Size = new System.Drawing.Size(52, 21);
            this.cbAttackArea.TabIndex = 31;
            this.cbAttackArea.SelectedIndexChanged += new System.EventHandler(this.CbAttackArea_SelectedIndexChanged);
            // 
            // checkAttackAreaRune
            // 
            this.checkAttackAreaRune.AutoSize = true;
            this.checkAttackAreaRune.Location = new System.Drawing.Point(17, 179);
            this.checkAttackAreaRune.Name = "checkAttackAreaRune";
            this.checkAttackAreaRune.Size = new System.Drawing.Size(111, 17);
            this.checkAttackAreaRune.TabIndex = 30;
            this.checkAttackAreaRune.Text = "Attack Area Rune";
            this.checkAttackAreaRune.UseVisualStyleBackColor = true;
            this.checkAttackAreaRune.CheckedChanged += new System.EventHandler(this.CheckAreaRune_CheckedChanged);
            // 
            // cbFollowMonster
            // 
            this.cbFollowMonster.AutoSize = true;
            this.cbFollowMonster.Location = new System.Drawing.Point(17, 64);
            this.cbFollowMonster.Name = "cbFollowMonster";
            this.cbFollowMonster.Size = new System.Drawing.Size(97, 17);
            this.cbFollowMonster.TabIndex = 29;
            this.cbFollowMonster.Text = "Follow Monster";
            this.cbFollowMonster.UseVisualStyleBackColor = true;
            this.cbFollowMonster.CheckedChanged += new System.EventHandler(this.cbFollowMonster_CheckedChanged);
            // 
            // cbAttackMissile
            // 
            this.cbAttackMissile.FormattingEnabled = true;
            this.cbAttackMissile.Location = new System.Drawing.Point(134, 138);
            this.cbAttackMissile.Name = "cbAttackMissile";
            this.cbAttackMissile.Size = new System.Drawing.Size(52, 21);
            this.cbAttackMissile.TabIndex = 28;
            this.cbAttackMissile.SelectedIndexChanged += new System.EventHandler(this.CbAttackMissile_SelectedIndexChanged);
            // 
            // checkAttackMissileRune
            // 
            this.checkAttackMissileRune.AutoSize = true;
            this.checkAttackMissileRune.Location = new System.Drawing.Point(17, 140);
            this.checkAttackMissileRune.Name = "checkAttackMissileRune";
            this.checkAttackMissileRune.Size = new System.Drawing.Size(120, 17);
            this.checkAttackMissileRune.TabIndex = 27;
            this.checkAttackMissileRune.Text = "Attack Missile Rune";
            this.checkAttackMissileRune.UseVisualStyleBackColor = true;
            this.checkAttackMissileRune.CheckedChanged += new System.EventHandler(this.CbAttackMissileRune_CheckedChanged);
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
        private System.Windows.Forms.ComboBox cbAttackMissile;
        public System.Windows.Forms.CheckBox checkAttackMissileRune;
        public System.Windows.Forms.CheckBox cbTarget;
        private System.Windows.Forms.ComboBox cbAttackArea;
        public System.Windows.Forms.CheckBox checkAttackAreaRune;
        private System.Windows.Forms.ComboBox cbAttackSpell;
        public System.Windows.Forms.CheckBox checkAttackSpell;
    }
}