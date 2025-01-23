using Microsoft.AspNetCore.Http;

namespace ExamCode.BL.DTOs;

public record  MemberListItemDto
{
    public int Id { get; set; }     
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Position { get; set; }
    public IFormFile Image { get; set; }
}
