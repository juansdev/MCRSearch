using System.Net;

namespace MCRSearch.src.SharedDtos
{
    public class ResponseAPI<T>
    {
        public ResponseAPI()
        {
            ErrorMessages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
        public T Result { get; set; }
    }
}
