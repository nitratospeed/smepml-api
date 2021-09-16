namespace Application.Common.Models
{
    public class BaseApiResponse<TDataTransferObject>
    {
        public bool IsSuccess { get; set; }

        public TDataTransferObject Data { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }

        public string[] ValidationErrors { get; set; }
    }
}
