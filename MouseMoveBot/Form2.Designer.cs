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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.healerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cavebotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxMana = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbManaHealer = new System.Windows.Forms.CheckBox();
            this.comboBoxHealthMax = new System.Windows.Forms.ComboBox();
            this.comboBoxHealthMid = new System.Windows.Forms.ComboBox();
            this.comboBoxHealthMin = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbHealthHealer = new System.Windows.Forms.CheckBox();
            this.checkPoisoned = new System.Windows.Forms.CheckBox();
            this.cbCurePoison = new System.Windows.Forms.ComboBox();
            this.cbEatFood = new System.Windows.Forms.ComboBox();
            this.checkHungry = new System.Windows.Forms.CheckBox();
            this.menuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.cavebotToolStripMenuItem.Click += new System.EventHandler(this.CavebotToolStripMenuItem_Click);
            // 
            // targetToolStripMenuItem
            // 
            this.targetToolStripMenuItem.Name = "targetToolStripMenuItem";
            this.targetToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.targetToolStripMenuItem.Text = "Target";
            this.targetToolStripMenuItem.Click += new System.EventHandler(this.TargetToolStripMenuItem_Click);
            // 
            // lootToolStripMenuItem
            // 
            this.lootToolStripMenuItem.Name = "lootToolStripMenuItem";
            this.lootToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.lootToolStripMenuItem.Text = "Loot";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEatFood);
            this.groupBox1.Controls.Add(this.checkHungry);
            this.groupBox1.Controls.Add(this.cbCurePoison);
            this.groupBox1.Controls.Add(this.checkPoisoned);
            this.groupBox1.Controls.Add(this.comboBoxMana);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbManaHealer);
            this.groupBox1.Controls.Add(this.comboBoxHealthMax);
            this.groupBox1.Controls.Add(this.comboBoxHealthMid);
            this.groupBox1.Controls.Add(this.comboBoxHealthMin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbHealthHealer);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 280);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Healer";
            // 
            // comboBoxMana
            // 
            this.comboBoxMana.FormattingEnabled = true;
            this.comboBoxMana.Location = new System.Drawing.Point(15, 237);
            this.comboBoxMana.Name = "comboBoxMana";
            this.comboBoxMana.Size = new System.Drawing.Size(95, 21);
            this.comboBoxMana.TabIndex = 36;
            this.comboBoxMana.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMana_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Mana <= 50 %";
            // 
            // cbManaHealer
            // 
            this.cbManaHealer.AutoSize = true;
            this.cbManaHealer.Location = new System.Drawing.Point(15, 170);
            this.cbManaHealer.Name = "cbManaHealer";
            this.cbManaHealer.Size = new System.Drawing.Size(53, 17);
            this.cbManaHealer.TabIndex = 34;
            this.cbManaHealer.Text = "Mana";
            this.cbManaHealer.UseVisualStyleBackColor = true;
            this.cbManaHealer.CheckedChanged += new System.EventHandler(this.CbManaHealer_CheckedChanged);
            // 
            // comboBoxHealthMax
            // 
            this.comboBoxHealthMax.FormattingEnabled = true;
            this.comboBoxHealthMax.Location = new System.Drawing.Point(347, 109);
            this.comboBoxHealthMax.Name = "comboBoxHealthMax";
            this.comboBoxHealthMax.Size = new System.Drawing.Size(95, 21);
            this.comboBoxHealthMax.TabIndex = 33;
            this.comboBoxHealthMax.SelectedIndexChanged += new System.EventHandler(this.ComboBoxHealthMax_SelectedIndexChanged);
            // 
            // comboBoxHealthMid
            // 
            this.comboBoxHealthMid.FormattingEnabled = true;
            this.comboBoxHealthMid.Location = new System.Drawing.Point(175, 109);
            this.comboBoxHealthMid.Name = "comboBoxHealthMid";
            this.comboBoxHealthMid.Size = new System.Drawing.Size(95, 21);
            this.comboBoxHealthMid.TabIndex = 32;
            this.comboBoxHealthMid.SelectedIndexChanged += new System.EventHandler(this.ComboBoxHealthMid_SelectedIndexChanged);
            // 
            // comboBoxHealthMin
            // 
            this.comboBoxHealthMin.FormattingEnabled = true;
            this.comboBoxHealthMin.Location = new System.Drawing.Point(15, 109);
            this.comboBoxHealthMin.Name = "comboBoxHealthMin";
            this.comboBoxHealthMin.Size = new System.Drawing.Size(95, 21);
            this.comboBoxHealthMin.TabIndex = 31;
            this.comboBoxHealthMin.SelectedIndexChanged += new System.EventHandler(this.ComboBoxHealthMin_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Health <= 85 %";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Health <= 65 %";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Health <= 30 %";
            // 
            // cbHealthHealer
            // 
            this.cbHealthHealer.AutoSize = true;
            this.cbHealthHealer.Location = new System.Drawing.Point(15, 43);
            this.cbHealthHealer.Name = "cbHealthHealer";
            this.cbHealthHealer.Size = new System.Drawing.Size(57, 17);
            this.cbHealthHealer.TabIndex = 27;
            this.cbHealthHealer.Text = "Health";
            this.cbHealthHealer.UseVisualStyleBackColor = true;
            this.cbHealthHealer.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // checkPoisoned
            // 
            this.checkPoisoned.AutoSize = true;
            this.checkPoisoned.Location = new System.Drawing.Point(347, 180);
            this.checkPoisoned.Name = "checkPoisoned";
            this.checkPoisoned.Size = new System.Drawing.Size(83, 17);
            this.checkPoisoned.TabIndex = 37;
            this.checkPoisoned.Text = "Cure Poison";
            this.checkPoisoned.UseVisualStyleBackColor = true;
            this.checkPoisoned.CheckedChanged += new System.EventHandler(this.checkPoisoned_CheckedChanged);
            // 
            // cbCurePoison
            // 
            this.cbCurePoison.FormattingEnabled = true;
            this.cbCurePoison.Location = new System.Drawing.Point(436, 180);
            this.cbCurePoison.Name = "cbCurePoison";
            this.cbCurePoison.Size = new System.Drawing.Size(53, 21);
            this.cbCurePoison.TabIndex = 38;
            this.cbCurePoison.SelectedIndexChanged += new System.EventHandler(this.cbCurePoison_SelectedIndexChanged);
            // 
            // cbEatFood
            // 
            this.cbEatFood.FormattingEnabled = true;
            this.cbEatFood.Location = new System.Drawing.Point(436, 216);
            this.cbEatFood.Name = "cbEatFood";
            this.cbEatFood.Size = new System.Drawing.Size(53, 21);
            this.cbEatFood.TabIndex = 40;
            this.cbEatFood.SelectedIndexChanged += new System.EventHandler(this.cbEatFood_SelectedIndexChanged);
            // 
            // checkHungry
            // 
            this.checkHungry.AutoSize = true;
            this.checkHungry.Location = new System.Drawing.Point(347, 216);
            this.checkHungry.Name = "checkHungry";
            this.checkHungry.Size = new System.Drawing.Size(69, 17);
            this.checkHungry.TabIndex = 39;
            this.checkHungry.Text = "Eat Food";
            this.checkHungry.UseVisualStyleBackColor = true;
            this.checkHungry.CheckedChanged += new System.EventHandler(this.checkHungry_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 340);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label label1;
        public MenuStrip menuStrip2;
        public ToolStripMenuItem homeToolStripMenuItem;
        public ToolStripMenuItem healerToolStripMenuItem;
        public ToolStripMenuItem cavebotToolStripMenuItem;
        public ToolStripMenuItem targetToolStripMenuItem;
        public ToolStripMenuItem lootToolStripMenuItem;
        private GroupBox groupBox1;
        public ComboBox comboBoxMana;
        private Label label7;
        public CheckBox cbManaHealer;
        private ComboBox comboBoxHealthMax;
        private ComboBox comboBoxHealthMid;
        private ComboBox comboBoxHealthMin;
        private Label label4;
        private Label label3;
        private Label label2;
        public CheckBox cbHealthHealer;
        public CheckBox checkPoisoned;
        private ComboBox cbCurePoison;
        private ComboBox cbEatFood;
        public CheckBox checkHungry;
    }
}

