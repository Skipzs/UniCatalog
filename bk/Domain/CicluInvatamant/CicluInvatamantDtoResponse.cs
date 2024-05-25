using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CicluInvatamant
{
  public class CicluInvatamantDtoResponse
  {
    public string Id { get; set; }

    public string Nume { get; set; }
    public List<Domain.ProgramStudiu.ProgramStudiu> ProgramStudiuIds { get; set; }
  }
}
