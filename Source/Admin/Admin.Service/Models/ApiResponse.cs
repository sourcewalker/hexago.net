using System.Dynamic;

namespace Admin.Service.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public ExpandoObject Data { get; set; }
    }
}