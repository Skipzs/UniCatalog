using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Semestru.SemestruDTO
{
    public class SemestruResponse
    {
       public string NumeSemestru { get; set; }
       public List <Domain.Disciplina.Disciplina> Discipline { get; set; }

    }
}
