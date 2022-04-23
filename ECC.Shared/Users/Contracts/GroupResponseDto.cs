namespace ECC.Shared.Users.Contracts
{
    public record GroupResponseDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public IEnumerable<UserResponseDto> Users { get; set; }
    }
}
