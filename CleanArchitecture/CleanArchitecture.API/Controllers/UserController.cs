using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.UseCases;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly CreateUserUseCase _createUserUseCase;
        private readonly IUserRepository _userRepository;

        public UserController(CreateUserUseCase createUserUseCase, IUserRepository userRepository)
        {
            _createUserUseCase = createUserUseCase;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            try
            {
                var userResult = await _createUserUseCase.Execute(user.Name.ToString(), user.Email.ToString());
                return CreatedAtAction(nameof(GetUsers), new { id = userResult.Id }, userResult);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetAll();
            return Ok(users);
        }
    }
}