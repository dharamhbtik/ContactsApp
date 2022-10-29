﻿using SQLite;

namespace ContactsApp.Classess
{
    [Table("PersonContact")]
    public class Contact
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public override string ToString()
        {
            return $"{Name} - {Email} - {Phone}";
        }
    }
}
