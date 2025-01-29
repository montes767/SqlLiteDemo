using SQLite;
using SQLiteNetExtensions.Attributes;
using SqlLiteDemo.Abstractions;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteDemo.MVVM.Models
{
    [Table("Passports")]
    public class Passport : TableData
    {
        public DateTime ExpirationDate { get; set; }

        [ManyToMany(typeof(CustomerPassport))]
        public int PassportId { get; set; }
    }
}
