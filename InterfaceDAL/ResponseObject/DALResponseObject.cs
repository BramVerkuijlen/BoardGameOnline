using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL.ResponseObject
{
    public class DALResponseObject<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public List<T> data { get; set; }

        public DALResponseObject()
        {
            Success = false;
        }
    }
}
