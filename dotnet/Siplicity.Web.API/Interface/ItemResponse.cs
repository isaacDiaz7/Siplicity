namespace Siplicity.Web.API.Interface
{
    public interface IItemResponse
    {
        bool IsSuccessfull { get; set; }

        string TransactionId { get; set; }

        object Item { get; }
    }
}
