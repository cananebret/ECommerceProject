using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    public class ServiceResult
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<string> Exceptions { get; set; }
        public object Data { get; set; }
    }

    public class ServiceReturnModel
    {
        public string Message { get; set; }
        public List<string> Exceptions { get; set; }
        public object Data { get; set; }
    }
}
