using Siplicity.Web.API.Models;

namespace Siplicity.Web.API.Interface
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        int Add(UserAddRequest request);
        void Update(UserUpdateRequest request, int id);
        void Delete(int id);
        Paged<User> GetPaginated(int pageIndex, int pageSize);
        Paged<User> GetSearchPaginated(int pageIndex, int pageSize, string query);
    }
}