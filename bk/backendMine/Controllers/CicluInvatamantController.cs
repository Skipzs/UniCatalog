using Domain.AnStudiu;
using Domain.CicluInvatamant;
using Domain.Disciplina;
using Domain.ProgramStudiu;
using Domain.ProgramStudiu.DTO;
using Microsoft.AspNetCore.Mvc;
using MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backendMine.Controllers
{
  [Route("api/[controller]")]
    [ApiController]

    public class CicluInvatamantController: ControllerBase
    {
        private readonly IDatabase _database;
       public CicluInvatamantController(IDatabase database)
        {
            _database = database;
        }

    [HttpPost]
    public async Task<IActionResult> Create(CicluInvatamantDto request, CancellationToken token)
    {
      var Collection = this._database.GetDbCollection<CicluInvatamant>("CicluInvatamant");
      CicluInvatamant cicluInvatamant = new CicluInvatamant
      {
        Nume = request.Nume,
        ProgramStudiuIds = request.ProgramStudiuIds,
      };
      await  Collection.InsertOneAsync(cicluInvatamant, token);

      return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken token)
    {
      var Collection = this._database.GetDbCollection<CicluInvatamant>("CicluInvatamant");

      var data = await (await Collection.FindAsync(Builders<CicluInvatamant>.Filter.Empty)).ToListAsync();

      List<CicluInvatamantDtoResponse> response = new List<CicluInvatamantDtoResponse>();

      foreach (var item in data)
      {
        //item.programstidiuids id-urile anilor
        //noi vrem chiar anii
        //deci ne folosim de item.AnStudii sa filtram anii de studii din db dupa id
        var CollectionProgramStudio = this._database.GetDbCollection<ProgramStudiu>("ProgramStudiu");
        var filter = Builders<ProgramStudiu>.Filter.In("Id", item.ProgramStudiuIds);
        var pointer = await CollectionProgramStudio.FindAsync(filter);
        var dataAni = await pointer.ToListAsync(token);

        response.Add(new CicluInvatamantDtoResponse { ProgramStudiuIds = dataAni, Nume = item.Nume, Id = item.Id });
      }
      return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id, CancellationToken token)
    {
      var Collection = this._database.GetDbCollection<CicluInvatamant>("CicluInvatamant");

      var data = await (await Collection.FindAsync(Builders<CicluInvatamant>.Filter.Empty)).FirstOrDefaultAsync(token);

      CicluInvatamantDtoResponse response =new CicluInvatamantDtoResponse();


        var CollectionProgramStudio = this._database.GetDbCollection<ProgramStudiu>("ProgramStudiu");
        var filter = Builders<ProgramStudiu>.Filter.In("Id", data.ProgramStudiuIds);
        var pointer = await CollectionProgramStudio.FindAsync(filter);
        var dataAni = await pointer.ToListAsync(token);
      response.Nume = data.Nume;
      response.Id = data.Id;
      response.ProgramStudiuIds = dataAni;
      return Ok(response);
    }
  }
}
