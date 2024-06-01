using Domain.AnStudiu;
using Domain.ProgramStudiu;
using Domain.ProgramStudiu.DTO;
using Domain.Semestru;
using Domain.Semestru.SemestruDTO;
using Microsoft.AspNetCore.Mvc;
using MongoDB;
using MongoDB.Driver;

namespace backendMine.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class ProgramStudioController : ControllerBase
  {
    private readonly IDatabase _database;
    public ProgramStudioController(IDatabase database)
    {
      _database = database;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProgramStudioRequest request, CancellationToken token)
    {
      ProgramStudiu program = new ProgramStudiu
      {
        Name = request.Name,
        AnStudii = request.AnStudii,
      };
      var Collection = this._database.GetDbCollection<ProgramStudiu>("ProgramStudiu");
      await Collection.InsertOneAsync(program, token);
      return Ok();

    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken token)
    {
      var Collection = this._database.GetDbCollection<ProgramStudiu>("ProgramStudiu");
     
       var data = await (await Collection.FindAsync(
          Builders<ProgramStudiu>.Filter.Empty
          )).ToListAsync(token)
        ; ;

      List<ProgramStudioResponse> responses = new List<ProgramStudioResponse>() ;

      foreach (var item in data)
      {
        //item.AnStudii id-urile anilor
        //noi vrem chiar anii
        //deci ne folosim de item.AnStudii sa filtram anii de studii din db dupa id
        var CollectionAnStudio= this._database.GetDbCollection<AnStudiu>("AnStudiu");
        var filter = Builders<AnStudiu>.Filter.In("Id", item.AnStudii);
        var pointer = await CollectionAnStudio.FindAsync(filter);
        var dataAni = await pointer.ToListAsync(token);

        responses.Add(new ProgramStudioResponse { AnStudii = dataAni , ProgramStudioName=item.Name, Id = item.Id });
      }
      return Ok(responses);

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id,CancellationToken token)
    {
      var Collection = this._database.GetDbCollection<ProgramStudiu>("ProgramStudiu");

      var data = await (await Collection.FindAsync(
         Builders<ProgramStudiu>.Filter.Eq(e=>e.Id,id)
         )).FirstOrDefaultAsync(token)
       ; ;

     
 
    
      return Ok(data);

    }


  }
}
