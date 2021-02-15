namespace Ruleta.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public bool success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }      
    }
}
