namespace EggStore.Domains.Users.Dto
{
    public class UsersDto
    {
        public Guid Id { get; set; } = default;
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
