using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFn_AddMonth
{
    public class PostData
    {
        public string original_dateTime { get; set; }
        public string addMonths_value { get; set; }
    }
}
