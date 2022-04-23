using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC.Shared.Users.Contracts
{
    public record UserRequestDto
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string Position { get; init; }
        public int GroupId { get; init; }
    }
}
