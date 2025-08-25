namespace HospitalManagementSystem.Models
{
    public class AppointmentModel{

        public int DoctorId { get; set; }

        public string DoctorName { get; set; }

        // each doctor that have list of details! HOW THIS SECTION WORK?
        public List <AppointmentDetailsModel> DoctorDetails { get; set; }
    }

    public class AppointmentDetailsModel{
        public string Day { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}
