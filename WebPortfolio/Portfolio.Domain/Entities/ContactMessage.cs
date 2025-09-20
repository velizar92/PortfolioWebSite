namespace Portfolio.Domain.Entities
{
    public class ContactMessage
    {
        public int Id { get; set; }
        public string FirstName { get; set; }    
        public string LastName { get; set; }    
        public string Email { get; set; }   
        public string Message { get; set; } 
        public DateTime SentDate { get; set; } 
    }
}
