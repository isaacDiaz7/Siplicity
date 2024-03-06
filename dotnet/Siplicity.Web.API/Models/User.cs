using System.ComponentModel.DataAnnotations;

namespace Siplicity.Web.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? Mi { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public int StatusId { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
