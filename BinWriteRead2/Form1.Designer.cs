namespace BinWriteRead2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DataName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCapital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataPeople = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataName,
            this.DataCapital,
            this.DataArea,
            this.DataPeople});
            this.dataGridView1.Location = new System.Drawing.Point(18, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(460, 346);
            this.dataGridView1.TabIndex = 0;
            // 
            // DataName
            // 
            this.DataName.HeaderText = "Name";
            this.DataName.Name = "DataName";
            // 
            // DataCapital
            // 
            this.DataCapital.HeaderText = "Capital";
            this.DataCapital.Name = "DataCapital";
            // 
            // DataArea
            // 
            this.DataArea.HeaderText = "Area";
            this.DataArea.Name = "DataArea";
            // 
            // DataPeople
            // 
            this.DataPeople.HeaderText = "People";
            this.DataPeople.Name = "DataPeople";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 425);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCapital;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataPeople;
    }
}

