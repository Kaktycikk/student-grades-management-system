using System;
using System.Windows.Forms;

namespace StudentGradesApp
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelGroupSubject;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnGrade;

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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGrade = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();

            // dataGridView
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ColumnName,
                this.ColumnGrade});
            this.dataGridView.Location = new System.Drawing.Point(30, 80);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(440, 150); // Начальный размер таблицы
            this.dataGridView.TabIndex = 0;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);

            // labelGroupSubject
            this.labelGroupSubject.AutoSize = true;
            this.labelGroupSubject.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelGroupSubject.Location = new System.Drawing.Point(30, 30);
            this.labelGroupSubject.Name = "labelGroupSubject";
            this.labelGroupSubject.Size = new System.Drawing.Size(320, 21);
            this.labelGroupSubject.TabIndex = 1;
            this.labelGroupSubject.Text = "Группа: <group>, Предмет: <subject>, Дата: <date>";

            // buttonSave
            this.buttonSave.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(30, 240);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(200, 40);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);

            // buttonBack
            this.buttonBack.BackColor = System.Drawing.Color.LightCoral;
            this.buttonBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(270, 240);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(200, 40);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);

            // ColumnName
            this.ColumnName.HeaderText = "Студент";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 250;

            // ColumnGrade
            this.ColumnGrade.HeaderText = "Оценка";
            this.ColumnGrade.Name = "ColumnGrade";
            this.ColumnGrade.Items.AddRange(new object[] { "—", "2", "3", "4", "5" });
            this.ColumnGrade.Width = 150;

            // Form2
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelGroupSubject);
            this.Controls.Add(this.dataGridView);
            this.Name = "Form2";
            this.Text = "Ввод оценок";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form2_Load); // Добавляем обработчик события Load
            this.Resize += new System.EventHandler(this.Form2_Resize); // Обработчик изменения размера формы
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}