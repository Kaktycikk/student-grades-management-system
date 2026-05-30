namespace StudentGradesApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.comboBoxSubject = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.radioButtonGrades = new System.Windows.Forms.RadioButton();
            this.radioButtonPerformance = new System.Windows.Forms.RadioButton();
            this.radioButtonAverage = new System.Windows.Forms.RadioButton();
            this.buttonNext = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // comboBoxGroup
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(30, 30);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(400, 24);
            this.comboBoxGroup.TabIndex = 0;
            this.comboBoxGroup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxGroup.Font = new System.Drawing.Font("Segoe UI", 10F);

            // comboBoxSubject
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.Location = new System.Drawing.Point(30, 70);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new System.Drawing.Size(400, 24);
            this.comboBoxSubject.TabIndex = 1;
            this.comboBoxSubject.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxSubject.Font = new System.Drawing.Font("Segoe UI", 10F);

            // dateTimePicker
            this.dateTimePicker.Location = new System.Drawing.Point(30, 110);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(400, 22);
            this.dateTimePicker.TabIndex = 2;
            this.dateTimePicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // radioButtonGrades
            this.radioButtonGrades.Location = new System.Drawing.Point(30, 150);
            this.radioButtonGrades.Name = "radioButtonGrades";
            this.radioButtonGrades.Size = new System.Drawing.Size(400, 24);
            this.radioButtonGrades.Text = "Выставление оценок";
            this.radioButtonGrades.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioButtonGrades.Checked = true;

            // radioButtonPerformance
            this.radioButtonPerformance.Location = new System.Drawing.Point(30, 180);
            this.radioButtonPerformance.Name = "radioButtonPerformance";
            this.radioButtonPerformance.Size = new System.Drawing.Size(400, 24);
            this.radioButtonPerformance.Text = "Вывод успеваемости";
            this.radioButtonPerformance.Font = new System.Drawing.Font("Segoe UI", 10F);

            // radioButtonAverage
            this.radioButtonAverage.Location = new System.Drawing.Point(30, 210);
            this.radioButtonAverage.Name = "radioButtonAverage";
            this.radioButtonAverage.Size = new System.Drawing.Size(400, 24);
            this.radioButtonAverage.Text = "Вывод среднего балла";
            this.radioButtonAverage.Font = new System.Drawing.Font("Segoe UI", 10F);

            // buttonNext
            this.buttonNext.Location = new System.Drawing.Point(30, 250);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(400, 40);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "Далее";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.buttonNext.ForeColor = System.Drawing.Color.White;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 330);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.comboBoxSubject);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.radioButtonGrades);
            this.Controls.Add(this.radioButtonPerformance);
            this.Controls.Add(this.radioButtonAverage);
            this.Controls.Add(this.buttonNext);
            this.Name = "Form1";
            this.Text = "Выбор группы и предмета";
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.RadioButton radioButtonGrades;
        private System.Windows.Forms.RadioButton radioButtonPerformance;
        private System.Windows.Forms.RadioButton radioButtonAverage;
        private System.Windows.Forms.Button buttonNext;
    }
}
