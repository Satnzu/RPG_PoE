namespace RPG_PoE
{
    partial class TheGame
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
            this.lbname = new System.Windows.Forms.Label();
            this.lblvl = new System.Windows.Forms.Label();
            this.lbdmg = new System.Windows.Forms.Label();
            this.lbdef = new System.Windows.Forms.Label();
            this.lbspeed = new System.Windows.Forms.Label();
            this.playertimer = new System.Windows.Forms.Timer(this.components);
            this.monstertimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LabHp = new System.Windows.Forms.Label();
            this.btninventory = new System.Windows.Forms.Button();
            this.Pause = new System.Windows.Forms.Button();
            this.BTsave = new System.Windows.Forms.Button();
            this.bosstimer = new System.Windows.Forms.Timer(this.components);
            this.inventorylabel = new System.Windows.Forms.Label();
            this.btnpassive = new System.Windows.Forms.Button();
            this.Lexp = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbname
            // 
            this.lbname.AutoSize = true;
            this.lbname.Location = new System.Drawing.Point(948, 42);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(19, 13);
            this.lbname.TabIndex = 1;
            this.lbname.Text = "kk";
            // 
            // lblvl
            // 
            this.lblvl.AutoSize = true;
            this.lblvl.Location = new System.Drawing.Point(948, 69);
            this.lblvl.Name = "lblvl";
            this.lblvl.Size = new System.Drawing.Size(35, 13);
            this.lblvl.TabIndex = 2;
            this.lblvl.Text = "label1";
            // 
            // lbdmg
            // 
            this.lbdmg.AutoSize = true;
            this.lbdmg.Location = new System.Drawing.Point(948, 106);
            this.lbdmg.Name = "lbdmg";
            this.lbdmg.Size = new System.Drawing.Size(35, 13);
            this.lbdmg.TabIndex = 3;
            this.lbdmg.Text = "label1";
            // 
            // lbdef
            // 
            this.lbdef.AutoSize = true;
            this.lbdef.Location = new System.Drawing.Point(1129, 69);
            this.lbdef.Name = "lbdef";
            this.lbdef.Size = new System.Drawing.Size(35, 13);
            this.lbdef.TabIndex = 4;
            this.lbdef.Text = "label1";
            // 
            // lbspeed
            // 
            this.lbspeed.AutoSize = true;
            this.lbspeed.Location = new System.Drawing.Point(1129, 106);
            this.lbspeed.Name = "lbspeed";
            this.lbspeed.Size = new System.Drawing.Size(35, 13);
            this.lbspeed.TabIndex = 5;
            this.lbspeed.Text = "label1";
            // 
            // playertimer
            // 
            this.playertimer.Interval = 1000;
            this.playertimer.Tick += new System.EventHandler(this.playertimer_Tick);
            // 
            // monstertimer
            // 
            this.monstertimer.Interval = 1000;
            this.monstertimer.Tick += new System.EventHandler(this.monstertimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1278, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // LabHp
            // 
            this.LabHp.AutoSize = true;
            this.LabHp.Location = new System.Drawing.Point(948, 145);
            this.LabHp.Name = "LabHp";
            this.LabHp.Size = new System.Drawing.Size(35, 13);
            this.LabHp.TabIndex = 7;
            this.LabHp.Text = "label1";
            // 
            // btninventory
            // 
            this.btninventory.Location = new System.Drawing.Point(1004, 224);
            this.btninventory.Name = "btninventory";
            this.btninventory.Size = new System.Drawing.Size(117, 23);
            this.btninventory.TabIndex = 8;
            this.btninventory.Text = "Go to inventory";
            this.btninventory.UseVisualStyleBackColor = true;
            this.btninventory.Click += new System.EventHandler(this.btninventory_Click);
            // 
            // Pause
            // 
            this.Pause.Location = new System.Drawing.Point(1004, 195);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(117, 23);
            this.Pause.TabIndex = 9;
            this.Pause.Text = "Pause";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // BTsave
            // 
            this.BTsave.Location = new System.Drawing.Point(1004, 254);
            this.BTsave.Name = "BTsave";
            this.BTsave.Size = new System.Drawing.Size(117, 23);
            this.BTsave.TabIndex = 10;
            this.BTsave.Text = "Save";
            this.BTsave.UseVisualStyleBackColor = true;
            this.BTsave.Click += new System.EventHandler(this.BTsave_Click);
            // 
            // bosstimer
            // 
            this.bosstimer.Interval = 1000;
            this.bosstimer.Tick += new System.EventHandler(this.bosstimer_Tick);
            // 
            // inventorylabel
            // 
            this.inventorylabel.AutoSize = true;
            this.inventorylabel.Location = new System.Drawing.Point(1132, 145);
            this.inventorylabel.Name = "inventorylabel";
            this.inventorylabel.Size = new System.Drawing.Size(76, 13);
            this.inventorylabel.TabIndex = 12;
            this.inventorylabel.Text = "inventory 0/20";
            // 
            // btnpassive
            // 
            this.btnpassive.Location = new System.Drawing.Point(1004, 284);
            this.btnpassive.Name = "btnpassive";
            this.btnpassive.Size = new System.Drawing.Size(117, 23);
            this.btnpassive.TabIndex = 13;
            this.btnpassive.Text = "PassiveTree";
            this.btnpassive.UseVisualStyleBackColor = true;
            this.btnpassive.Click += new System.EventHandler(this.btnpassive_Click);
            // 
            // Lexp
            // 
            this.Lexp.AutoSize = true;
            this.Lexp.Location = new System.Drawing.Point(948, 167);
            this.Lexp.Name = "Lexp";
            this.Lexp.Size = new System.Drawing.Size(24, 13);
            this.Lexp.TabIndex = 14;
            this.Lexp.Text = "exp";
            // 
            // TheGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 954);
            this.Controls.Add(this.Lexp);
            this.Controls.Add(this.btnpassive);
            this.Controls.Add(this.inventorylabel);
            this.Controls.Add(this.BTsave);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.btninventory);
            this.Controls.Add(this.LabHp);
            this.Controls.Add(this.lbspeed);
            this.Controls.Add(this.lbdef);
            this.Controls.Add(this.lbdmg);
            this.Controls.Add(this.lblvl);
            this.Controls.Add(this.lbname);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TheGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TheGame";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TheGame_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TheGame_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbname;
        private System.Windows.Forms.Label lblvl;
        private System.Windows.Forms.Label lbdmg;
        private System.Windows.Forms.Label lbdef;
        private System.Windows.Forms.Label lbspeed;
        private System.Windows.Forms.Timer playertimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label LabHp;
        private System.Windows.Forms.Button btninventory;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Button BTsave;
        private System.Windows.Forms.Label inventorylabel;
        private System.Windows.Forms.Button btnpassive;
        private System.Windows.Forms.Label Lexp;
        public System.Windows.Forms.Timer monstertimer;
        public System.Windows.Forms.Timer bosstimer;
    }
}