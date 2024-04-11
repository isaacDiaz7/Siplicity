namespace Siplicity.Web.API.Responses
{
    /// <summary>
    /// The Base class for all our Response models. If it is going out the door from our Api it must
    /// inherit form here.
    /// </summary>
    public abstract class BaseResponse
    {
        public bool IsSuccessfull { get; set; }

        public string TransactionId { get; set; }

        public BaseResponse()
        {
            this.TransactionId = Guid.NewGuid().ToString();
        }
    }
}
