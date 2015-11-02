namespace FirstLabWork
{
    partial class Form3
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
            this.dgvHi = new System.Windows.Forms.DataGridView();
            this.ofdHi = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHi
            // 
            this.dgvHi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHi.Location = new System.Drawing.Point(0, 0);
            this.dgvHi.Name = "dgvHi";
            this.dgvHi.ReadOnly = true;
            this.dgvHi.Size = new System.Drawing.Size(599, 368);
            this.dgvHi.TabIndex = 0;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 368);
            this.Controls.Add(this.dgvHi);
            this.Name = "Form3";
            this.Text = "Таблица значений критерия Пирсона";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHi;
        private System.Windows.Forms.OpenFileDialog ofdHi;
    }
}