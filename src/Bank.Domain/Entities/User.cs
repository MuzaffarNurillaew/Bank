using Bank.Domain.Commons;

namespace Bank.Domain.Entities
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set;  }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
    }
}
