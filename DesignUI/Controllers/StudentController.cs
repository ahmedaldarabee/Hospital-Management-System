using DesignUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignUI.Controllers
{
    public class StudentController : Controller {

        Student student = new Student();
        DBEntities context = new DBEntities();

        public IActionResult Index() {
            return View();
        }

        public IActionResult Add(){
            return View();
        }

        // that take data from form view by [ studentModel ] then try to store it in database.

        public IActionResult AddNewStudent(Models.StudentModel studentModel){
            student.FirstName = studentModel.FirstName;
            student.LastName = studentModel.LastName;
            student.Email = studentModel.Email;
            student.Gender = true;
            
            context.Students.Add(student);
            context.SaveChanges();

            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll(){
            // select specific columns from database
            // and show it into screen after stored
            List<StudentModel> student = new List<StudentModel>();

            student = (
                from std in context.Students.ToList()
                select new StudentModel {
                    FirstName = std.FirstName,
                    LastName = std.LastName,
                    Email = std.Email,
                    StudentId = std.StudentId
                }
            ).ToList();

            return View(student);
        }

        public IActionResult Delete(int Id){
            student = context.Students.Where(std => std.StudentId == Id).FirstOrDefault();
            
            if(student != null){
                context.Students.Remove(student);
                context.SaveChanges();
            }
            
            return RedirectToAction("GetAll");
        }

        public IActionResult Edit(int Id){

            student = context.Students.Where(std => std.StudentId == Id).FirstOrDefault();

            Models.StudentModel model = new Models.StudentModel();

            model.StudentId = student.StudentId;
            model.FirstName = student.FirstName;
            model.LastName  = student.LastName;
            model.Email     = student.Email;

            return View(model);
        }
        
        public IActionResult UpdateStudent(Models.StudentModel studentModel)
        {
            student = context.Students.Where(std => studentModel.StudentId == std.StudentId).FirstOrDefault();

            student.StudentId = studentModel.StudentId;
            student.FirstName = studentModel.FirstName;
            student.LastName  = studentModel.LastName;
            student.Email     = studentModel.Email;

            context.SaveChanges();
            return RedirectToAction("GetAll");
        }
    }
}
