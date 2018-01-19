using System;

namespace Uyelik.API.Models
{
    public class ResponseModel
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public DateTime responseTime { get; set; } = DateTime.Now;
    }
}