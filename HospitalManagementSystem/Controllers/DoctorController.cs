using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Controllers
{
    public class DoctorController : Controller {
        DBEntities.HospitalManagementSystemContext context = new DBEntities.HospitalManagementSystemContext();

        public IActionResult Add() {
            // ViewBag to move data from controller into view directly
            ViewBag.shift = (
                // get all data from this table: ShiftTypes
                from data in context.ShiftTypes.ToList()                
                // the next section just to select ShiftTypeId and ShiftName from ShiftTypes Table
                
                select new {
                    Id = data.ShiftTypeId,
                    Name = data.ShiftName,
                }

            ).ToList();


            ViewBag.Specialization = (
               from data in context.Specializations.ToList()
               select new
               {
                   Id = data.SpecializationId,
                   Name = data.SpecializationName,
               }

           ).ToList();


            return View();
        }

        // this action that take data from view and store it into database
        public IActionResult AddNewDoctor(Models.DoctorModel model){
            try {
                DBEntities.Doctor doctor = new DBEntities.Doctor();

                doctor.FirstName = model.FirstName;
                doctor.LastName = model.LastName;
                doctor.Gender = model.Gender;

                doctor.JoinDate = model.JoinDate;
                doctor.Salary = model.Salary;
                doctor.Mobile = model.Mobile;
                doctor.ShiftTypeId = model.ShiftTypeId;

                doctor.SpecializationId = model.SpecializationId;
                doctor.YearsOfExperience = model.YearsOfExperience;

                context.Doctors.Add(doctor);
                context.SaveChanges();
                return RedirectToAction("GetAll");

            }
            catch (Exception ex) {
                context = new DBEntities.HospitalManagementSystemContext();
                DBEntities.Error errorObj = new DBEntities.Error();
                errorObj.TransactionDate = DateTime.Now;

                if (ex.InnerException != null){
                    errorObj.InnerException = ex.InnerException.ToString();
                }

                if(ex.Message != null){
                    errorObj.ErrorMessage = ex.Message;
                }

                errorObj.StackTrace = ex.StackTrace;
                context.Errors.Add(errorObj);
                context.SaveChanges();
                return RedirectToAction("ErrorLog", "Home");

            }

        }


        public IActionResult Edit(int id){
            // all data that hold this sent id!
            var result = context.Doctors.Where(data => data.DoctorId == id).FirstOrDefault();

            Models.DoctorModel doctorModel = new Models.DoctorModel();

            doctorModel.DoctorId          = result.DoctorId;
            doctorModel.FirstName         = result.FirstName;
            doctorModel.LastName          = result.LastName;

            doctorModel.Gender = result.Gender;
            doctorModel.JoinDate          = result.JoinDate;
            doctorModel.Mobile            = result.Mobile;

            doctorModel.Salary            = result.Salary;
            doctorModel.ShiftTypeId       = result.ShiftTypeId;
            doctorModel.SpecializationId  = result.SpecializationId;
            doctorModel.YearsOfExperience = result.YearsOfExperience;

            //to get selected data from drop-down list
            ViewBag.shift = (
                from data in context.ShiftTypes.ToList()
                select new {
                    Id = data.ShiftTypeId,
                    Name = data.ShiftName,
                }
            ).ToList();


            ViewBag.Specialization = ( 
               from data in context.Specializations.ToList()
               select new {
                   Id = data.SpecializationId,
                   Name = data.SpecializationName,
               }
           ).ToList();

            return View(doctorModel);
        }

        public IActionResult Delete(int id) {
            var result = context.Doctors.Where(data => data.DoctorId == id).FirstOrDefault();
            result.IsDeleted = true;
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }


        // this section that read data from database then
        public IActionResult GetAll(){
            // Empty list that store doctor information that coming from database
            List<Models.DoctorModel> doctorList = new List<Models.DoctorModel>();
            doctorList = (

                //LINQ Section, and to get main table data + data that exist in another table
                from data in context.Doctors.
                    Where(data => !data.IsDeleted).
                    Include(data => data.ShiftType).
                    Include(data => data.Specialization).ToList()

                    //Projection Section, where select needed column from overall data
                select new Models.DoctorModel
                {
                    DoctorId = data.DoctorId,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    GenderName = data.Gender ? "Male" : "Female",
                    JoinDate = data.JoinDate,
                    Mobile = data.Mobile,
                    ShiftName = data.ShiftType.ShiftName,
                    SpecializationName = data.Specialization.SpecializationName,
                    Salary = data.Salary,
                    YearsOfExperience = data.YearsOfExperience,
                }).ToList(); // error is here?

            // show data section
            return View(doctorList);
        }
        
        public IActionResult UpdateDoctor(Models.DoctorModel model)
        {
            DBEntities.Doctor doctor = new DBEntities.Doctor();

            //section about update
            doctor = context.Doctors.Where(data => data.DoctorId == model.DoctorId).FirstOrDefault();

            doctor.FirstName = model.FirstName;
            doctor.LastName = model.LastName;
            doctor.Gender = model.Gender;

            doctor.JoinDate = model.JoinDate;
            doctor.Salary = model.Salary;
            doctor.Mobile = model.Mobile;
            doctor.ShiftTypeId = model.ShiftTypeId;

            doctor.SpecializationId = model.SpecializationId;
            doctor.YearsOfExperience = model.YearsOfExperience;

            context.SaveChanges();
            return RedirectToAction("GetAll");
        }
    }
}
