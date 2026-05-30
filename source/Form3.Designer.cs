using System.Windows.Forms;

namespace StudentGradesApp
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelGroupSubject;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonShowGrades;
        private System.Windows.Forms.RadioButton radioButtonFirstHalf;
        private System.Windows.Forms.RadioButton radioButtonSecondHalf;
        private System.Windows.Forms.Panel panelPeriodSelection;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelGroupSubject = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonShowGrades = new System.Windows.Forms.Button();
            this.radioButtonFirstHalf = new System.Windows.Forms.RadioButton();
            this.radioButtonSecondHalf = new System.Windows.Forms.RadioButton();
            this.panelPeriodSelection = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelPeriodSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelGroupSubject
            // 
            this.labelGroupSubject.AutoSize = true;
            this.labelGroupSubject.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelGroupSubject.Location = new System.Drawing.Point(30, 20);
            this.labelGroupSubject.Name = "labelGroupSubject";
            this.labelGroupSubject.Size = new System.Drawing.Size(280, 21);
            this.labelGroupSubject.TabIndex = 0;
            this.labelGroupSubject.Text = "Группа: <group>, Предмет: <subject>";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(34, 134);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(440, 200);
            this.dataGridView.TabIndex = 2;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.LightCoral;
            this.buttonBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(150, 340);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(200, 40);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonShowGrades
            // 
            this.buttonShowGrades.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonShowGrades.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.buttonShowGrades.ForeColor = System.Drawing.Color.White;
            this.buttonShowGrades.Location = new System.Drawing.Point(160, 90);
            this.buttonShowGrades.Name = "buttonShowGrades";
            this.buttonShowGrades.Size = new System.Drawing.Size(200, 40);
            this.buttonShowGrades.TabIndex = 4;
            this.buttonShowGrades.Text = "Показать успеваемость";
            this.buttonShowGrades.UseVisualStyleBackColor = false;
            this.buttonShowGrades.Click += new System.EventHandler(this.buttonShowGrades_Click);
            // 
            // radioButtonFirstHalf
            // 
            this.radioButtonFirstHalf.AutoSize = true;
            this.radioButtonFirstHalf.Checked = true;
            this.radioButtonFirstHalf.Location = new System.Drawing.Point(0, 5);
            this.radioButtonFirstHalf.Name = "radioButtonFirstHalf";
            this.radioButtonFirstHalf.Size = new System.Drawing.Size(86, 17);
            this.radioButtonFirstHalf.TabIndex = 0;
            this.radioButtonFirstHalf.TabStop = true;
            this.radioButtonFirstHalf.Text = "1 полугодие";
            this.radioButtonFirstHalf.UseVisualStyleBackColor = true;
            // 
            // radioButtonSecondHalf
            // 
            this.radioButtonSecondHalf.AutoSize = true;
            this.radioButtonSecondHalf.Location = new System.Drawing.Point(100, 5);
            this.radioButtonSecondHalf.Name = "radioButtonSecondHalf";
            this.radioButtonSecondHalf.Size = new System.Drawing.Size(86, 17);
            this.radioButtonSecondHalf.TabIndex = 1;
            this.radioButtonSecondHalf.Text = "2 полугодие";
            this.radioButtonSecondHalf.UseVisualStyleBackColor = true;
            // 
            // panelPeriodSelection
            // 
            this.panelPeriodSelection.Controls.Add(this.radioButtonFirstHalf);
            this.panelPeriodSelection.Controls.Add(this.radioButtonSecondHalf);
            this.panelPeriodSelection.Location = new System.Drawing.Point(160, 55);
            this.panelPeriodSelection.Name = "panelPeriodSelection";
            this.panelPeriodSelection.Size = new System.Drawing.Size(200, 25);
            this.panelPeriodSelection.TabIndex = 1;
            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.buttonShowGrades);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelPeriodSelection);
            this.Controls.Add(this.labelGroupSubject);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Успеваемость студентов";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelPeriodSelection.ResumeLayout(false);
            this.panelPeriodSelection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
