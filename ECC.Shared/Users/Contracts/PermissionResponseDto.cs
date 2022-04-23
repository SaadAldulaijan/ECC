namespace ECC.Shared.Users.Contract
{
    public record PermissionResponseDto
    {
        public List<GroupDto> Groups { get; set; }
        public List<PermissionDto> Permissions { get; set; }
    }
}
