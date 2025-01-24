using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteDemo.MVVM.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Column("id"), PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("name"), Indexed]
        public string Name { get; set; } = string.Empty;
        [Column("addres"), MaxLength(100)]
        public string Address { get; set; }= string.Empty;
        [Column("phone"), Unique]
        public string Phone { get; set; }= string.Empty;
        [Column("age")]
        public int Age { get; set; }
        [Ignore]
        public bool IsYoung => Age < 18;
    }
}
