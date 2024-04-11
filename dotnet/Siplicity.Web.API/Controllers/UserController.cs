using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siplicity.Web.API.DataAccessLayer;
using Siplicity.Web.API.Interface;
using Siplicity.Web.API.Models;
using Siplicity.Web.API.Responses;

namespace Siplicity.Web.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private IUserService _service = null;

        public UserController(IUserService service, ILogger<UserController> logger) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ItemsResponse<User>> GetAll()
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                List<User> list = _service.GetAll();

                if (list == null)
                {
                    code = 404;
                    response = new ErrorResponse("App resource not found");
                }
                else
                {
                    response = new ItemsResponse<User> { Items = list };

                }
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
                Logger.LogError(ex, ex.Message);
            }

            return StatusCode(code, response);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ItemResponse<User>> GetById(int id) 
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                User user = _service.GetById(id);
                if (user == null)
                {
                    code = 404;
                    response = new ErrorResponse("Application resource not found");
                }
                else
                {
                    response = new ItemResponse<User> { Item = user };
                }
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
                Logger.LogError(ex, ex.Message);
            }

            return StatusCode(code, response);
        }

        [HttpGet("paginated")]
        public ActionResult<ItemResponse<Paged<User>>> GetPaginated(int pageIndex, int pageSize)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                Paged<User> paged = _service.GetPaginated(pageIndex, pageSize);
                if (paged == null)
                {
                    code = 404;
                    response = new ErrorResponse("Not Found");
                }
                else
                {
                    response = new ItemResponse<Paged<User>>() { Item = paged };
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                code = 500;
                response = new ErrorResponse(ex.Message.ToString());
            }

            return StatusCode(code, response);
        }

        [HttpGet("search")]
        public ActionResult<ItemResponse<Paged<User>>> GetSearchPaginated(int pageIndex, int pageSize, string query)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                Paged<User> paged = _service.GetSearchPaginated(pageIndex, pageSize, query);
                if (paged == null)
                {
                    code = 404;
                    response = new ErrorResponse("Not Found");
                }
                else
                {
                    response = new ItemResponse<Paged<User>>() { Item = paged };
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                code = 500;
                response = new ErrorResponse(ex.Message.ToString());
            }

            return StatusCode(code, response);
        }

        [HttpPost]
        public ActionResult<ItemResponse<int>> Add(UserAddRequest request)
        {
            ObjectResult result = null;

            try
            {
                int id = _service.Add(request);
                ItemResponse<int> response = new ItemResponse<int>();

                result = Created201(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                ErrorResponse response = new ErrorResponse(ex.Message);

                result = StatusCode(500, response);
            }

            return result;
        }

        [HttpPut("{id:int}")]
        public ActionResult<int> Update(UserUpdateRequest request, int id)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                _service.Update(request, id);

                response = new SuccessResponse();
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
            }
            return StatusCode(code, response);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<SuccessResponse> Delete(int id)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                _service.Delete(id);
                response = new SuccessResponse();
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
            }

            return StatusCode(code, response);
        }
        
    }
}
