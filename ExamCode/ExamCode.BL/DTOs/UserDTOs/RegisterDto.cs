using System.ComponentModel.DataAnnotations;

namespace ExamCode.BL.DTOs.UserDTOs
{
    public record  RegisterDto
    {
        [Display(Prompt = "Username")]
        public string Username { get; set; }
        [Display(Prompt = "Email")]
        public string Email { get; set; }
        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
        [Display(Prompt = "confirmPaswword")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }     
    }
}
