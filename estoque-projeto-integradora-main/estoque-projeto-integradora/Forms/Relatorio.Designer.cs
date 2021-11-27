
namespace estoque_projeto_integradora.Forms
{
    partial class Relatorio
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
            this.cmdGerarRelatório = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // cmdGerarRelatório
            // 
            this.cmdGerarRelatório.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmdGerarRelatório.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGerarRelatório.Location = new System.Drawing.Point(424, 292);
            this.cmdGerarRelatório.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdGerarRelatório.Name = "cmdGerarRelatório";
            this.cmdGerarRelatório.Size = new System.Drawing.Size(188, 85);
            this.cmdGerarRelatório.TabIndex = 0;
            this.cmdGerarRelatório.Text = "Gerar Relatório";
            this.cmdGerarRelatório.UseVisualStyleBackColor = true;
            this.cmdGerarRelatório.Click += new System.EventHandler(this.cmdGerarRelatório_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(389, 151);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(249, 41);
            this.dateTimePicker2.TabIndex = 61;
            // 
            // Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.cmdGerarRelatório);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Relatorio";
            this.Text = "Relatorio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdGerarRelatório;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}