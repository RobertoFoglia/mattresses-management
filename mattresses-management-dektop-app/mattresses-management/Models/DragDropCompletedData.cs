using System.Collections.Generic;

using Windows.ApplicationModel.DataTransfer;

namespace mattresses_management.Models
{
    public class DragDropCompletedData
    {
        public DataPackageOperation DropResult { get; set; }

        public IReadOnlyList<object> Items { get; set; }
    }
}
