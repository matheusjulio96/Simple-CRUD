namespace Simple_CRUD.Infrastructure
{
    public class CommandResponse<T> : CommandResponse
    {
        public T Data { get; set; }
    }
    public class CommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
