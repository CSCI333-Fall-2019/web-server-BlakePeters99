namespace WebServer
{
    partial class WebServerPage
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
            this.Start = new System.Windows.Forms.Button();
            this.StopEnd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(61, 41);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(158, 45);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // StopEnd
            // 
            this.StopEnd.Location = new System.Drawing.Point(61, 140);
            this.StopEnd.Name = "StopEnd";
            this.StopEnd.Size = new System.Drawing.Size(158, 45);
            this.StopEnd.TabIndex = 1;
            this.StopEnd.Text = "Stop";
            this.StopEnd.UseVisualStyleBackColor = true;
            this.StopEnd.Click += new System.EventHandler(this.StopEnd_Click);
            // 
            // WebServerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.StopEnd);
            this.Controls.Add(this.Start);
            this.Name = "WebServerPage";
            this.Text = "WebServer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button StopEnd;
    }
}

