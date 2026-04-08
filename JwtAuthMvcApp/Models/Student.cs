namespace JwtAuthMvcApp.Models
{
    public class Student
    {
        
        public int StudentId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
        public string course { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime Createddate { get; set; }
    }
}
