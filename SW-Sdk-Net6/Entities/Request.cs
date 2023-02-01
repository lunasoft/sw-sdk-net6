namespace SW.Entities
{
    internal class Request
    {
        public string? Path { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public HttpClientHandler? Proxy { get; set; }
    }
}
