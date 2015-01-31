using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PreciousLifeApplication.Model.Dashboard;
using PreciousLifeApplication.Repository;
using PreciousLifeApplication.Repository.Entities;

namespace PreciousLifeApplication.Api.Services
{
    public class DashboardService : IDisposable
    {
        private readonly PreciousLifeDbContext _db;

        public DashboardService()
        {
            _db = new PreciousLifeDbContext();
        }

        public void UpdateIntrestedDonor(IntrestedDonorDModel dModel)
        {
            var iDonor = _db.IDonors.FirstOrDefault(d => d.Id == dModel.Id);
            //iDonor.CollectionCentreId = dModel.ChangedCollectionCenter
            if (iDonor == null) return;
            if (dModel.AppointmentChangedDate != null)
            {
                iDonor.AppointmentScheduled = (DateTime)dModel.AppointmentChangedDate;
                iDonor.AppointmentScheduled.AddDays(-1);
            }
            
            _db.IDonors.Attach(iDonor);
            _db.Entry(iDonor).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public List<CollectionCenterDModel> GetDashboardData()
        {
            var dashboardModel = new DashboardModel();

            var collectioncenterService = new CollectionCenterService();

            var collectioncenters = new List<CollectionCenterDModel>();

            var centers = collectioncenterService.GetCollectionCentersOfNext(DateTime.Now);
            foreach (var center in centers)
            {
                var model = new CollectionCenterDModel
                {
                    Id = center.Id,
                    Name = center.Name,
                    ExpectedDates = GetExpectedDatesByCollectionCenter(center.Id)
                };
                collectioncenters.Add(model);
            }
            return collectioncenters;
        }

        private CollectionCenterDModel MapEntityToModel(CollectionCenterDModel entity)
        {
            var model = new Model.Dashboard.CollectionCenterDModel
            {
                Id = entity.Id,
                Name = entity.Name,
                ExpectedDates = GetExpectedDatesByCollectionCenter(entity.Id)
            };
            return model;
        }

        private CollectionCenterDModel GetCollectionCenterDModel(CollectionCenterDModel entity)
        {
            var model = new Model.Dashboard.CollectionCenterDModel
            {
                Id = entity.Id,
                Name = entity.Name,
                ExpectedDates = GetExpectedDatesByCollectionCenter(entity.Id)
            };
            return model;
        }   
        private List<ExpectedDateDModel> GetExpectedDatesByCollectionCenter(int centerId)
        {
            // from requestors by Collection center Id
            var requestors = _db.Requestors.Where(r => r.CollectionCentreId == centerId).ToList();

            requestors = requestors.GroupBy(i => i.ExpectedDate, (key, group) => group.First()).ToList();
            var expectedDates = new List<ExpectedDateDModel>();

            foreach (var requestor in requestors)
            {
                var expectedDate = new ExpectedDateDModel
                {
                    Date = requestor.ExpectedDate,
                    Quantity = requestor.Quantity,
                    Requestors = GetRequestorDModels(centerId, requestor.ExpectedDate),
                    IntrestedDonors = GetDonorDModels(centerId, requestor.ExpectedDate)
                };
                expectedDates.Add(expectedDate);
            }
            return expectedDates;
        }

        private List<RequestorDModel> GetRequestorDModels(int centerId, DateTime expectedDate)
        {
            var requestorDModels = new List<RequestorDModel>();
            var requestors = _db.Requestors.Where(r => r.CollectionCentreId == centerId && r.ExpectedDate.Day.Equals(expectedDate.Day));
            foreach (var requestor in requestors)
            {
                var model = new RequestorDModel
                {
                    Id = requestor.Id,
                    RequestorName = requestor.RequestorName,
                    PatientName = requestor.PatientName,
                    BloodGroup = requestor.BloodGroup,
                    ContactNumber = requestor.ContactNumber,
                    CollectionCentreId = requestor.CollectionCentreId,
                    ExpectedDate = requestor.ExpectedDate,
                    DeliveredDate = requestor.DeliveredDate,
                    Quantity = requestor.Quantity,
                    IsActive = requestor.IsActive
                };
                requestorDModels.Add(model);
            }
            return requestorDModels;
        }

        private List<IntrestedDonorDModel> GetDonorDModels(int centerId, DateTime expectedDate)
        {
            var donorDModels = new List<IntrestedDonorDModel>();
            var interestedDonors = _db.IDonors.Where(d => d.CollectionCentreId == centerId && d.AppointmentScheduled.Day.Equals(expectedDate.Day));
            var donors = _db.Doners.ToList();
            foreach (var interestedDonor in interestedDonors)
            {
                var model = new IntrestedDonorDModel
                {
                    Id = interestedDonor.Id,
                    Name = donors.Where(d => d.Id == interestedDonor.Id).Select(d => d.Name).FirstOrDefault(),
                    ContactNumber = interestedDonor.ContactNumber,
                    CollectionCentreId = interestedDonor.CollectionCentreId,
                    AppointmentScheduled = interestedDonor.AppointmentScheduled,
                    DonatedDate = interestedDonor.DonatedDate,
                    DonorId = interestedDonor.DonorId,
                    RepliedOn = interestedDonor.RepliedOn,
                    SmsSentDate = interestedDonor.SMSSentDate,
                    Status = interestedDonor.Status,
                    AppointmentChangedDate = null
                };
                donorDModels.Add(model);
            }
            return donorDModels;

        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}