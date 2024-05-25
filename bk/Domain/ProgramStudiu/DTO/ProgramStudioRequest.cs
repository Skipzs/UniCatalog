using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProgramStudiu.DTO
{
  public class ProgramStudioRequest
  {
    public string Name { get; set; } = string.Empty;

    public List<string> AnStudii { get; set; } = new List<string>();
  }
}
