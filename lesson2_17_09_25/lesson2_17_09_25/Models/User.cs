using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using lesson2_17_09_25.Enums;

namespace lesson2_17_09_25.Models;
    public class User
    {
        public int Id { get; set; }
        //[Required]
        //[MaxLength(50)]
         public string Login { get; set; }
        //[EmailAddress]
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        [JsonIgnore]
        public Student? Student { get; set; }

    }
