using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Core.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Notes { get; set; }
    }
}
