using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Domain.Login;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB;

namespace backendMine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IDatabase _database;
        private readonly IMongoCollection<Login> _login;

        public LoginController(IDatabase database)
        {
            _database = database;
            _login = this._database.GetDbCollection<Login>("Login");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _login.Find(_ => true).ToListAsync();
            return Ok(users);
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateUser([FromBody] Login login)
        {
            var user = await _login.Find(u => u.Username == login.Username && u.Password == login.Password).FirstOrDefaultAsync();
            if (user != null)
            {
                return Ok(true);
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LoginDTO request, CancellationToken token)
        {
            var Collection = this._database.GetDbCollection<Login>("Login");
            Login user = new Login
            {
                Username = request.Username,
                Password = request.Password
            };
            await Collection.InsertOneAsync(user);

            return Ok("Success");
        }


    }
}
