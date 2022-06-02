namespace EggStore.Infrastucture.Helpers.ResponseBuilders
{
    public class ResponseFormat
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public dynamic Errors { get; set; }
    }
}
