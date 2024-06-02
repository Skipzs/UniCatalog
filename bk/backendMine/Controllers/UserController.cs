using Domain.CicluInvatamant;
using Domain.Users;
using Microsoft.AspNetCore.Mvc;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace backendMine.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IDatabase _database;
    private readonly IMongoCollection<User> _users;
    public UserController(IDatabase database)
    {
      _database = database;
      _users = this._database.GetDbCollection<User>("User");

    }

    [HttpPost]
    public async Task<IActionResult> Create(Domain.Users.UserDto request, CancellationToken cancellationToken)
    {
      if (request == null)
      {
        return BadRequest();
      }

      User user = new User
      {
        CNP = request.CNP,
        Age
        = request.Age,
        AnStudiu = request.AnStudiu,
        CicluInvatamant = request.CicluInvatamant,
        Email = request.Email,
        FirstName = request.FirstName,
        LastName = request.LastName,
        PhoneNumber = request.PhoneNumber,
        ProgramStudiu = request.ProgramStudiu,
        Semestru = request.Semestru,
      };
      await _users.InsertOneAsync(user, cancellationToken);

      return this.Ok(user.Id);
    }

    [HttpGet("{ciclu}/{program}/{an}/{semestru}/")]
    public async Task<IActionResult> Get(string? ciclu, string? program, string? an, string? semestru, CancellationToken token)
    {
      var filters = new List<FilterDefinition<User>>();

      if (!string.IsNullOrEmpty(ciclu))
      {
        filters.Add(Builders<User>.Filter.Eq(x => x.CicluInvatamant, ciclu));
      }
      if (!string.IsNullOrEmpty(program))
      {
        filters.Add(Builders<User>.Filter.Eq(x => x.ProgramStudiu, program));
      }
      if (!string.IsNullOrEmpty(an))
      {
        filters.Add(Builders<User>.Filter.Eq(x => x.AnStudiu, an));
      }
      if (!string.IsNullOrEmpty(semestru))
      {
        filters.Add(Builders<User>.Filter.Eq(x => x.Semestru, semestru));
      }

      var combinedFilter = filters.Count > 0 ? Builders<User>.Filter.And(filters) : Builders<User>.Filter.Empty;

      var usersCursor = await this._users.FindAsync(combinedFilter, cancellationToken: token);
      var usersList = await usersCursor.ToListAsync();

      return Ok(usersList);
    }

  }
}
