using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace LinqData
{
    public class DatabaseConnection
    {
        private static List<Student> students = new List<Student>();
        private static string provider = ConfigurationManager.AppSettings["provider"];
        static void Main(string[] args)
        {
            Connect(ConfigurationManager.AppSettings["provider"], GetConnectionString("LocalTestDB"));

            ShowStudents();

            
                       

            Console.ReadLine();
        }


        public static DataTable ExecuteQuery(string query,string provider, string connectionString)
        {
            DatabaseConnection.provider = provider;
            DbProviderFactory factoy = DbProviderFactories.GetFactory(provider);
            DataTable dt = new DataTable();


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, conn));
                adapter.Fill(dt);
                return dt;
            }





            /*
            using (DbConnection connection = factoy.CreateConnection())
            {               
                
                connection.ConnectionString = connectionString;
                connection.Open();

                DbCommand command = factoy.CreateCommand();
                
                command.Connection = connection;
                command.CommandText = query;

                List<dynamic> ret = null;
                string outt = "";

                using (DbDataReader dataReader = command.ExecuteReader())
                {           
                    
                    
                    while (dataReader.Read())
                    {
                        outt = (string)dataReader["SURNAME_STUDENT"];
                       // students.Add(new Student((int)dataReader["ID_STUDENT"], (string)dataReader["NAME_STUDENT"], (string)dataReader["SURNAME_STUDENT"], (int)dataReader["ID_REGISTER"]));
                    }

                }
                return dt;
                
            }*/
        }


        public static string GetConnectionString(string conn)
        {
            return ConfigurationManager.ConnectionStrings[conn].ConnectionString;
        }



        private static void Connect(string provider, string connectionString)
        {
            DbProviderFactory factoy = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factoy.CreateConnection())
            {
                if (connection == null)
                {
                    ShowError("Connection");
                    return;
                }
                //Console.WriteLine($"Your connection object is a: { connection.GetType().Name}");
                connection.ConnectionString = connectionString;
                connection.Open();

                DbCommand command = factoy.CreateCommand();
                if (command == null)
                {
                    ShowError("Command");
                    return;
                }
               // Console.WriteLine($"Your command object is a: {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "Select * from STUDENT";

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    //Console.WriteLine($"Your data reader object is a: { dataReader.GetType().Name}");
                    while (dataReader.Read())
                    {
                        //Console.WriteLine($" -> Student {dataReader["NAME_STUDENT"]}  {dataReader["SURNAME_STUDENT"]}.");
                        students.Add(new Student((int)dataReader["ID_STUDENT"], (string)dataReader["NAME_STUDENT"], (string)dataReader["SURNAME_STUDENT"], (int)dataReader["ID_REGISTER"]));
                    }

                }

                command.CommandText = "select * from REGISTER";
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        foreach (var student in students)
                        {
                            if (student.IDRegister == (int)dataReader["ID_REGISTER"])
                            {
                                student.Subjects.Add(new Subject("Matematyka", (int)dataReader["MATEMATYKA"]));
                                student.Subjects.Add(new Subject("Polski", (int)dataReader["POLSKI"]));
                                student.Subjects.Add(new Subject("Angielski", (int)dataReader["ANGIELSKI"]));
                                student.Subjects.Add(new Subject("Chemia", (int)dataReader["CHEMIA"]));
                                student.Subjects.Add(new Subject("Biologia", (int)dataReader["BIOLOGIA"]));

                            }
                        }
                    }
                }

                
            }
            
        }

        private static void ShowError(string v)
        {
            Console.WriteLine($"Bład: {v}");
        }

        private static void ShowStudents()
        {
            foreach(var student in students)
            {
                Console.WriteLine($"Uczniowie: {student.Name} {student.Surname}");
                ShowStudentGrades(student);
            }
        }

        private static void ShowStudentGrades(Student students)
        {
            foreach (var subject in students.Subjects)
            {
                Console.WriteLine($"{subject.Name} {subject.FinalGrade}");
            }
            Console.WriteLine();
        }
    
    
    }
}
