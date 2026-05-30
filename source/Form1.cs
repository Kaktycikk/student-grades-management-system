using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Npgsql;

namespace StudentGradesApp
{
    public partial class Form1 : Form
    {
        private Form2 form2;
        private Form3 form3;
        private Form4 form4; 

        public Form1()
        {
            InitializeComponent();
            LoadGroups();
            LoadSubjects();
            comboBoxGroup.Text = "Выберите группу";
            comboBoxSubject.Text = "Выберите предмет";

            buttonNext.Click += buttonNext_Click;
        }

        private void LoadGroups()
        {
            using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=112233;Database=postgres"))
            {
                conn.Open();
                string query = "SELECT DISTINCT groupname FROM groups ORDER BY groupname";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxGroup.Items.Add(reader.GetString(0));
                    }
                }
            }
        }

        private void LoadSubjects()
        {
            comboBoxSubject.Items.Add("Математический анализ");
            comboBoxSubject.Items.Add("Программирование");
            comboBoxSubject.Items.Add("Схемотехника");
            comboBoxSubject.Items.Add("Базы данных");
            comboBoxSubject.Items.Add("Операционные системы");
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            string selectedGroup = comboBoxGroup.Text;
            string selectedSubject = comboBoxSubject.Text;
            DateTime selectedDate = dateTimePicker.Value;

            List<string> emptyFields = new List<string>();

            if (string.IsNullOrWhiteSpace(selectedGroup) || selectedGroup == "Выберите группу")
            {
                emptyFields.Add("группу");
            }

            if (string.IsNullOrWhiteSpace(selectedSubject) || selectedSubject == "Выберите предмет")
            {
                emptyFields.Add("предмет");
            }

            if (emptyFields.Count > 0)
            {
                string missingFields = string.Join(", ", emptyFields);
                MessageBox.Show($"Пожалуйста, выберите {missingFields}.");
                return;
            }

            if (radioButtonGrades.Checked)
            {
                OpenForm2(selectedGroup, selectedSubject, selectedDate);
            }
            else if (radioButtonPerformance.Checked)
            {
                OpenForm3(selectedGroup, selectedSubject);
            }
            else if (radioButtonAverage.Checked)
            {
                OpenForm4(selectedGroup, selectedSubject);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите одно из действий.");
            }
        }

        private void OpenForm2(string selectedGroup, string selectedSubject, DateTime selectedDate)
        {
            if (form2 == null || form2.IsDisposed)
            {
                form2 = new Form2(this, selectedGroup, selectedSubject, selectedDate);
                form2.FormClosed += (sender, e) => this.Show();
            }

            form2.Show();
            this.Hide();
        }

        private void OpenForm3(string selectedGroup, string selectedSubject)
        {
            this.Hide();

            if (form3 == null || form3.IsDisposed)
            {
                form3 = new Form3(this, selectedGroup, selectedSubject);
                form3.FormClosed += (sender, e) => this.Show();
            }

            form3.Show();
        }

        private void OpenForm4(string selectedGroup, string selectedSubject)
        {
            this.Hide();

            if (form4 == null || form4.IsDisposed)
            {
                form4 = new Form4(this, selectedGroup, selectedSubject);
                form4.FormClosed += (sender, e) => this.Show();
            }

            form4.Show();
        }
    }
}