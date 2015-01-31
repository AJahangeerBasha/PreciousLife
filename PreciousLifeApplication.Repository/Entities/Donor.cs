using System;

namespace PreciousLifeApplication.Repository.Entities
{
    public class Donor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public int PinCode { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string BloodGroup { get; set; }

        public string ContactNumber { get; set; }

        public bool IsActive { get; set; }
    }
}
