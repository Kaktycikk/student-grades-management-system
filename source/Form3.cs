using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Npgsql;

namespace StudentGradesApp
{
    public partial class Form3 : Form
    {
        private string selectedGroup;
        private string selectedSubject;
        private Form1 parentForm; 

        public Form3(Form1 parent, string group, string subject)
        {
            InitializeComponent();
            selectedGroup = group;
            selectedSubject = subject;
            parentForm = parent; 
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            labelGroupSubject.Text = $"Группа: {selectedGroup}, Предмет: {selectedSubject}";
        }

        private void LoadStudentGrades()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=112233;Database=postgres";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string dateQuery = GetDateQuery();
                List<DateTime> uniqueDates = new List<DateTime>();
                using (var dateCommand = new NpgsqlCommand(dateQuery, connection))
                using (var reader = dateCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        uniqueDates.Add(reader.GetDateTime(0));
                    }
                }

                if (uniqueDates.Count == 0)
                {
                    MessageBox.Show("За выбранный период нет оценок.");
                    return;
                }

                dataGridView.Columns.Add("StudentName", "ФИО студента");
                foreach (var date in uniqueDates)
                {
                    dataGridView.Columns.Add(date.ToShortDateString(), date.ToShortDateString());
                }

                string studentQuery = "SELECT fullname FROM students WHERE groupid = (SELECT groupid FROM groups WHERE groupname = @groupname)";
                List<string> students = new List<string>();

                using (var studentCommand = new NpgsqlCommand(studentQuery, connection))
                {
                    studentCommand.Parameters.AddWithValue("groupname", selectedGroup);
                    using (var reader = studentCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(reader.GetString(0));
                        }
                    }
                }

                if (students.Count == 0)
                {
                    MessageBox.Show($"Студенты для группы '{selectedGroup}' не найдены.");
                    return;
                }

                foreach (var student in students)
                {
                    var row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = student });

                    foreach (var date in uniqueDates)
                    {
                        string gradeQuery = "SELECT grade FROM grades WHERE studentid = (SELECT studentid FROM students WHERE fullname = @fullname) AND date = @date AND subject = @subject";
                        using (var gradeCommand = new NpgsqlCommand(gradeQuery, connection))
                        {
                            gradeCommand.Parameters.AddWithValue("fullname", student);
                            gradeCommand.Parameters.AddWithValue("date", date);
                            gradeCommand.Parameters.AddWithValue("subject", selectedSubject);

                            var result = gradeCommand.ExecuteScalar();
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = result?.ToString() ?? "—" });
                        }
                    }

                    dataGridView.Rows.Add(row);
                }
            }
        }

        private string GetDateQuery()
        {
            DateTime startDate;
            DateTime endDate;

            if (radioButtonFirstHalf.Checked)
            {
                startDate = new DateTime(DateTime.Now.Year, 9, 1);
                endDate = new DateTime(DateTime.Now.Year, 12, 31);
            }
            else
            {
                startDate = new DateTime(DateTime.Now.Year, 1, 1);
                endDate = new DateTime(DateTime.Now.Year, 5, 31);
            }

            return $"SELECT DISTINCT date FROM grades WHERE date BETWEEN '{startDate:yyyy-MM-dd}' AND '{endDate:yyyy-MM-dd}' AND subject = '{selectedSubject}' ORDER BY date";
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            parentForm.Show();
        }

        private void buttonShowGrades_Click(object sender, EventArgs e)
        {
            LoadStudentGrades();
        }
    }
}