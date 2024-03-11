using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siplicity.Web.API.DataAccessLayer;
using Siplicity.Web.API.Models;

namespace Siplicity.Web.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private User_DAL _dal;

        public UserController(User_DAL dal)
        {
            _dal = dal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            int code = 200;
            List<User> users = new List<User>();
            Object response = null;
            

            try
            {
                users = _dal.GetAllUser();

                if(users == null)
                {
                    code = 404;
                    response = NotFound();
                 
                }
                else
                {
                    response = users;
                }
            }
            catch(Exception ex)
            {
                code = 500;
                response = BadRequest(ex.Message);
                
            }
            return StatusCode(code, response);
        }

        [HttpPost]
        public IActionResult Create(UserAddRequest request) 
        {
            int code = 201;
            ObjectResult result = null;


            try
            {
                int id = _dal.Add(request);
                result = StatusCode(201, id);

            }
            catch (Exception ex)
            {

                result = StatusCode(500, ex.ToString());
            }
            return result;
        }
    }
}
