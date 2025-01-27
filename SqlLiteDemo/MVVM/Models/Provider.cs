using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteDemo.MVVM.Models
{
    public class Provider
    {
        public string Name { get; set; } = "Juan";

        private Provider()
        {

            
        }

        public static Provider getInstance()
        {
            return new Provider();
        }
    }
}
