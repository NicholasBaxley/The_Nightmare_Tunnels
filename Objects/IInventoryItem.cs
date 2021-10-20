using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public interface IInventoryItem
    {
        string name { get; set; }
        string desc { get; set; }
        int id { get; set; }
        
    }
}
