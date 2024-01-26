using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TireShop.Utils
{
    public class ResponseFormat <T>
    {
        [Required]
        public T? Data { get; set; }

        [Required]
        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
        [Required]
        public string Message { get; set; } = "OK";
        [Required]
        public int Code { get; set; } = 0;
        
        [Required]
        public short Version { get; set; } = 2;
    }
}
