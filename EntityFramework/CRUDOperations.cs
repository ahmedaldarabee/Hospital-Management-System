using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class CRUDOperations{
        AapCourseEntities entities = new AapCourseEntities();

        //Why Student not Students ?
        Student studentObj = new Student();
        
        public void addStudent() {
            studentObj.FirstName = "Ahmed nayel";
            studentObj.LastName = "al-darabee";
            studentObj.Email = "seahmednail@gmail.com";
            studentObj.DataOFBirth = DateTime.Now;
            studentObj.Gender = true;
            studentObj.CountryId = 3;
            studentObj.DepartmentId = 3;


            entities.Students.Add(studentObj);
            entities.SaveChanges();
        }
    
        public void updateStudent(){
            studentObj = entities.Students.
            Where(std => std.StudentId == 2001).ToList().FirstOrDefault();
            if(studentObj != null){
                studentObj.FirstName = "Darabee21";
                entities.SaveChanges();
            }
        }
    
        public void deleteStudent(){
            studentObj = entities.Students.
            Where(std => std.isDeleted == false).ToList().FirstOrDefault();

            entities.Students.Remove(studentObj);
            entities.SaveChanges();
        }

        //Not Understandable
        // for what used ?
        public void getStudentData(){
            List<Student> studentList = new List<Student>();
            // to return specific columns and store it in list
            studentList = (from std in entities.Students.ToList()
            select new Student {
                FirstName = std.FirstName,
                LastName  = std.LastName 
            }).ToList();
        }

        public void getStudentName(){
            // to return specific columns and store it in var
            var studentName = (from std in entities.Students.ToList()
                select new {
                    username = std.FirstName
                }
            ).ToList();
        }
    
        public void getJoinedData(){
            var studentList = (
                 from std in entities.Students.ToList()

                 join country in entities.Countries.ToList()
                 on std.CountryId equals country.CountryId

                 select new {
                     studentName    = std.FirstName + ' ' + std.LastName,
                     studentCountry = country.CountryName
                 }
                 
                 ).ToList();
        }
        

        //public void getIncludedData(){
        //    // left join
        //    var studentInfo =
        //        (
        //        from s in entities.Students.Include(s => s.Country).ToList()
        //         select new
        //         {
        //             studentName = s.FirstName + " " + s.LastName,
        //             countryName = s.Country == null ? "" : s.Country.CountryName
        //         }).ToList();
        //}
        
        public void getStudentAvg(){
            List<StudentTeacher> marks = entities.StudentTeachers.ToList();

            int resutlOFSum = 0;
            foreach(StudentTeacher item in marks){
                resutlOFSum += item.TecherId.Value;
            }
            int avg = resutlOFSum / marks.Count() ;
            Console.WriteLine("The average of students: " + avg);
        }
    
        public void getStudentIds() {
            List<int> studentId = entities.Students.ToList().
            Select(std => std.StudentId).ToList();

            // this section to show common id between students and departments
            List<string> departmentId =
            entities.Departments.Where(dept => studentId.Contains(dept.DepartmentId)).ToList()
            .Select(dept => dept.DepartmentName).ToList();
        }
    }
}
