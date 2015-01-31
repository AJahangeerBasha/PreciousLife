using System;

namespace PreciousLifeApplication.Repository.Entities
{
    public class Requestor
    {
        public int Id { get; set; }

        public string RequestorName { get; set; }

        public string PatientName { get; set; }

        public int CollectionCentreId { get; set; }

        public string ContactNumber { get; set; }

        public string BloodGroup { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpectedDate { get; set; }

        public DateTime? DeliveredDate { get; set; }

        public bool IsActive { get; set; }

        public virtual CollectionCentre CollectionCentre { get; set; }

    }
}
