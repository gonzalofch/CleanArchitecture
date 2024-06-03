using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using PizzaBlazor.Shared.DtoModels;

namespace PizzaBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult AdminGetUsers()
        {
            var users = _unitOfWork.User.GetAll().ToList();
            return Ok(users);
        }

        [HttpPut("{guid}")]
        public IActionResult UpdateUser(Guid guid, [FromBody] UserDTO updatedUser)
        {
            if (updatedUser == null || guid != updatedUser.UserId)
            {
                return BadRequest();
            }

            var user = _unitOfWork.User.GetByGuid(guid);
            if (user == null)
            {
                return NotFound();
            }

            user.FullName = updatedUser.FullName;
            user.Email = updatedUser.Email;
            user.UserName = updatedUser.UserName;
            user.Password = updatedUser.Password;


            _unitOfWork.User.Update(user);
            _unitOfWork.Complete();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(UserDTO user)
        {
            UserInfo newUser = new UserInfo(user.UserId, user.FullName, user.Email, user.Password, user.UserName, user.PhoneNumber);
            _unitOfWork.User.Add(newUser);
            _unitOfWork.Complete();
            return Ok(newUser);
        }

    }
}
