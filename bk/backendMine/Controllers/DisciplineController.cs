using Domain.Disciplina;
using Domain.Disciplina.DTO;
using Microsoft.AspNetCore.Mvc;
using MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace backendMine.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class DisciplineController:ControllerBase
    {
        private readonly IDatabase _database;
        public DisciplineController(IDatabase database) 
        { 
            _database = database;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DisciplinaDTO request,CancellationToken token)
        {

            var Collection = this._database.GetDbCollection<Disciplina>("Disciplina");
            Disciplina disciplina1 = new Disciplina
            {
                NumarCredite = request.NumarCredite,
                NumeDisciplina = request.NumeDisciplina,
                CodDisciplina = request.CodDisciplina,
                AcronimDisciplina = request.AcronimDisciplina
            };
            await Collection.InsertOneAsync(disciplina1);

            return Ok("Succes");
        }
      [HttpGet]
      public async Task<IActionResult> Get()
      {
      var Collection = this._database.GetDbCollection<Disciplina>("Disciplina");
      var filter = Builders<Disciplina>.Filter.Empty;
      var pointer = await Collection.FindAsync(filter);
      var actualData = await pointer.ToListAsync();
      return Ok(actualData);
    }
  }
}
