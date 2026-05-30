using System;

namespace StudentGradesApp
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelGroupSubject;
        private System.Windows.Forms.Button buttonBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelGroupSubject = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 69);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(476, 150);
            this.dataGridView.TabIndex = 0;
            // 
            // labelGroupSubject
            // 
            this.labelGroupSubject.AutoSize = true;
            this.labelGroupSubject.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelGroupSubject.Location = new System.Drawing.Point(30, 30);
            this.labelGroupSubject.Name = "labelGroupSubject";
            this.labelGroupSubject.Size = new System.Drawing.Size(280, 21);
            this.labelGroupSubject.TabIndex = 1;
            this.labelGroupSubject.Text = "Группа: <group>, Предмет: <subject>";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.LightCoral;
            this.buttonBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(150, 240);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(200, 40);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            // 
            // Form4
            // 
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.labelGroupSubject);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Средние баллы студентов";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.Resize += new System.EventHandler(this.Form4_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form4_Resize(object sender, EventArgs e)
        {
            ResizeDataGridView();
        }

        private void ResizeDataGridView()
        {
            if (this.dataGridView != null)
            {
                int tableWidth = this.ClientSize.Width - 60;
                this.dataGridView.Size = new System.Drawing.Size(tableWidth, 150);
                this.dataGridView.Location = new System.Drawing.Point(30, 80);
            }
        }
    }
}