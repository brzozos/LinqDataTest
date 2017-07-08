using LinqData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterUI
{
    public static class Loader
    {
        private static string provider = "System.Data.SqlClient";
        private static string connectionString = ConfigurationManager.ConnectionStrings["LocalTestDB"].ConnectionString;
        public static void GetData(TextBox input, Label output, Student student)
        {
            string query = "";
            query = $"Select * from STUDENT where NAME_STUDENT = '{(string)input.Text}'";


            DataTable basicData = DatabaseConnection.ExecuteQuery(query, provider, connectionString);

            FillStudent(student, basicData);

            query = $"Select * from REGISTER WHERE ID_REGISTER = {student.IDRegister}";

            DataTable gradeData = DatabaseConnection.ExecuteQuery(query, provider, connectionString);

            

            FillStudentGrades(student, gradeData);
            ShowStudent(student, output);

            
        }

        private static void FillStudentGrades(Student student, DataTable gradeData)
        {
            DataRow dr = gradeData.Rows[0];
            student.Subjects = new List<Subject>();
            for(int i = 0; i<5;i++)
            {
                student.Subjects.Add(new Subject(gradeData.Columns[i+1].ToString(), (int)dr.ItemArray.GetValue(i+1)));
            }

        }

        private static void FillStudent(Student student, DataTable dt)
        {
            student.ID = (int)dt.Rows[0].ItemArray.GetValue(0);
            student.Name = (string)dt.Rows[0].ItemArray.GetValue(1);
            student.Surname = (string)dt.Rows[0].ItemArray.GetValue(2);
            student.IDRegister = (int)dt.Rows[0].ItemArray.GetValue(3);
        }
        private static void ShowStudent(Student student, Label output)
        {
            StringBuilder s = new StringBuilder();
            s.Append($"ID: {student.ID} Imie: {student.Name} Nazwisko: {student.Surname}\n");
            
            foreach(var sub in student.Subjects)
            {
                s.Append($"{sub.Name} Ocena: {sub.FinalGrade}\n");
            }
            
            output.Text =  s.ToString();            
        }

    }
}
