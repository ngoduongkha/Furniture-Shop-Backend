using System.Collections.Generic;
namespace Furniture_Shop_Backend.ViewModels.Common {

    public class PagedResult<T> : PagedResultBase {
        public List<T> Items { set; get; }
    }
}
