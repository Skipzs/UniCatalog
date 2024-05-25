using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProgramStudiu.DTO
{
  public class ProgramStudioResponse
  {
    public string ProgramStudioName { get; set; }

    public string Id { get; set; }

    public List<Domain.AnStudiu.AnStudiu> AnStudii { get; set; }
  }
}
