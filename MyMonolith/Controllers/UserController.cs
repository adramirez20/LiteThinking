using Microsoft.AspNetCore.Mvc; using Microsoft.EntityFrameworkCore; [ApiController] [Route("api/users")] public class UserController : ControllerBase { private readonly StoreContext context; public UserController(StoreContext context) => context = context; [HttpGet] public IActionResult GetUsers() { var users = context.Users.ToList(); return Ok(users); } [HttpPost] public IActionResult AddUser([FromBody] User user) { user.CreatedAt = DateTime.UtcNow; context.Users.Add(user); _context.SaveChanges(); return CreatedAtAction (nameof (GetUsers),new {id = user.Id}, user); } }

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

[ApiController]

[Route("api/users")]

public class UserController : ControllerBase

{

private readonly StoreContext _context;

public UserController(StoreContext context) => _context = context;

 [HttpGet]

public IActionResult GetUsers()

 {

var users = _context.Users.ToList();

return Ok(users);

 }

 [HttpPost]

public IActionResult AddUser([FromBody] User user)

 {

user.CreatedAt = DateTime.UtcNow;

_context.Users.Add(user);

_context.SaveChanges();

return CreatedAtAction (nameof (GetUsers),new {id = user.Id}, user);

 }

}