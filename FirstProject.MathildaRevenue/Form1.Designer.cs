
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
            this.ComboBoxChartType = new System.Windows.Forms.ComboBox();
            this.LabelChartType = new System.Windows.Forms.Label();
            this.ComboBoxChartInterval = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelChartInterval = new System.Windows.Forms.Label();
            this.LabelYearlyTotalMoney = new System.Windows.Forms.Label();
            this.LabelMontlyTotalMoney = new System.Windows.Forms.Label();
            this.LabelWeeklyTotalMoney = new System.Windows.Forms.Label();
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
            this.ChartPanel.Location = new System.Drawing.Point(12, 62);
            this.ChartPanel.Name = "ChartPanel";
            this.ChartPanel.Size = new System.Drawing.Size(960, 487);
            this.ChartPanel.TabIndex = 1;
            // 
            // ComboBoxChartType
            // 
            this.ComboBoxChartType.FormattingEnabled = true;
            this.ComboBoxChartType.Items.AddRange(new object[] {
            "Total money",
            "Basic cupcakes",
            "Delux cupcakes"});
            this.ComboBoxChartType.Location = new System.Drawing.Point(80, 33);
            this.ComboBoxChartType.Name = "ComboBoxChartType";
            this.ComboBoxChartType.Size = new System.Drawing.Size(121, 23);
            this.ComboBoxChartType.TabIndex = 2;
            // 
            // LabelChartType
            // 
            this.LabelChartType.AutoSize = true;
            this.LabelChartType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelChartType.Location = new System.Drawing.Point(99, 9);
            this.LabelChartType.Name = "LabelChartType";
            this.LabelChartType.Size = new System.Drawing.Size(82, 21);
            this.LabelChartType.TabIndex = 3;
            this.LabelChartType.Text = "Chart type";
            // 
            // ComboBoxChartInterval
            // 
            this.ComboBoxChartInterval.FormattingEnabled = true;
            this.ComboBoxChartInterval.Items.AddRange(new object[] {
            "Last 12 months (Year)",
            "Last 52 weeks (Year)",
            "Last 30 days (Month)",
            "Last 7 days (Week)"});
            this.ComboBoxChartInterval.Location = new System.Drawing.Point(207, 33);
            this.ComboBoxChartInterval.Name = "ComboBoxChartInterval";
            this.ComboBoxChartInterval.Size = new System.Drawing.Size(121, 23);
            this.ComboBoxChartInterval.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(218, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Time interval";
            // 
            // LabelChartInterval
            // 
            this.LabelChartInterval.AutoSize = true;
            this.LabelChartInterval.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelChartInterval.Location = new System.Drawing.Point(218, 9);
            this.LabelChartInterval.Name = "LabelChartInterval";
            this.LabelChartInterval.Size = new System.Drawing.Size(100, 21);
            this.LabelChartInterval.TabIndex = 5;
            this.LabelChartInterval.Text = "Time interval";
            // 
            // LabelYearlyTotalMoney
            // 
            this.LabelYearlyTotalMoney.AutoSize = true;
            this.LabelYearlyTotalMoney.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelYearlyTotalMoney.Location = new System.Drawing.Point(390, 35);
            this.LabelYearlyTotalMoney.Name = "LabelYearlyTotalMoney";
            this.LabelYearlyTotalMoney.Size = new System.Drawing.Size(161, 21);
            this.LabelYearlyTotalMoney.TabIndex = 6;
            this.LabelYearlyTotalMoney.Text = "Yearly revenue totals: ";
            // 
            // LabelMontlyTotalMoney
            // 
            this.LabelMontlyTotalMoney.AutoSize = true;
            this.LabelMontlyTotalMoney.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelMontlyTotalMoney.Location = new System.Drawing.Point(640, 9);
            this.LabelMontlyTotalMoney.Name = "LabelMontlyTotalMoney";
            this.LabelMontlyTotalMoney.Size = new System.Drawing.Size(168, 21);
            this.LabelMontlyTotalMoney.TabIndex = 7;
            this.LabelMontlyTotalMoney.Text = "Montly revenue totals: ";
            // 
            // LabelWeeklyTotalMoney
            // 
            this.LabelWeeklyTotalMoney.AutoSize = true;
            this.LabelWeeklyTotalMoney.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelWeeklyTotalMoney.Location = new System.Drawing.Point(639, 35);
            this.LabelWeeklyTotalMoney.Name = "LabelWeeklyTotalMoney";
            this.LabelWeeklyTotalMoney.Size = new System.Drawing.Size(169, 21);
            this.LabelWeeklyTotalMoney.TabIndex = 8;
            this.LabelWeeklyTotalMoney.Text = "Weekly revenue totals: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.LabelWeeklyTotalMoney);
            this.Controls.Add(this.LabelMontlyTotalMoney);
            this.Controls.Add(this.LabelYearlyTotalMoney);
            this.Controls.Add(this.LabelChartInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBoxChartInterval);
            this.Controls.Add(this.LabelChartType);
            this.Controls.Add(this.ComboBoxChartType);
            this.Controls.Add(this.ChartPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Counting $$$";
            this.ChartPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FillChartTotalMoney;
        private System.Windows.Forms.Panel ChartPanel;
        private System.Windows.Forms.ComboBox ComboBoxChartType;
        private System.Windows.Forms.Label LabelChartType;
        private System.Windows.Forms.ComboBox ComboBoxChartInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelChartInterval;
        private System.Windows.Forms.Label LabelYearlyTotalMoney;
        private System.Windows.Forms.Label LabelMontlyTotalMoney;
        private System.Windows.Forms.Label LabelWeeklyTotalMoney;
    }
}

