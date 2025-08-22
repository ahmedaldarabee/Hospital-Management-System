using System.ComponentModel.DataAnnotations;

namespace DesignUI.Models
{
    public class StudentModel {

        [Required(AllowEmptyStrings =false,ErrorMessage ="This field is required")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string LastName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Email { get; set; }

        public int StudentId { get; set; }
    }
}
