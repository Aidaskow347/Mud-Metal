namespace Mud_Metal
{
    partial class GameScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.healthP1 = new System.Windows.Forms.Label();
            this.healthP2 = new System.Windows.Forms.Label();
            this.power1 = new System.Windows.Forms.Label();
            this.power2 = new System.Windows.Forms.Label();
            this.fuel1 = new System.Windows.Forms.Label();
            this.fuel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 623);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(515, 157);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(882, 623);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(515, 157);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // healthP1
            // 
            this.healthP1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.healthP1.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthP1.Location = new System.Drawing.Point(16, 634);
            this.healthP1.Name = "healthP1";
            this.healthP1.Size = new System.Drawing.Size(113, 31);
            this.healthP1.TabIndex = 2;
            this.healthP1.Text = "Text";
            this.healthP1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // healthP2
            // 
            this.healthP2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.healthP2.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthP2.Location = new System.Drawing.Point(893, 634);
            this.healthP2.Name = "healthP2";
            this.healthP2.Size = new System.Drawing.Size(113, 31);
            this.healthP2.TabIndex = 3;
            this.healthP2.Text = "Health";
            this.healthP2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // power1
            // 
            this.power1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.power1.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.power1.Location = new System.Drawing.Point(385, 634);
            this.power1.Name = "power1";
            this.power1.Size = new System.Drawing.Size(116, 31);
            this.power1.TabIndex = 4;
            this.power1.Text = "Str:";
            this.power1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // power2
            // 
            this.power2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.power2.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.power2.Location = new System.Drawing.Point(1257, 634);
            this.power2.Name = "power2";
            this.power2.Size = new System.Drawing.Size(126, 31);
            this.power2.TabIndex = 5;
            this.power2.Text = "Str:";
            this.power2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fuel1
            // 
            this.fuel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.fuel1.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fuel1.Location = new System.Drawing.Point(266, 634);
            this.fuel1.Name = "fuel1";
            this.fuel1.Size = new System.Drawing.Size(113, 31);
            this.fuel1.TabIndex = 6;
            this.fuel1.Text = "Text";
            this.fuel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fuel2
            // 
            this.fuel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.fuel2.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fuel2.Location = new System.Drawing.Point(1138, 634);
            this.fuel2.Name = "fuel2";
            this.fuel2.Size = new System.Drawing.Size(113, 31);
            this.fuel2.TabIndex = 7;
            this.fuel2.Text = "Text";
            this.fuel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.fuel2);
            this.Controls.Add(this.fuel1);
            this.Controls.Add(this.power2);
            this.Controls.Add(this.power1);
            this.Controls.Add(this.healthP2);
            this.Controls.Add(this.healthP1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(1400, 800);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label healthP1;
        private System.Windows.Forms.Label healthP2;
        private System.Windows.Forms.Label power1;
        private System.Windows.Forms.Label power2;
        private System.Windows.Forms.Label fuel1;
        private System.Windows.Forms.Label fuel2;
    }
}
