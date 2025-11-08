namespace Wolf_Rabbit
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
            this.Start = new System.Windows.Forms.Button();
            this.World = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtTick = new System.Windows.Forms.TextBox();
            this.txtThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Start.Location = new System.Drawing.Point(787, 452);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(86, 43);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // World
            // 
            this.World.Location = new System.Drawing.Point(1, 4);
            this.World.Name = "World";
            this.World.Size = new System.Drawing.Size(872, 442);
            this.World.TabIndex = 1;
            this.World.Paint += new System.Windows.Forms.PaintEventHandler(this.World_Paint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(683, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Stop_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReset.Location = new System.Drawing.Point(575, 452);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(79, 43);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // txtTick
            // 
            this.txtTick.Location = new System.Drawing.Point(455, 462);
            this.txtTick.Name = "txtTick";
            this.txtTick.Size = new System.Drawing.Size(49, 22);
            this.txtTick.TabIndex = 4;
            this.txtTick.Text = "1000";
            // 
            // txtThoat
            // 
            this.txtThoat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtThoat.Location = new System.Drawing.Point(787, 536);
            this.txtThoat.Name = "txtThoat";
            this.txtThoat.Size = new System.Drawing.Size(79, 43);
            this.txtThoat.TabIndex = 5;
            this.txtThoat.Text = "Thoát";
            this.txtThoat.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 662);
            this.Controls.Add(this.txtThoat);
            this.Controls.Add(this.txtTick);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.World);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "World";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Panel World;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtTick;
        private System.Windows.Forms.Button txtThoat;
    }
}

