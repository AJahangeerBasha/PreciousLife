using System;
using System.Collections.Generic;
using System.Linq;
using PreciousLifeApplication.Model;
using PreciousLifeApplication.Repository;
using PreciousLifeApplication.Repository.Entities;

namespace PreciousLifeApplication.Api.Services
{
    public class RequestorService: IDisposable
    {
        private readonly PreciousLifeDbContext _db;

        public RequestorService()
        {
            _db = new PreciousLifeDbContext();
        }

        public void SaveRequestor(RequestorModel model)
        {
            var requestor = MapModelToEntity(model);
            _db.Requestors.Add(requestor);
            _db.SaveChangesAsync(); // ?
        }

        public Requestor MapModelToEntity(RequestorModel model)
        {
            var requestor = new Requestor
            {
                Id = model.Id,
                RequestorName = model.RequestorName,
                PatientName = model.PatientName,
                CollectionCentreId = model.CollectionCentreId,
                ContactNumber = model.ContactNumber,
                Quantity = model.Quantity,
                BloodGroup = model.BloodGroup,
                ExpectedDate = model.ExpectedDate,
                DeliveredDate = model.DeliveredDate,
                IsActive = model.IsActive
            };
            return requestor;
        }

        public List<Requestor> MapModelsToEntities(List<RequestorModel> models)
        {
            return models.Select(model => new Requestor
            {
                Id = model.Id, RequestorName = model.RequestorName, PatientName = model.PatientName, CollectionCentreId = model.CollectionCentreId, ContactNumber = model.ContactNumber, Quantity = model.Quantity, BloodGroup = model.BloodGroup, ExpectedDate = model.ExpectedDate, DeliveredDate = model.DeliveredDate, IsActive = model.IsActive
            }).ToList();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}