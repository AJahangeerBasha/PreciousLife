using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PreciousLifeApplication.Repository;
using PreciousLifeApplication.Repository.Entities;

namespace PreciousLifeApplication.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //CollectionCenterInsert();
            //RequestorCreate();
            //DonorsCreate();
            //CollectionCenterInsertMultiple();
            //RequestorCreateMultiple();
            //DonorsCreateMultiple();
            IntrestedDonorCreate();
        }

        private static void IntrestedDonorCreate()
        {
            var id = new InterestedDonor();
            id.DonorId = 1;
            id.CollectionCentreId = 1;
            id.ContactNumber = "12345";
            id.Status = "Sent";
            id.SMSSentDate = DateTime.Now;
            id.RepliedOn = DateTime.Now;
            id.AppointmentScheduled = DateTime.Now;
            id.DonatedDate = DateTime.Now;

            var db = new PreciousLifeDbContext();
            db.IDonors.Add(id);
            db.SaveChanges();
        }
        private static void CollectionCenterInsert()
        {
            var cc = new CollectionCentre();
            cc.CenterName = "Collection Center1";
            cc.Address = "123, Street Name, KP";
            cc.Pincode = 400100;
            cc.IsActive = true;
            var db = new PreciousLifeDbContext();
            db.CollectionCentres.Add(cc);
            db.SaveChanges();
        }

        private static void CollectionCenterInsertMultiple()
        {
            for (int i = 0; i < 10; i++)
            {
                var cc = new CollectionCentre();
                cc.CenterName = string.Format("Collection Center{0}", i);
                cc.Address = "123, Street Name, KP";
                cc.Pincode = 400100 + i + 10;
                cc.IsActive = true;
                using (var db = new PreciousLifeDbContext())
                {
                    db.CollectionCentres.Add(cc);
                    db.SaveChanges();
                }
            }


        }



        private static void RequestorCreate()
        {
            var requestor = new Requestor();
            requestor.RequestorName = "Requestor";
            requestor.PatientName = "Patient";
            requestor.ContactNumber = "123456789";
            requestor.BloodGroup = "A";
            requestor.CollectionCentreId = 1;
            requestor.ExpectedDate = DateTime.Now;
            requestor.Quantity = 600;
            requestor.DeliveredDate = null;
            requestor.IsActive = true;
            using (var db = new PreciousLifeDbContext())
            {
                db.Requestors.Add(requestor);
                db.SaveChanges();
            }
        }


        private static void RequestorCreateMultiple()
        {
            for (int i = 0; i < 20; i++)
            {
                var requestor = new Requestor();
                requestor.RequestorName = string.Format("Requestor{0}", i);
                requestor.PatientName = string.Format("Patient{0}", i);
                requestor.ContactNumber = string.Format("12345678{0}", i);
                requestor.BloodGroup = "A";
                requestor.CollectionCentreId = 1;
                requestor.ExpectedDate = DateTime.Now;
                requestor.Quantity = 600;
                requestor.DeliveredDate = null;
                requestor.IsActive = true;
                using (var db = new PreciousLifeDbContext())
                {
                    db.Requestors.Add(requestor);
                    db.SaveChanges();
                }
            }

        }

        private static void DonorsCreate()
        {
            var donor = new Donor();
            donor.Name = "Donor1";
            donor.UserName = "Donor1";
            donor.BloodGroup = "AB";
            donor.ContactNumber = "9833580106";
            donor.Address = "Mahape";
            donor.DateOfBirth = DateTime.Now;
            donor.IsActive = true;
            donor.PinCode = 400034;
            donor.City = "Mumbai";
            using (var context = new PreciousLifeDbContext())
            {
                context.Doners.Add(donor);
                context.SaveChanges();
            }
        }

        private static void DonorsCreateMultiple()
        {
            for (int i = 0; i < 30; i++)
            {
                var donor = new Donor();
                donor.Name = "Donor1";
                donor.UserName = "Donor1";
                donor.BloodGroup = "AB";
                donor.ContactNumber = "9833580106";
                donor.Address = "Mahape";
                donor.DateOfBirth = DateTime.Now;
                donor.IsActive = true;
                donor.PinCode = 400034;
                donor.City = "Mumbai";
                using (var context = new PreciousLifeDbContext())
                {
                    context.Doners.Add(donor);
                    context.SaveChanges();
                }
            }

        }
    }
}
