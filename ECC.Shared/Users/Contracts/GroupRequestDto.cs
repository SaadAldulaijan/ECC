using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC.Shared.Users.Contracts
{
    public record GroupRequestDto
    {
        public string Name { get; init; }
    }
}
