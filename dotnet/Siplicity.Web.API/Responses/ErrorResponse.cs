namespace Siplicity.Web.API.Responses
{
    public class ErrorResponse : BaseResponse
    {
        public List<String> Errors { get; set; }

        public ErrorResponse(string errMsg)
        {
            Errors = new List<string>();

            Errors.Add(errMsg);
            this.IsSuccessfull = false;
        }

        public ErrorResponse(IEnumerable<String> errMsg)
        {
            Errors = new List<string>();

            Errors.AddRange(errMsg);
            this.IsSuccessfull = false;
        }
    }
}
