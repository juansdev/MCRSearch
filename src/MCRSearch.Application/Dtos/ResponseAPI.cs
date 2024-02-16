using System.Net;

namespace MCRSearch.src.MCRSearch.Application.Dtos
{
    public class ResponseAPI
    {
        public ResponseAPI()
        {
            ErrorMessages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}
