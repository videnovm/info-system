﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentData
    {
        public static List<Student> _TestStudents = new List<Student>();
        public static List<Student> TestStudents()
        {
            _TestStudents.Add(new Student { name = "Milosh", lastName = "Videnov", familyName = "Videnov", faculty = "ФКСТ", specialty = "Комп. и софт. инженерство",
                level = "Бакалавър", status = "Finalized", fakNo = "123217004", course = "3", potok = "9", group = "36" });
            _TestStudents.Add(new Student { name = "Hristijan", lastName = "Kolev", familyName = "Kolev", faculty = "ФКСТ", specialty = "Комп. и софт. инженерство", 
                level = "Бакалавър", status = "Dropped", fakNo = "123217007", course = "3", potok = "9", group = "36" });
            return _TestStudents;
        }
    }
}
