using Microsoft.AspNetCore.Http;

namespace ExamCode.BL.DTOs;
    public record  MemberViewItemDto
    {
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Position { get; set; }
    public IFormFile Image { get; set; }
}

