using AutoMapper;
using ECC.Models;
using ECC.Shared.Users.Contracts;
using ECC.Users.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECC.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public UsersController(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAsync()
        {
            var users = await _ctx.Users
                .Include(x => x.Group)
                .ToListAsync();

            var userResponseDto =  _mapper.Map<IEnumerable<UserResponseDto>>(users);

            return Ok(userResponseDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDto>> GetAsync(int id)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(x => x.Id == id);
            var userResponseDto = _mapper.Map<UserResponseDto>(user);
            return Ok(userResponseDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> Post(User user)
        {
            if (user is null)
            {
                return BadRequest();
            }

            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
            return Ok(_mapper.Map<UserResponseDto>(user));
        } 
    }
}
