using BUS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class StudentService
    {
        StudentcontextDB context = new StudentcontextDB();

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public List<Student> GetAllHasNoMajor()
        {
             return context.Students.Where(p => p.MajorID == null).ToList();
        }

        public List<Student> GetAllHasNoMajor(int facultyID)
        {
            return context.Students.Where(p => p.MajorID == null && p.FacultyID == facultyID).ToList();
        }

        public Student FindById(int studentID)
        {
            return context.Students.FirstOrDefault(p => p.StudentID == studentID);
        }

        public void InserUpdate (Student s)
        {
            context.Students.Add(s);
            context.SaveChanges();
        }

        public void DeleteStudent(string studentID)
        {
            
            var student = context.Students.FirstOrDefault(s => s.StudentID.ToString() == studentID);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Sinh viên không tồn tại.");
            }
        }

        public void Update(Student s)
        {
            var existingStudent = context.Students.FirstOrDefault(p => p.StudentID == s.StudentID);
            if (existingStudent != null)
            {
               
                existingStudent.FullName = s.FullName;
                existingStudent.FacultyID = s.FacultyID;
                existingStudent.AverageScore = s.AverageScore;
                
            }
            else
            {
                context.Students.Add(s);
            }
            context.SaveChanges();
        }
    }
}
