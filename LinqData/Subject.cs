using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqData
{
    public class Subject
    {
        public string Name { get; set; }
        public int FinalGrade { get; set; }       

        public List<int> Grades { get; set; }

        public Subject(string name, int finalGrade)
        {
            Name = name;
            FinalGrade = finalGrade;
        }

    }
}
