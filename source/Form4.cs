using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Npgsql;

namespace StudentGradesApp
{
    public partial class Form4 : Form
    {
        private readonly string selectedGroup;
        private readonly string selectedSubject;
        private readonly Form1 parentForm;

        public Form4(Form1 parent, string group, string subject)
        {
            InitializeComponent();
            selectedGroup = group;
            selectedSubject = subject;
            parentForm = parent;

            Load += Form4_Load;
            buttonBack.Click += buttonBack_Click;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            labelGroupSubject.Text = $"Группа: {selectedGroup}, Предмет: {selectedSubject}";
            LoadStudentAverages();
        }

        private void LoadStudentAverages()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add("StudentName", "ФИО студента");
            dataGridView.Columns.Add("FirstHalfAverage", "Средний балл (1 полугодие)");
            dataGridView.Columns.Add("SecondHalfAverage", "Средний балл (2 полугодие)");
            dataGridView.Columns.Add("YearAverage", "Средний балл (за год)");

            var dateRanges = GetAcademicYearDateRanges();

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=112233;Database=postgres";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string studentQuery = @"
                    SELECT s.studentid, s.fullname
                    FROM students s
                    JOIN groups g ON s.groupid = g.groupid
                    WHERE g.groupname = @groupname
                    ORDER BY s.fullname";

                using (var cmdStudents = new NpgsqlCommand(studentQuery, connection))
                {
                    cmdStudents.Parameters.AddWithValue("groupname", selectedGroup);

                    using (var reader = cmdStudents.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentId = reader.GetInt32(0);
                            string fullName = reader.GetString(1);

                            decimal? firstHalfAverage = GetAverageGradeForPeriod(studentId, dateRanges.firstHalfStart, dateRanges.firstHalfEnd);
                            decimal? secondHalfAverage = GetAverageGradeForPeriod(studentId, dateRanges.secondHalfStart, dateRanges.secondHalfEnd);
                            decimal? yearAverage = CalculateYearAverage(firstHalfAverage, secondHalfAverage);

                            dataGridView.Rows.Add(
                                fullName,
                                firstHalfAverage?.ToString("F2") ?? "—",
                                secondHalfAverage?.ToString("F2") ?? "—",
                                yearAverage?.ToString("F2") ?? "—"
                            );
                        }
                    }
                }
            }
        }

        private (DateTime firstHalfStart, DateTime firstHalfEnd, DateTime secondHalfStart, DateTime secondHalfEnd) GetAcademicYearDateRanges()
        {
            int currentYear = DateTime.Now.Year;

            // Определяем начало учебного года
            int academicYearStart = DateTime.Now.Month >= 9 ? currentYear : currentYear - 1;

            DateTime firstHalfStart = new DateTime(academicYearStart, 9, 1);
            DateTime firstHalfEnd = new DateTime(academicYearStart, 12, 31);
            DateTime secondHalfStart = new DateTime(academicYearStart + 1, 1, 1);
            DateTime secondHalfEnd = new DateTime(academicYearStart + 1, 5, 31);

            return (firstHalfStart, firstHalfEnd, secondHalfStart, secondHalfEnd);
        }

        private decimal? GetAverageGradeForPeriod(int studentId, DateTime startDate, DateTime endDate)
        {
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=112233;Database=postgres";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT AVG(grade)
                    FROM grades
                    WHERE studentid = @studentid
                    AND subject = @subject
                    AND date BETWEEN @startdate AND @enddate";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("studentid", studentId);
                    cmd.Parameters.AddWithValue("subject", selectedSubject);
                    cmd.Parameters.AddWithValue("startdate", startDate);
                    cmd.Parameters.AddWithValue("enddate", endDate);

                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : (decimal?)null;
                }
            }
        }

        private decimal? CalculateYearAverage(decimal? firstHalf, decimal? secondHalf)
        {
            if (firstHalf.HasValue || secondHalf.HasValue)
            {
                List<decimal> averages = new List<decimal>();
                if (firstHalf.HasValue) averages.Add(firstHalf.Value);
                if (secondHalf.HasValue) averages.Add(secondHalf.Value);
                return averages.Average();
            }

            return null;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            parentForm.Show();
        }
    }
}