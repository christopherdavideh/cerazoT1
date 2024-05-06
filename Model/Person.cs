using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cerazoT1.Model
{
    [Table("person")]
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(25)]
        public string Lastname { get; set; }
        [MaxLength(50), Unique]
        public string Email { get; set; }
    }
}
