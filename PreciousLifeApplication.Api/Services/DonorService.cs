﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using PreciousLifeApplication.Model;
using PreciousLifeApplication.Repository;
using PreciousLifeApplication.Repository.Entities;

namespace PreciousLifeApplication.Api.Services
{
    public class DonorService : IDisposable
    {
        private readonly PreciousLifeDbContext _db;

        public DonorService()
        {
            _db = new PreciousLifeDbContext();
        }

        public List<DonorModel> GetSearchResults(int pincode, string bloodGroup, int pincodeRange)
        {
            //var minValue = pincode - pincodeRange;
            //var maxValue = pincode + pincodeRange;
            ////var donors = _db.Doners.Where(d => int.Parse(d.PinCode) >= minValue && int.Parse(d.PinCode) <= maxValue);

            ////delete the below line:
            //var donors = _db.Doners.ToList();
            //// to do => need to take care of AGE + Weight + 15 days

            //var models = MapEntitiesToModels(donors.ToList());
            //return models.ToList();

            var eliglibledononrs = new List<Donor>();
            DateTime startDate = new DateTime(2010, 1, 1);
            DateTime endDate = DateTime.Now;
            var totalDays = (endDate - startDate).TotalDays;
            var totalYears = Math.Truncate(totalDays / 365);
            var minValue = pincode - pincodeRange;
            var maxValue = pincode + pincodeRange;
            var donors = _db.Doners.Where(d => d.PinCode >= minValue && d.PinCode <= maxValue && d.BloodGroup == bloodGroup).ToList();
            var minAllowedAge = 18; var maxAllowedAge = 58; var donationDaysLimit = 15;

            donors = donors.Where(s => (DateTime.Now.Year - s.DateOfBirth.Year >= minAllowedAge) && (DateTime.Now.Year - s.DateOfBirth.Year <= maxAllowedAge)).ToList();
            var models = MapEntitiesToModels(donors.ToList());
            return models.ToList();

        }

        public Donor MapModelToEntity(DonorModel model)
        {
            var donor = new Donor
            {
                Id = model.Id,
                Name = model.Name,
                UserName = model.UserName,
                Address = model.Address,
                City = model.City,
                PinCode = model.PinCode,
                DateOfBirth = model.DateOfBirth,
                BloodGroup = model.BloodGroup,
                ContactNumber = model.ContactNumber,
                IsActive = model.IsActive
            };
            return donor;
        }

        public DonorModel MapEntityToModel(Donor entity)
        {
            var model = new DonorModel
            {
                Id = entity.Id,
                Name = entity.Name,
                UserName = entity.UserName,
                Address = entity.Address,
                City = entity.City,
                PinCode = entity.PinCode,
                DateOfBirth = entity.DateOfBirth,
                BloodGroup = entity.BloodGroup,
                ContactNumber = entity.ContactNumber,
                IsActive = entity.IsActive,
                Chosen = false
            };
            return model;
        }

        public List<DonorModel> MapEntitiesToModels(List<Donor> entities)
        {
            return entities.Select(MapEntityToModel).ToList();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}