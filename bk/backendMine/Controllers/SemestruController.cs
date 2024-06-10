using Domain.Disciplina.DTO;
using Domain.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Semestru.SemestruDTO;
using Domain.Semestru;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB;

namespace backendMine.Controllers
{

  [Route("api/[controller]")]
    [ApiController]
    public class SemestruController : ControllerBase
    {
        private readonly IDatabase _database;
        public SemestruController(IDatabase database)
        {
            _database = database;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SemestruDTO request, CancellationToken token)
        {

            var Collection = this._database.GetDbCollection<Semestru>("Semestru");
            Semestru semestru1 = new Semestru
            {
                NumeSemestru = request.NumeSemestru,
                Discipline = request.Discipline,
            };
            await Collection.InsertOneAsync(semestru1);

            return Ok("Succes");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get( string  id, CancellationToken token)
        {
            var Collection = this._database.GetDbCollection<Semestru>("Semestru");
            var Filter = Builders<Semestru>.Filter.Eq("Id", id);
            var Response = await Collection.FindAsync(Filter);
            var semestru = await Response.FirstOrDefaultAsync();

            var CollectionDiscipline = this._database.GetDbCollection<Disciplina>("Disciplina");
            var FilterDiscipline = Builders<Disciplina>.Filter.In("Id", semestru.Discipline);
            var ResponseDiscipline = await CollectionDiscipline.FindAsync(FilterDiscipline);
            var discipline = await ResponseDiscipline.ToListAsync();


            var finalresponse = new SemestruResponse
            {
                NumeSemestru = semestru.NumeSemestru,
                Discipline = discipline
            };
            return Ok(finalresponse);


        }

    }
}
