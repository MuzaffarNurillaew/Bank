using Bank.Domain.Commons;

namespace Bank.Domain.Entities
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Age { get; set; }
        public decimal Balance { get; set; }
    }
}
