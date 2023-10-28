using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDatabase
{
    internal class Grade
    {
        public static Dictionary<string, string> grades = new Dictionary<string, string>() {
            {"1", "1st"},
            {"2", "2nd" },
            {"3", "3rd" },
            {"4", "4th"},
            {"5", "5th" },
            {"6", "6th" },
            {"7", "7th"},
            {"8", "8th" },
            {"9", "9th" },
            {"10", "10th"},
            {"11", "11th" },
            {"12", "12th" },
        };
        public static List<GradeEntry> ToList()
        {
            List<GradeEntry> gradeEntries = new List<GradeEntry>();
            foreach(KeyValuePair<string, string> gradeEntry in grades)
            {
                gradeEntries.Add(new GradeEntry()
                {
                    key = gradeEntry.Key,
                    value = gradeEntry.Value
                });
            }
            return gradeEntries;
        } 
    }
    class GradeEntry
    {
        public override string ToString()
        {
            return value.ToString();
        }
        public string key { get; set; }
        public string value { get; set; }

    }
}