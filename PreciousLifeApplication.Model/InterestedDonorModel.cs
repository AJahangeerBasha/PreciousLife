using System;

namespace PreciousLifeApplication.Model
{
    public class InterestedDonorModel
    {
        public int Id { get; set; }

        public int DonorId { get; set; }

        public int CollectionCentreId { get; set; }

        public string ContactNumber { get; set; }

        public string Status { get; set; }

        public DateTime SMSSentDate { get; set; }

        public DateTime RepliedOn { get; set; }

        public DateTime AppointmentScheduled { get; set; }

        public DateTime DonatedDate { get; set; }

        public DonorModel DonorModel { get; set; }
        public CollectionCentreModel CollectionCentreModel { get; set; }

    }
}
