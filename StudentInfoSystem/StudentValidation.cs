using System;
using System.Collections.Generic;
using UserLogin;

namespace StudentInfoSystem
{
    internal class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
           StudentData studentData = new StudentData();
           if(user == null || user.facultyNum == null)
           {
                throw new ArgumentNullException("Faculty number is not found");
           } 

           IEnumerable<Student> list = studentData.GetStudents();

           foreach(Student student in list)
           {
                if (student.FacultyNum.Equals(user.facultyNum))
                {
                    return student;
                }
           }

            throw new ArgumentNullException("Student is not found");
        }
    }
}
