using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HospitalManagementSystem.Controllers
{
    public class AppointmentController : Controller
    {
        DBEntities.HospitalManagementSystemContext context = new DBEntities.HospitalManagementSystemContext();
        public IActionResult GetAll() {
            List<Models.AppointmentModel> list = new List<Models.AppointmentModel>();

            var FullList = context.AppointmentDates.Include(data => data.Doctor).ToList();

            //Include that enable you to get Doctor not just DoctorId
            list = (from data in FullList
              //same idea but that be more accure
                    select new Models.AppointmentModel
                    {
                        DoctorId = data.DoctorId,
                        DoctorName = data.Doctor.FirstName + " " + data.Doctor.LastName,
                    }
             ).DistinctBy(info => info.DoctorName).ToList();

            foreach (Models.AppointmentModel item in list){
                item.DoctorDetails = (from secondData in FullList.Where(secondData => secondData.DoctorId == item.DoctorId).ToList()
                        select new Models.AppointmentDetailsModel {
                                Day = secondData.Day,
                                EndTime = secondData.EndTime,
                                StartTime = secondData.StartTime,
                        }).ToList();
             }
            return View(list);
        }
    }
}
