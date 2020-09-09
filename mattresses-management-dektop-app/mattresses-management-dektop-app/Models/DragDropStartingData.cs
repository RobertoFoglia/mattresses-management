using System.Collections.Generic;

using Windows.ApplicationModel.DataTransfer;

namespace mattresses_management_dektop_app.Models
{
    public class DragDropStartingData
    {
        public DataPackage Data { get; set; }

        public IList<object> Items { get; set; }
    }
}
