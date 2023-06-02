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
    public class User
    {
        public int Id { get; set; }
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string PasswordHash { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }

        // Relationship
        [JsonIgnore]
        public List<Profile> Profiles { get; set; } = new();
    }
}
