using System.Diagnostics.Eventing.Reader;

namespace ViewLayer.Data
{
    public class ResponeObject
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int role { get; set; }
    }
}
