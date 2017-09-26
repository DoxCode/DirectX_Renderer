namespace DirectX_Renderer.Screen_Stream
{
    partial class Screen_Stream
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
            this.stream_box = new System.Windows.Forms.PictureBox();
            this.btn_stream = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._average_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this._fps_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stream_box)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stream_box
            // 
            this.stream_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stream_box.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.stream_box.Location = new System.Drawing.Point(12, 12);
            this.stream_box.Name = "stream_box";
            this.stream_box.Size = new System.Drawing.Size(652, 336);
            this.stream_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.stream_box.TabIndex = 0;
            this.stream_box.TabStop = false;
            // 
            // btn_stream
            // 
            this.btn_stream.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_stream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stream.Location = new System.Drawing.Point(529, 354);
            this.btn_stream.Name = "btn_stream";
            this.btn_stream.Size = new System.Drawing.Size(135, 49);
            this.btn_stream.TabIndex = 1;
            this.btn_stream.Text = "Stream Desktop";
            this.btn_stream.UseVisualStyleBackColor = true;
            this.btn_stream.Click += new System.EventHandler(this.btn_stream_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Average:";
            // 
            // _average_label
            // 
            this._average_label.AutoSize = true;
            this._average_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._average_label.ForeColor = System.Drawing.Color.YellowGreen;
            this._average_label.Location = new System.Drawing.Point(139, 17);
            this._average_label.Name = "_average_label";
            this._average_label.Size = new System.Drawing.Size(48, 16);
            this._average_label.TabIndex = 3;
            this._average_label.Text = "00 ms";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this._fps_label);
            this.panel1.Controls.Add(this._average_label);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 354);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 48);
            this.panel1.TabIndex = 4;
            // 
            // _fps_label
            // 
            this._fps_label.AutoSize = true;
            this._fps_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fps_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._fps_label.Location = new System.Drawing.Point(84, 17);
            this._fps_label.Name = "_fps_label";
            this._fps_label.Size = new System.Drawing.Size(49, 16);
            this._fps_label.TabIndex = 4;
            this._fps_label.Text = "00 fps";
            // 
            // Screen_Stream
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 415);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_stream);
            this.Controls.Add(this.stream_box);
            this.Name = "Screen_Stream";
            this.Text = "Screen_Stream";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Screen_Stream_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.stream_box)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox stream_box;
        private System.Windows.Forms.Button btn_stream;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _average_label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _fps_label;
    }
}