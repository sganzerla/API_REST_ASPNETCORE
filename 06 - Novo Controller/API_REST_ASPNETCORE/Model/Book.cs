using RestWithASPNETUdemy.Model.Base;
using System;

namespace RestWithASPNETUdemy.Model
{
    public class Book : BaseEntity
    {      
        public string Title { get; set; }
        public string Author { get; set; }
        public string Price { get; set; }
        public DateTime LauchDate { get; set; }
    }
}
