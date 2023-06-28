using System.Diagnostics.Eventing.Reader;

namespace E_Food_Admin.Data
{
    public class ResponseObject
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int role { get; set; }
    }
}
