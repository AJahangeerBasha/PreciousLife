using System;
using System.Collections.Generic;
using System.Linq;
using PreciousLifeApplication.Model.Dashboard;
using PreciousLifeApplication.Repository;
using PreciousLifeApplication.Repository.Entities;

namespace PreciousLifeApplication.Api.Services
{
    // Entity = Not Model
    public class CollectionCenterService: IDisposable
    {
        private readonly PreciousLifeDbContext _db;

        public CollectionCenterService()
        {
            _db = new PreciousLifeDbContext();
        }

        public List<CollectionCentre> GetCollectionCenters()
        {
            return _db.CollectionCentres.ToList();
        }

        public List<CollectionCentre> GetCollectionCentersBy(string expectedDate)
        {
            // get by expected Date 
            return _db.CollectionCentres.ToList();
        }

        public List<CollectionCenterDModel> GetCollectionCentersOfNext(DateTime expectedDate)
        {
            // get by expected Date > 5 days => for dashboard.
            var centers = _db.CollectionCentres.ToList();
            return MapEntitiesToDModels(centers);
        }

        public List<CollectionCenterDModel> MapEntitiesToDModels(List<CollectionCentre> centers)
        {
            var models = new List<CollectionCenterDModel>();
            foreach (var center in centers)
            {
                var model = MapEntityToModel(center);
                models.Add(model);
            }
            return models;
        }

        public CollectionCenterDModel MapEntityToModel(CollectionCentre entity)
        {
            var model = new CollectionCenterDModel
            {
                Id = entity.Id,
                Name = entity.CenterName
                //ExpectedDates = // to do
            };
            return model;

        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}