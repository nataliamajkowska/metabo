using System;
using System.Collections.Generic;
using System.Text;

namespace MetaboCoins.Helpers.Response
{
    public class BaseResponse
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public object Obj { get; set; }
    }
}
