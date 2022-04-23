using ECC.Models;
using ECC.Shared.Users.Contract;
using ECC.Users.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECC.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly DataContext _ctx;

        public PermissionsController(DataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetAsync()
        {
            var groupsDto = await _ctx.Groups.Select(x => new GroupDto { Id = x.Id, Name = x.Name }).ToListAsync();
            var permissionsDto = await _ctx.Permissions.Select(x => new PermissionDto { Id = x.Id, Name = x.Name }).ToListAsync();
            return Ok( new PermissionResponseDto { Groups = groupsDto, Permissions = permissionsDto });
        }

        [HttpGet("matrix")]
        public async Task<ActionResult> GetMatrixAsync()
        {
            var permissionMatrixDto = await _ctx.GroupPermissions
                .Select(x => new PermissionMatrixDto
                {
                    GroupId = x.GroupId,
                    PermissionId = x.PermissionId
                })
                .ToListAsync();
            return Ok(permissionMatrixDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddPermissionToGroupAsync([FromBody] PermissionRequestDto permissionRequestDto)
        {
            if (permissionRequestDto == null) return BadRequest();
            if (permissionRequestDto.GroupId == 0) return BadRequest();

            var groupPermissionsToBeDeleted = _ctx.GroupPermissions
                .Where(x => x.GroupId == permissionRequestDto.GroupId);

            _ctx.GroupPermissions.RemoveRange(groupPermissionsToBeDeleted);

            if (permissionRequestDto.PermissionIds.Length > 0)
            {
                List<GroupPermission> groupPermissionsToBeAdded = new List<GroupPermission>();

                foreach (var permissionId in permissionRequestDto.PermissionIds)
                {
                    groupPermissionsToBeAdded.Add(new GroupPermission
                    {
                        PermissionId = permissionId,
                        GroupId = permissionRequestDto.GroupId
                    });
                }
                _ctx.GroupPermissions.AddRange(groupPermissionsToBeAdded);
            }
            await _ctx.SaveChangesAsync();
            return Ok(permissionRequestDto);
        }
    }
}
