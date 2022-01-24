using System;
using System.Collections.Generic;
namespace Furniture_Shop_Backend.ViewModels.Common
{
        public class ApiResult<T>
        {
            public bool IsSuccessed { get; set; }

            public string Message { get; set; }

            public T ResultObj { get; set; }
        }
}
