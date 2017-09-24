namespace DirectX_Renderer
{
    partial class Launcher
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
            this.overlay_launcher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // overlay_launcher
            // 
            this.overlay_launcher.Location = new System.Drawing.Point(12, 12);
            this.overlay_launcher.Name = "overlay_launcher";
            this.overlay_launcher.Size = new System.Drawing.Size(153, 45);
            this.overlay_launcher.TabIndex = 0;
            this.overlay_launcher.Text = "Overlay Screen SharpDX";
            this.overlay_launcher.UseVisualStyleBackColor = true;
            this.overlay_launcher.Click += new System.EventHandler(this.overlay_launcher_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 166);
            this.Controls.Add(this.overlay_launcher);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Launcher";
            this.ShowIcon = false;
            this.Text = "Launcher";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button overlay_launcher;
    }
}