using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqData
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IDRegister { get; set; }

        public List<Subject> Subjects { get; set; }

        public Student(){}

        public Student(int id, string name,string surname,int idRegister)
        {
            ID = id;
            Name = name;
            Surname = surname;
            IDRegister = idRegister;
            Subjects = new List<Subject>();

        }
    }
}
