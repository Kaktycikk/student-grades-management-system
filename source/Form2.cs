using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace StudentGradesApp
{
    public partial class Form2 : Form
    {
        private readonly string selectedGroup;
        private readonly string selectedSubject;
        private readonly DateTime selectedDate;
        private readonly Form1 parentForm;

        public bool SavedSuccessfully { get; private set; }

        public Form2(Form1 parent, string group, string subject, DateTime date)
        {
            InitializeComponent();
            selectedGroup = group;
            selectedSubject = subject;
            selectedDate = date;
            parentForm = parent;

            Load += Form2_Load;
            Resize += Form2_Resize;
            buttonSave.Click += ButtonSave_Click;
            buttonBack.Click += buttonBack_Click;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            labelGroupSubject.Text = $"Группа: {selectedGroup}, Предмет: {selectedSubject}, Дата: {selectedDate:dd.MM.yyyy}";

            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add("ФИО", "ФИО");

            var gradeColumn = new DataGridViewComboBoxColumn
            {
                Name = "Оценка",
                HeaderText = "Оценка",
                DataSource = new string[] { "—", "2", "3", "4", "5" }
            };
            dataGridView.Columns.Add(gradeColumn);

            LoadStudents();

            ResizeDataGridView();
        }

        private void LoadStudents()
        {
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=112233;Database=postgres";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT s.studentid, s.fullname
                    FROM students s
                    JOIN groups g ON s.groupid = g.groupid
                    WHERE g.groupname = @groupname
                    ORDER BY s.fullname";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("groupname", selectedGroup);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentId = reader.GetInt32(0);
                            string fullName = reader.GetString(1);
                            string grade = GetExistingGrade(studentId);

                            dataGridView.Rows.Add(fullName, grade ?? "—");
                        }
                    }
                }
            }
        }

        private string GetExistingGrade(int studentId)
        {
            string grade = null;
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=112233;Database=postgres";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT grade
                    FROM grades
                    WHERE studentid = @studentid
                    AND subject = @subject
                    AND date = @date";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("studentid", studentId);
                    cmd.Parameters.AddWithValue("subject", selectedSubject);
                    cmd.Parameters.AddWithValue("date", selectedDate);

                    object result = cmd.ExecuteScalar();
                    grade = result != null ? result.ToString() : null;
                }
            }

            return grade;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            bool anyChangesMade = false;//1

            for (int i = 0; i < dataGridView.Rows.Count; i++)//2
            {
                string fullName = dataGridView.Rows[i].Cells[0].Value?.ToString();//3
                string grade = dataGridView.Rows[i].Cells[1].Value?.ToString();//4

                if (!string.IsNullOrEmpty(fullName) && grade != "—")//5
                {
                    int studentId = GetStudentId(fullName);//6
                    string existingGrade = GetExistingGrade(studentId);//7

                    if (existingGrade != grade)//8
                    {
                        SaveGrade(studentId, grade);//9
                        anyChangesMade = true;
                    }
                }
            }

            if (anyChangesMade)//10
            {
                SavedSuccessfully = true;

                MessageBox.Show("Оценки сохранены.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
                parentForm.Show();
                return; 
            }

            MessageBox.Show("Нет изменений для сохранения.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);//11
        }

        private void SaveGrade(int studentId, string grade)
        {
            int? gradeValue = null;

            if (grade != "—")
            {
                gradeValue = Convert.ToInt32(grade);
            }

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=112233;Database=postgres";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string checkQuery = @"
                    SELECT COUNT(*)
                    FROM grades
                    WHERE studentid = @studentid
                    AND subject = @subject
                    AND date = @date";

                using (var cmdCheck = new NpgsqlCommand(checkQuery, connection))
                {
                    cmdCheck.Parameters.AddWithValue("studentid", studentId);
                    cmdCheck.Parameters.AddWithValue("subject", selectedSubject);
                    cmdCheck.Parameters.AddWithValue("date", selectedDate);

                    int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

                    if (count > 0)
                    {
                        string updateQuery = @"
                            UPDATE grades
                            SET grade = @grade
                            WHERE studentid = @studentid
                            AND subject = @subject
                            AND date = @date";

                        using (var cmdUpdate = new NpgsqlCommand(updateQuery, connection))
                        {
                            cmdUpdate.Parameters.AddWithValue("grade", gradeValue.HasValue ? gradeValue.Value : (object)DBNull.Value);
                            cmdUpdate.Parameters.AddWithValue("studentid", studentId);
                            cmdUpdate.Parameters.AddWithValue("subject", selectedSubject);
                            cmdUpdate.Parameters.AddWithValue("date", selectedDate);

                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string insertQuery = @"
                            INSERT INTO grades (studentid, subject, grade, date, groupid)
                            VALUES (@studentid, @subject, @grade, @date, @groupid)";

                        using (var cmdInsert = new NpgsqlCommand(insertQuery, connection))
                        {
                            cmdInsert.Parameters.AddWithValue("studentid", studentId);
                            cmdInsert.Parameters.AddWithValue("subject", selectedSubject);
                            cmdInsert.Parameters.AddWithValue("grade", gradeValue.HasValue ? gradeValue.Value : (object)DBNull.Value);
                            cmdInsert.Parameters.AddWithValue("date", selectedDate);
                            cmdInsert.Parameters.AddWithValue("groupid", GetGroupId(studentId));

                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private int GetStudentId(string fullName)
        {
            int studentId = -1;
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=112233;Database=postgres";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT studentid FROM students WHERE fullname = @fullname";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("fullname", fullName);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        studentId = Convert.ToInt32(result);
                }
            }

            return studentId;
        }

        private int GetGroupId(int studentId)
        {
            int groupId = -1;
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=112233;Database=postgres";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT groupid FROM students WHERE studentid = @studentid";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("studentid", studentId);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        groupId = Convert.ToInt32(result);
                }
            }

            return groupId;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            parentForm.Show();
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            ResizeDataGridView();
        }

        private void ResizeDataGridView()
        {
            if (dataGridView != null)
            {
                int tableWidth = ClientSize.Width - 60; 
                dataGridView.Size = new System.Drawing.Size(tableWidth, 150);
                dataGridView.Location = new System.Drawing.Point(30, 80); 
            }
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Произошла ошибка при вводе данных.");
            e.ThrowException = false;
        }
    }
}