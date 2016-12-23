namespace ComputeCollisionCylinderPoint
{
	partial class frmMain
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
            this.picRender = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picRender)).BeginInit();
            this.SuspendLayout();
            // 
            // picRender
            // 
            this.picRender.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picRender.Location = new System.Drawing.Point(12, 12);
            this.picRender.Name = "picRender";
            this.picRender.Size = new System.Drawing.Size(698, 512);
            this.picRender.TabIndex = 0;
            this.picRender.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 527);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Left Click + [(1 or A) = Move point A, (2 or K) = Move point K, (3 or B) = Move p" +
    "oint B]";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 549);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picRender);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComputeCollisionCylinderPoint";
            ((System.ComponentModel.ISupportInitialize)(this.picRender)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picRender;
		private System.Windows.Forms.Label label1;
	}
}

