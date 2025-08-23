using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class DoctorModel
    {
        public int DoctorId { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="This Filed is required")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Filed is required")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Filed is required")]
        public bool Gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Filed is required")]
        public DateOnly JoinDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Filed is required")]
        public decimal Salary { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Filed is required")]
        public string Mobile { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Filed is required")]
        public int ShiftTypeId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Filed is required")]
        public int SpecializationId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Filed is required")]
        public int YearsOfExperience { get; set; }

        public bool IsDeleted { get; set; }

        public string ShiftName { get; set; }

        public string SpecializationName { get; set;}

        public string GenderName { get; set; }

    }
}
