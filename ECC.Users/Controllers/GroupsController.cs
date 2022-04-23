using ECC.Models;
using ECC.Shared.Users.Contracts;
using ECC.Users.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECC.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly DataContext _ctx;
        public GroupsController(DataContext ctx)
        {
            _ctx = ctx;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupResponseDto>>> GetAsync()
        {
            var groups = await _ctx.Groups
                .Include(x => x.Users)
                .Select(x => new GroupResponseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Users = x.Users.Select(x => new UserResponseDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Email = x.Email,
                        Position = x.Position,
                        GroupId = x.GroupId,
                    })
                })
                .ToListAsync();
            return Ok(groups);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var groups = await _ctx.Groups
                .Where(x => x.Id == id)
                .Include(x => x.Users)
                .Select(x => new GroupResponseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Users = x.Users.Select(x => new UserResponseDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Email = x.Email,
                        Position = x.Position,
                        GroupId = x.GroupId,
                    })
                })
                .FirstOrDefaultAsync();
            return Ok(groups);
        }

        [HttpPost]
        public async Task<ActionResult> Post(GroupRequestDto groupRequestDto)
        {
            if (groupRequestDto == null) return BadRequest();
            _ctx.Groups.Add(new Group { Name = groupRequestDto.Name });
            await _ctx.SaveChangesAsync();

            return Ok("Created");
        }
    }
}
