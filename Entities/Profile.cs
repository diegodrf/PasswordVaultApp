using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime LastModifiedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
        [Required]
        public required int UserId { get; set; }

        // Relationship
        [JsonIgnore]
        public User User { get; set; } = null!;
    }
}
