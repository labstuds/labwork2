namespace FirstLabWork
{
	partial class CheckDistributionForm
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
            this.graphTheor = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // graphTheor
            // 
            this.graphTheor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphTheor.Location = new System.Drawing.Point(12, 12);
            this.graphTheor.Name = "graphTheor";
            this.graphTheor.ScrollGrace = 0D;
            this.graphTheor.ScrollMaxX = 0D;
            this.graphTheor.ScrollMaxY = 0D;
            this.graphTheor.ScrollMaxY2 = 0D;
            this.graphTheor.ScrollMinX = 0D;
            this.graphTheor.ScrollMinY = 0D;
            this.graphTheor.ScrollMinY2 = 0D;
            this.graphTheor.Size = new System.Drawing.Size(571, 392);
            this.graphTheor.TabIndex = 1;
            this.graphTheor.UseExtendedPrintDialog = true;
            // 
            // CheckDistributionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(595, 416);
            this.Controls.Add(this.graphTheor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CheckDistributionForm";
            this.Text = "Проверка гипотезы о виде закона распределения";
            this.ResumeLayout(false);

		}

		#endregion

        private ZedGraph.ZedGraphControl graphTheor;
	}
}