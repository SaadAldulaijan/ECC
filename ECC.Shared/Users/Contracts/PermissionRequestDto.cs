namespace ECC.Shared.Users.Contract
{
    public record PermissionRequestDto
    {
        public int GroupId { get; set; }
        public int[] PermissionIds { get; set; }
    }
}
