using SqlLiteDemo.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteDemo.MVVM.Models
{
    public class Order : TableData
    {
        

        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
