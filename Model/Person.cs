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
        public int useId { get; set; }
        [MaxLength(25)]
        public string useName { get; set; }
        [MaxLength(25)]
        public string useLastname { get; set; }
        [MaxLength(50), Unique]
        public string useEmail { get; set; }
    }
}
