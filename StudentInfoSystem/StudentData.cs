using System.Collections.Generic;

namespace StudentInfoSystem
{
    internal class StudentData
    {
        private List<Student> testStudents;

        public StudentData()
        {
            testStudents = new List<Student>();
            testStudents.Add(exampleStudent());
        }

        public List<Student> GetStudents()
        {
            return testStudents;
        }

        private void SetStudents(List<Student> list)
        {
            testStudents = list;
        }

        private Student exampleStudent()
        {
            Student student = new Student();
            student.Name = "Tijana";
            student.FatherName = "Trajche";
            student.Family = "Avramova";
            student.FacultyNum = "123219002";
            student.Year = 3;
            student.Specialty = "KSI";
            return student;
        }
    }
}
