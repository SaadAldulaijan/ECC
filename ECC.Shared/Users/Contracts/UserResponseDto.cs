namespace ECC.Shared.Users.Contracts
{
    public record UserResponseDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public string Position { get; init; }
        public string GroupName { get; set; }
        public int GroupId { get; init; }

    }
}
