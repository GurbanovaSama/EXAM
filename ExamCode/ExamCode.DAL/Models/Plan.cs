namespace ExamCode.DAL.Models
{
    public class Plan : BaseEntity
    {
        public string Name { get; set; }    
        public string Description { get; set; }
        public decimal Price { get; set; }      
        public ICollection<Member>? Members { get; set; }        

    }
}
