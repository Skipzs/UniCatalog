using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
  public class UserDto
  {
    public string? ProgramStudiu { get; set; }

    public string? CicluInvatamant { get; set; }

    public string? AnStudiu { get; set; }

    public string? Semestru { get; set; }

    public string Email { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public short Age { get; set; } = 18;

    public string CNP { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
  }
}
