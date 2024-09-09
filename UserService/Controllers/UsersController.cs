using Microsoft.AspNetCore.Mvc;
using UserService.Data;
using UserService.Models;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserDbContext _dbContext;

        public UsersController(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_dbContext.Users.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<IEnumerable<User>> CreateUsers(IEnumerable<User> users)
        {
            _dbContext.Users.AddRange(users);
            _dbContext.SaveChanges();

            // Return the list of created users with their new IDs
            return CreatedAtAction(nameof(GetUsers), null, users);
        }
    }



}
