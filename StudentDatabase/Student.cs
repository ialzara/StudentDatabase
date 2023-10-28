using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDatabase
{
    internal class Student
    {
        private string firstName;
        private string lastName;
        private string dob;
        private string grade;
        private string studentGu;
        private string schoolGu;

        public Student(string firstName, string lastName, string dob, string grade, string studentGu, string schoolGu) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dob = dob;
            this.grade = grade;
            this.studentGu = studentGu;
            this.schoolGu = schoolGu;
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }

        public string FirstName {  get { return firstName; } }
        public string LastName { get { return lastName; } }
        public string Dob { get {  return dob; } }
        public string Grade { get {  return grade; } }
        public string StudentGu { get {  return studentGu; } }
        public string SchoolGu { get { return schoolGu; } }

    }
}
