using System;
using System.Collections.Generic;

namespace PreciousLifeApplication.Model.Dashboard
{
    public class DashboardModel
    {
        public List<CollectionCenterDModel> CollectionCenters { get; set; } 
    }
    public class CollectionCenterDModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExpectedDateDModel> ExpectedDates { get; set; } 
    }

    public class ExpectedDateDModel
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public List<RequestorDModel> Requestors { get; set; }
        public List<IntrestedDonorDModel> IntrestedDonors { get; set; } 
    }

    public class RequestorDModel
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
    }

    public class IntrestedDonorDModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int DonorId { get; set; }

        public int CollectionCentreId { get; set; }

        public string ContactNumber { get; set; }

        public string Status { get; set; }

        public DateTime SmsSentDate { get; set; }

        public DateTime RepliedOn { get; set; }

        public DateTime AppointmentScheduled { get; set; }

        public DateTime DonatedDate { get; set; }

    }
}
