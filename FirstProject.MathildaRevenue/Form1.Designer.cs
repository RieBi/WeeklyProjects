
namespace FirstProject.MathildaRevenue
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FillChartTotalMoney = new System.Windows.Forms.Button();
            this.ChartPanel = new System.Windows.Forms.Panel();
            this.ChartPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FillChartTotalMoney
            // 
            this.FillChartTotalMoney.Location = new System.Drawing.Point(3, 3);
            this.FillChartTotalMoney.Name = "FillChartTotalMoney";
            this.FillChartTotalMoney.Size = new System.Drawing.Size(954, 481);
            this.FillChartTotalMoney.TabIndex = 0;
            this.FillChartTotalMoney.Text = "button1";
            this.FillChartTotalMoney.UseVisualStyleBackColor = true;
            this.FillChartTotalMoney.Visible = false;
            // 
            // ChartPanel
            // 
            this.ChartPanel.AutoScroll = true;
            this.ChartPanel.Controls.Add(this.FillChartTotalMoney);
            this.ChartPanel.Location = new System.Drawing.Point(12, 12);
            this.ChartPanel.Name = "ChartPanel";
            this.ChartPanel.Size = new System.Drawing.Size(960, 487);
            this.ChartPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 511);
            this.Controls.Add(this.ChartPanel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 550);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 550);
            this.Name = "Form1";
            this.Text = "Counting $$$";
            this.ChartPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FillChartTotalMoney;
        private System.Windows.Forms.Panel ChartPanel;
    }
}

