using Siplicity.Web.API.Interface;

namespace Siplicity.Web.API.Models
{
    public class UserUpdateRequest : UserAddRequest, IModelIdentifier
    {
        public int Id { get; set; }
    }
}
