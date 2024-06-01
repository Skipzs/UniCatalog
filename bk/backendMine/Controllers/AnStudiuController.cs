using Domain.Semestru.SemestruDTO;
using Domain.Semestru;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.AnStudiu;
using Domain.AnStudiu.AnStudiuDTO;
using Domain.Disciplina.DTO;
using Domain.Disciplina;
using MongoDB;
using MongoDB.Driver;

namespace backendMine.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class AnStudiuController : ControllerBase
  {
    private readonly IDatabase _database;

    public AnStudiuController(IDatabase database)
    {
      this._database = database;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AnStudiuDTO request, CancellationToken token)
    {

      var Collection = this._database.GetDbCollection<AnStudiu>("AnStudiu");
      AnStudiu anstudiu = new AnStudiu
      {
        NumeAnStudiu = request.NumeaAnStudiu,
        Semestre = request.Semestre,
      };
      await Collection.InsertOneAsync(anstudiu);

      return Ok("Succes");

    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var response = new List<AnStudiuResponse>();
      var Collection = this._database.GetDbCollection<AnStudiu>("AnStudiu");
      var filter = Builders<AnStudiu>.Filter.Empty;
      var pointer = await Collection.FindAsync(filter);
      var data = await pointer.ToListAsync();

      foreach(var item in data)
      {
        var CollectionSemester = this._database.GetDbCollection<Semestru>("Semestru");
        var filterSemester = Builders<Semestru>.Filter.In("Id", item.Semestre);
        var pointerSemester = await CollectionSemester.FindAsync(filterSemester);
        var semesterList = await pointerSemester.ToListAsync();
       
        var obj = new AnStudiuResponse
        {
          AnStudiuName = item.NumeAnStudiu,
          Semestre = semesterList,
        };
        response.Add(obj);
      }
      return Ok(response);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById(string id)
    {
      var Collection = this._database.GetDbCollection<AnStudiu>("AnStudiu");
      var filter = Builders<AnStudiu>.Filter.Eq(x=>x.Id,id);
      var pointer = await Collection.FindAsync(filter);
      var data = await pointer.FirstOrDefaultAsync();

        var CollectionSemester = this._database.GetDbCollection<Semestru>("Semestru");
        var filterSemester = Builders<Semestru>.Filter.In("Id", data.Semestre);
        var pointerSemester = await CollectionSemester.FindAsync(filterSemester);
        var semesterList = await pointerSemester.ToListAsync();

        var obj = new AnStudiuResponse
        {
          AnStudiuName = data.NumeAnStudiu,
          Semestre = semesterList,
        };
 
      return Ok(obj);
    }

  }
}
