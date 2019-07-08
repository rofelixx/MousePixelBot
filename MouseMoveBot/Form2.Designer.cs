using System.Windows.Forms;

namespace MouseMoveBot
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxHealthMax = new System.Windows.Forms.ComboBox();
            this.comboBoxHealthMid = new System.Windows.Forms.ComboBox();
            this.comboBoxHealthMin = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.healerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cavebotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxMana = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbManaHealer = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Healer";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxHealthMax);
            this.panel1.Controls.Add(this.comboBoxHealthMid);
            this.panel1.Controls.Add(this.comboBoxHealthMin);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Location = new System.Drawing.Point(15, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 145);
            this.panel1.TabIndex = 1;
            // 
            // comboBoxHealthMax
            // 
            this.comboBoxHealthMax.FormattingEnabled = true;
            this.comboBoxHealthMax.Location = new System.Drawing.Point(344, 78);
            this.comboBoxHealthMax.Name = "comboBoxHealthMax";
            this.comboBoxHealthMax.Size = new System.Drawing.Size(95, 21);
            this.comboBoxHealthMax.TabIndex = 26;
            this.comboBoxHealthMax.SelectedIndexChanged += new System.EventHandler(this.ComboBoxHealthMax_SelectedIndexChanged);
            // 
            // comboBoxHealthMid
            // 
            this.comboBoxHealthMid.FormattingEnabled = true;
            this.comboBoxHealthMid.Location = new System.Drawing.Point(172, 78);
            this.comboBoxHealthMid.Name = "comboBoxHealthMid";
            this.comboBoxHealthMid.Size = new System.Drawing.Size(95, 21);
            this.comboBoxHealthMid.TabIndex = 25;
            this.comboBoxHealthMid.SelectedIndexChanged += new System.EventHandler(this.ComboBoxHealthMid_SelectedIndexChanged);
            // 
            // comboBoxHealthMin
            // 
            this.comboBoxHealthMin.FormattingEnabled = true;
            this.comboBoxHealthMin.Location = new System.Drawing.Point(12, 78);
            this.comboBoxHealthMin.Name = "comboBoxHealthMin";
            this.comboBoxHealthMin.Size = new System.Drawing.Size(95, 21);
            this.comboBoxHealthMin.TabIndex = 24;
            this.comboBoxHealthMin.SelectedIndexChanged += new System.EventHandler(this.ComboBoxHealthMin_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Health <= 85 %";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Health <= 65 %";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Health <= 30 %";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(57, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Health";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
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
            this.menuStrip2.TabIndex = 15;
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
            // 
            // cavebotToolStripMenuItem
            // 
            this.cavebotToolStripMenuItem.Name = "cavebotToolStripMenuItem";
            this.cavebotToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.cavebotToolStripMenuItem.Text = "Cavebot";
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
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBoxMana);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbManaHealer);
            this.panel2.Location = new System.Drawing.Point(15, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 145);
            this.panel2.TabIndex = 27;
            // 
            // comboBox3
            // 
            this.comboBoxMana.FormattingEnabled = true;
            this.comboBoxMana.Location = new System.Drawing.Point(12, 78);
            this.comboBoxMana.Name = "comboBox3";
            this.comboBoxMana.Size = new System.Drawing.Size(95, 21);
            this.comboBoxMana.TabIndex = 24;
            this.comboBoxMana.SelectedIndexChanged += new System.EventHandler(this.ComboBox3_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Mana <= 50 %";
            // 
            // checkBox2
            // 
            this.cbManaHealer.AutoSize = true;
            this.cbManaHealer.Location = new System.Drawing.Point(12, 12);
            this.cbManaHealer.Name = "checkBox2";
            this.cbManaHealer.Size = new System.Drawing.Size(53, 17);
            this.cbManaHealer.TabIndex = 17;
            this.cbManaHealer.Text = "Mana";
            this.cbManaHealer.UseVisualStyleBackColor = true;
            this.cbManaHealer.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 340);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label label1;
        public Panel panel1;
        public CheckBox checkBox1;
        private Label label2;
        private Label label4;
        private Label label3;
        public MenuStrip menuStrip2;
        public ToolStripMenuItem homeToolStripMenuItem;
        public ToolStripMenuItem healerToolStripMenuItem;
        public ToolStripMenuItem cavebotToolStripMenuItem;
        public ToolStripMenuItem targetToolStripMenuItem;
        public ToolStripMenuItem lootToolStripMenuItem;
        private ComboBox comboBoxHealthMax;
        private ComboBox comboBoxHealthMid;
        private ComboBox comboBoxHealthMin;
        public Panel panel2;
        public ComboBox comboBoxMana;
        private Label label7;
        public CheckBox cbManaHealer;
    }
}

