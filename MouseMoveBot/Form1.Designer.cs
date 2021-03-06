﻿using System.Windows.Forms;

namespace MouseMoveBot
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.healerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cavebotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkAttackAreaRune = new System.Windows.Forms.CheckBox();
            this.checkMaximized = new System.Windows.Forms.CheckBox();
            this.checkAttackSpell = new System.Windows.Forms.CheckBox();
            this.cbFollowMonster = new System.Windows.Forms.CheckBox();
            this.comboBoxManaKey = new System.Windows.Forms.ComboBox();
            this.checkAttackMissileRune = new System.Windows.Forms.CheckBox();
            this.cbHealerMana = new System.Windows.Forms.CheckBox();
            this.comboBoxLifeKey = new System.Windows.Forms.ComboBox();
            this.cbLooter = new System.Windows.Forms.CheckBox();
            this.cbTarget = new System.Windows.Forms.CheckBox();
            this.cbTrainer = new System.Windows.Forms.CheckBox();
            this.cbHealerLife = new System.Windows.Forms.CheckBox();
            this.cbCavebot = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textboxMinHealth = new System.Windows.Forms.TextBox();
            this.textboxMidHealth = new System.Windows.Forms.TextBox();
            this.textboxMaxHealth = new System.Windows.Forms.TextBox();
            this.checkHungry = new System.Windows.Forms.CheckBox();
            this.checkPoisoned = new System.Windows.Forms.CheckBox();
            this.checkParalyze = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.capTextBox = new System.Windows.Forms.TextBox();
            this.checkUseEnergyRing = new System.Windows.Forms.CheckBox();
            this.trainerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(42, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(73, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(42, 20);
            this.textBox2.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Position X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Position Y";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(72, 94);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(43, 20);
            this.textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(73, 120);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(42, 20);
            this.textBox4.TabIndex = 5;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(73, 146);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(42, 20);
            this.textBox5.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(49, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "R";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.LimeGreen;
            this.label4.Location = new System.Drawing.Point(49, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "G";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(49, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "B";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(132, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 133);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(16, 186);
            this.trackBar1.Maximum = 30;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(234, 45);
            this.trackBar1.SmallChange = 2;
            this.trackBar1.TabIndex = 11;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.healerToolStripMenuItem,
            this.cavebotToolStripMenuItem,
            this.targetToolStripMenuItem,
            this.lootToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.trainerToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(571, 24);
            this.menuStrip2.TabIndex = 14;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
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
            this.targetToolStripMenuItem.Click += new System.EventHandler(this.TargetToolStripMenuItem_Click);
            // 
            // lootToolStripMenuItem
            // 
            this.lootToolStripMenuItem.Name = "lootToolStripMenuItem";
            this.lootToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.lootToolStripMenuItem.Text = "Loot";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.FileToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkAttackAreaRune);
            this.panel1.Controls.Add(this.checkMaximized);
            this.panel1.Controls.Add(this.checkAttackSpell);
            this.panel1.Controls.Add(this.cbFollowMonster);
            this.panel1.Controls.Add(this.comboBoxManaKey);
            this.panel1.Controls.Add(this.checkAttackMissileRune);
            this.panel1.Controls.Add(this.cbHealerMana);
            this.panel1.Controls.Add(this.comboBoxLifeKey);
            this.panel1.Controls.Add(this.cbLooter);
            this.panel1.Controls.Add(this.cbTarget);
            this.panel1.Controls.Add(this.cbHealerLife);
            this.panel1.Controls.Add(this.cbCavebot);
            this.panel1.Location = new System.Drawing.Point(274, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 226);
            this.panel1.TabIndex = 15;
            // 
            // checkAttackAreaRune
            // 
            this.checkAttackAreaRune.AutoSize = true;
            this.checkAttackAreaRune.Location = new System.Drawing.Point(152, 167);
            this.checkAttackAreaRune.Name = "checkAttackAreaRune";
            this.checkAttackAreaRune.Size = new System.Drawing.Size(111, 17);
            this.checkAttackAreaRune.TabIndex = 31;
            this.checkAttackAreaRune.Text = "Attack Area Rune";
            this.checkAttackAreaRune.UseVisualStyleBackColor = true;
            // 
            // checkMaximized
            // 
            this.checkMaximized.AutoSize = true;
            this.checkMaximized.Location = new System.Drawing.Point(27, 203);
            this.checkMaximized.Name = "checkMaximized";
            this.checkMaximized.Size = new System.Drawing.Size(111, 17);
            this.checkMaximized.TabIndex = 25;
            this.checkMaximized.Text = "Always Maximized";
            this.checkMaximized.UseVisualStyleBackColor = true;
            // 
            // checkAttackSpell
            // 
            this.checkAttackSpell.AutoSize = true;
            this.checkAttackSpell.Location = new System.Drawing.Point(152, 90);
            this.checkAttackSpell.Name = "checkAttackSpell";
            this.checkAttackSpell.Size = new System.Drawing.Size(115, 17);
            this.checkAttackSpell.TabIndex = 35;
            this.checkAttackSpell.Text = "Attack Spell Magic";
            this.checkAttackSpell.UseVisualStyleBackColor = true;
            // 
            // cbFollowMonster
            // 
            this.cbFollowMonster.AutoSize = true;
            this.cbFollowMonster.Location = new System.Drawing.Point(152, 203);
            this.cbFollowMonster.Name = "cbFollowMonster";
            this.cbFollowMonster.Size = new System.Drawing.Size(97, 17);
            this.cbFollowMonster.TabIndex = 24;
            this.cbFollowMonster.Text = "Follow Monster";
            this.cbFollowMonster.UseVisualStyleBackColor = true;
            // 
            // comboBoxManaKey
            // 
            this.comboBoxManaKey.FormattingEnabled = true;
            this.comboBoxManaKey.Location = new System.Drawing.Point(121, 50);
            this.comboBoxManaKey.Name = "comboBoxManaKey";
            this.comboBoxManaKey.Size = new System.Drawing.Size(121, 21);
            this.comboBoxManaKey.TabIndex = 21;
            this.comboBoxManaKey.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged_1);
            // 
            // checkAttackMissileRune
            // 
            this.checkAttackMissileRune.AutoSize = true;
            this.checkAttackMissileRune.Location = new System.Drawing.Point(152, 128);
            this.checkAttackMissileRune.Name = "checkAttackMissileRune";
            this.checkAttackMissileRune.Size = new System.Drawing.Size(120, 17);
            this.checkAttackMissileRune.TabIndex = 33;
            this.checkAttackMissileRune.Text = "Attack Missile Rune";
            this.checkAttackMissileRune.UseVisualStyleBackColor = true;
            // 
            // cbHealerMana
            // 
            this.cbHealerMana.AutoSize = true;
            this.cbHealerMana.Location = new System.Drawing.Point(27, 50);
            this.cbHealerMana.Name = "cbHealerMana";
            this.cbHealerMana.Size = new System.Drawing.Size(53, 17);
            this.cbHealerMana.TabIndex = 20;
            this.cbHealerMana.Text = "Mana";
            this.cbHealerMana.UseVisualStyleBackColor = true;
            // 
            // comboBoxLifeKey
            // 
            this.comboBoxLifeKey.FormattingEnabled = true;
            this.comboBoxLifeKey.Location = new System.Drawing.Point(121, 14);
            this.comboBoxLifeKey.Name = "comboBoxLifeKey";
            this.comboBoxLifeKey.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLifeKey.TabIndex = 19;
            this.comboBoxLifeKey.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // cbLooter
            // 
            this.cbLooter.AutoSize = true;
            this.cbLooter.Location = new System.Drawing.Point(27, 167);
            this.cbLooter.Name = "cbLooter";
            this.cbLooter.Size = new System.Drawing.Size(47, 17);
            this.cbLooter.TabIndex = 18;
            this.cbLooter.Text = "Loot";
            this.cbLooter.UseVisualStyleBackColor = true;
            // 
            // cbTarget
            // 
            this.cbTarget.AutoSize = true;
            this.cbTarget.Location = new System.Drawing.Point(27, 128);
            this.cbTarget.Name = "cbTarget";
            this.cbTarget.Size = new System.Drawing.Size(57, 17);
            this.cbTarget.TabIndex = 17;
            this.cbTarget.Text = "Target";
            this.cbTarget.UseVisualStyleBackColor = true;
            this.cbTarget.CheckedChanged += new System.EventHandler(this.cbTarget_CheckedChanged);
            // 
            // cbHealerLife
            // 
            this.cbHealerLife.AutoSize = true;
            this.cbHealerLife.Location = new System.Drawing.Point(27, 14);
            this.cbHealerLife.Name = "cbHealerLife";
            this.cbHealerLife.Size = new System.Drawing.Size(57, 17);
            this.cbHealerLife.TabIndex = 16;
            this.cbHealerLife.Text = "Healer";
            this.cbHealerLife.UseVisualStyleBackColor = true;
            // 
            // cbCavebot
            // 
            this.cbCavebot.AutoSize = true;
            this.cbCavebot.Location = new System.Drawing.Point(27, 89);
            this.cbCavebot.Name = "cbCavebot";
            this.cbCavebot.Size = new System.Drawing.Size(66, 17);
            this.cbCavebot.TabIndex = 0;
            this.cbCavebot.Text = "Cavebot";
            this.cbCavebot.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(132, 236);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Scan";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // textboxMinHealth
            // 
            this.textboxMinHealth.Location = new System.Drawing.Point(0, 0);
            this.textboxMinHealth.Name = "textboxMinHealth";
            this.textboxMinHealth.Size = new System.Drawing.Size(100, 20);
            this.textboxMinHealth.TabIndex = 19;
            this.textboxMinHealth.Visible = false;
            // 
            // textboxMidHealth
            // 
            this.textboxMidHealth.Location = new System.Drawing.Point(0, 0);
            this.textboxMidHealth.Name = "textboxMidHealth";
            this.textboxMidHealth.Size = new System.Drawing.Size(100, 20);
            this.textboxMidHealth.TabIndex = 20;
            this.textboxMidHealth.Visible = false;
            // 
            // textboxMaxHealth
            // 
            this.textboxMaxHealth.Location = new System.Drawing.Point(0, 0);
            this.textboxMaxHealth.Name = "textboxMaxHealth";
            this.textboxMaxHealth.Size = new System.Drawing.Size(100, 20);
            this.textboxMaxHealth.TabIndex = 21;
            this.textboxMaxHealth.Visible = false;
            // 
            // checkHungry
            // 
            this.checkHungry.AutoSize = true;
            this.checkHungry.Location = new System.Drawing.Point(301, 311);
            this.checkHungry.Name = "checkHungry";
            this.checkHungry.Size = new System.Drawing.Size(69, 17);
            this.checkHungry.TabIndex = 41;
            this.checkHungry.Text = "Eat Food";
            this.checkHungry.UseVisualStyleBackColor = true;
            // 
            // checkPoisoned
            // 
            this.checkPoisoned.AutoSize = true;
            this.checkPoisoned.Location = new System.Drawing.Point(301, 275);
            this.checkPoisoned.Name = "checkPoisoned";
            this.checkPoisoned.Size = new System.Drawing.Size(83, 17);
            this.checkPoisoned.TabIndex = 40;
            this.checkPoisoned.Text = "Cure Poison";
            this.checkPoisoned.UseVisualStyleBackColor = true;
            // 
            // checkParalyze
            // 
            this.checkParalyze.AutoSize = true;
            this.checkParalyze.Location = new System.Drawing.Point(426, 275);
            this.checkParalyze.Name = "checkParalyze";
            this.checkParalyze.Size = new System.Drawing.Size(91, 17);
            this.checkParalyze.TabIndex = 43;
            this.checkParalyze.Text = "Cure Paralyze";
            this.checkParalyze.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Cap";
            // 
            // capTextBox
            // 
            this.capTextBox.Location = new System.Drawing.Point(52, 308);
            this.capTextBox.Name = "capTextBox";
            this.capTextBox.Size = new System.Drawing.Size(100, 20);
            this.capTextBox.TabIndex = 18;
            // 
            // checkUseEnergyRing
            // 
            this.checkUseEnergyRing.AutoSize = true;
            this.checkUseEnergyRing.Location = new System.Drawing.Point(426, 311);
            this.checkUseEnergyRing.Name = "checkUseEnergyRing";
            this.checkUseEnergyRing.Size = new System.Drawing.Size(103, 17);
            this.checkUseEnergyRing.TabIndex = 44;
            this.checkUseEnergyRing.Text = "Use EnergyRing";
            this.checkUseEnergyRing.UseVisualStyleBackColor = true;
            // 
            // trainerToolStripMenuItem
            // 
            this.trainerToolStripMenuItem.Name = "trainerToolStripMenuItem";
            this.trainerToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.trainerToolStripMenuItem.Text = "Trainer";
            this.trainerToolStripMenuItem.Click += new System.EventHandler(this.trainerToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 340);
            this.Controls.Add(this.checkUseEnergyRing);
            this.Controls.Add(this.checkParalyze);
            this.Controls.Add(this.checkHungry);
            this.Controls.Add(this.checkPoisoned);
            this.Controls.Add(this.capTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.textboxMinHealth);
            this.Controls.Add(this.textboxMidHealth);
            this.Controls.Add(this.textboxMaxHealth);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public TextBox textBox1;
        public TextBox textBox2;
        public Timer timer1;
        public Label label1;
        public Label label2;
        public TextBox textBox3;
        public TextBox textBox4;
        public TextBox textBox5;
        public Label label3;
        public Label label4;
        public Label label5;
        public PictureBox pictureBox1;
        public TrackBar trackBar1;
        public Button button1;
        public MenuStrip menuStrip2;
        public ToolStripMenuItem homeToolStripMenuItem;
        public ToolStripMenuItem healerToolStripMenuItem;
        public ToolStripMenuItem cavebotToolStripMenuItem;
        public ToolStripMenuItem targetToolStripMenuItem;
        public ToolStripMenuItem lootToolStripMenuItem;
        public Panel panel1;
        public CheckBox cbLooter;
        public CheckBox cbTarget;
        public CheckBox cbHealerLife;
        public CheckBox cbCavebot;
        public CheckBox cbHealerMana;
        public CheckBox cbTrainer;
        private Button button2;
        public ComboBox comboBoxLifeKey;
        public ComboBox comboBoxManaKey;
        public CheckBox cbFollowMonster;
        private CheckBox checkMaximized;
        public TextBox textboxMinHealth;
        public TextBox textboxMidHealth;
        public TextBox textboxMaxHealth;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        public CheckBox checkAttackSpell;
        public CheckBox checkAttackMissileRune;
        public CheckBox checkAttackAreaRune;
        public CheckBox checkHungry;
        public CheckBox checkPoisoned;
        public CheckBox checkParalyze;
        private Label label6;
        private TextBox capTextBox;
        public CheckBox checkUseEnergyRing;
        private ToolStripMenuItem trainerToolStripMenuItem;
    }
}

