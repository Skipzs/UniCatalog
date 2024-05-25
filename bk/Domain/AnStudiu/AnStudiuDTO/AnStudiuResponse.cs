using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AnStudiu.AnStudiuDTO
{
  public class AnStudiuResponse
  {
    public string AnStudiuName { get; set; } = string.Empty;

    public List<Domain.Semestru.Semestru> Semestre { get; set; } = new ();
  }
}
