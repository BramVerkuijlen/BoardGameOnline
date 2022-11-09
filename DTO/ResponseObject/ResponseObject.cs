using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ResponseObject
{
    public class ResponseObject<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public List<T> data { get; set; }

        public ResponseObject()
        {
            Success = false;
            data = new List<T>();

            Message = "unkown error";
        }
    }
}
