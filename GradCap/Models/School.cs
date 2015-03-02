using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradCap.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public USAStates State { get; set; }
        public string Zip { get; set; }
        public int Size { get; set; }
        public SchoolType SchoolType { get; set; }
        public int Tuition { get; set; }
        public int AdmitRate { get; set; }
        public int AvgSAT { get; set; }
        public int AvgACT { get; set; }
        public string Website { get; set; }

        public ICollection<Student> FavoriteStudents { get; set; }
        public ICollection<Student> NoInterestStudents { get; set; }
    }
}