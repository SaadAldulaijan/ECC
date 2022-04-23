namespace ECC.Shared.Users.Contract
{
    public record PermissionMatrixDto
    {
        public int GroupId { get; set; }
        public int PermissionId { get; set; }
    }
}
