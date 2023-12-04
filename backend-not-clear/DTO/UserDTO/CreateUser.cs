namespace backend_not_clear.DTO.UserDTO
{
    public class CreateUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        public string Fullname { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
    }
}
