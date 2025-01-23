using System.ComponentModel.DataAnnotations;

namespace ExamCode.BL.DTOs.UserDTOs
{
   public record LoginDto
    {
        [Display(Prompt = "Username")]
        public string Username { get; set; }

        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
