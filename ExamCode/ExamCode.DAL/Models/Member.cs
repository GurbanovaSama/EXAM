namespace ExamCode.DAL.Models
{
    public class Member : BaseEntity
    {
        public string Name { get; set; }        
        public string Surname { get; set; }     
        public string Position { get; set; }        
        public string ImageUrl { get; set; }        
        public int  PlanId { get; set; }        
        public Plan? Plan { get; set; }     
    }
}
