using System;

namespace Ijora.Domain.Interactions.Users.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime SingUpDate { get; set; }
    }
}
