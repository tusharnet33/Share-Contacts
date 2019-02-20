using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Contacts5.Models
{
    public class Profile
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
    }
}
