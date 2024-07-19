using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAssignment.DTOs
{
    public record UpdateRoleDto
    {
      public required string Description{get;set;}

    }
}