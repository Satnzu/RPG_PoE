namespace RPG_PoE
{
    partial class NewGame
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
            this.BtnNewPlayer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LBattack = new System.Windows.Forms.Label();
            this.LBdefence = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LBspeed = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LBres = new System.Windows.Forms.Label();
            this.PBplayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBplayer)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnNewPlayer
            // 
            this.BtnNewPlayer.Location = new System.Drawing.Point(51, 265);
            this.BtnNewPlayer.Name = "BtnNewPlayer";
            this.BtnNewPlayer.Size = new System.Drawing.Size(75, 23);
            this.BtnNewPlayer.TabIndex = 0;
            this.BtnNewPlayer.Text = "Create character";
            this.BtnNewPlayer.UseVisualStyleBackColor = true;
            this.BtnNewPlayer.Click += new System.EventHandler(this.BtnNewPlayer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // tbname
            // 
            this.tbname.Location = new System.Drawing.Point(77, 46);
            this.tbname.Name = "tbname";
            this.tbname.Size = new System.Drawing.Size(121, 20);
            this.tbname.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Class:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Warrior",
            "Rogue",
            "Wizard"});
            this.comboBox1.Location = new System.Drawing.Point(77, 86);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Attack Power:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Defence:";
            // 
            // LBattack
            // 
            this.LBattack.AutoSize = true;
            this.LBattack.Location = new System.Drawing.Point(113, 130);
            this.LBattack.Name = "LBattack";
            this.LBattack.Size = new System.Drawing.Size(13, 13);
            this.LBattack.TabIndex = 7;
            this.LBattack.Text = "0";
            // 
            // LBdefence
            // 
            this.LBdefence.AutoSize = true;
            this.LBdefence.Location = new System.Drawing.Point(113, 160);
            this.LBdefence.Name = "LBdefence";
            this.LBdefence.Size = new System.Drawing.Size(13, 13);
            this.LBdefence.TabIndex = 8;
            this.LBdefence.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Speed:";
            // 
            // LBspeed
            // 
            this.LBspeed.AutoSize = true;
            this.LBspeed.Location = new System.Drawing.Point(113, 192);
            this.LBspeed.Name = "LBspeed";
            this.LBspeed.Size = new System.Drawing.Size(13, 13);
            this.LBspeed.TabIndex = 10;
            this.LBspeed.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 222);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Resistance:";
            // 
            // LBres
            // 
            this.LBres.AutoSize = true;
            this.LBres.Location = new System.Drawing.Point(113, 222);
            this.LBres.Name = "LBres";
            this.LBres.Size = new System.Drawing.Size(13, 13);
            this.LBres.TabIndex = 12;
            this.LBres.Text = "0";
            // 
            // PBplayer
            // 
            this.PBplayer.Location = new System.Drawing.Point(270, 46);
            this.PBplayer.Name = "PBplayer";
            this.PBplayer.Size = new System.Drawing.Size(264, 242);
            this.PBplayer.TabIndex = 13;
            this.PBplayer.TabStop = false;
            // 
            // NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 330);
            this.Controls.Add(this.PBplayer);
            this.Controls.Add(this.LBres);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.LBspeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LBdefence);
            this.Controls.Add(this.LBattack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnNewPlayer);
            this.Name = "NewGame";
            this.Text = "NewGame";
            this.Load += new System.EventHandler(this.NewGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBplayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnNewPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LBattack;
        private System.Windows.Forms.Label LBdefence;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LBspeed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LBres;
        private System.Windows.Forms.PictureBox PBplayer;
    }
}