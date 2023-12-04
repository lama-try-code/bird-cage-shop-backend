using System.ComponentModel.DataAnnotations;

namespace backend_not_clear.DTO.UserDTO
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        [EmailAddress]
        public string? Email { get; set; }
    }
}
