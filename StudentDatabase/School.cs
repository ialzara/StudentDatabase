using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDatabase
{
    internal class School
    {
        private string name;
        private string schoolGu;

        public School(string name, string schoolGu) 
        {
            this.name = name;
            this.schoolGu = schoolGu;
        }
        public override string ToString()
        {
            return name;
        }
        public string Name {  get { return name; } }
        public string SchoolGu { get {  return schoolGu; } }
    }
}
