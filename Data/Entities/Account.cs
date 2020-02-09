using System;

namespace Data.Entities
{
    public class Account : BaseEntity
    {
        public string AccountNumber { get; set; }
        public string AccountTitle { get; set; }
        public double CurrentBalance { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}
