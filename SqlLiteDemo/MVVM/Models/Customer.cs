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
    [Table("Customers")]
    public class Customer : TableData
    {
       
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
        [ManyToMany(typeof(CustomerPassport), CascadeOperations=CascadeOperation.All)]
        public List<Passport> Passport { get; set; }= new List<Passport>();
    }
}
