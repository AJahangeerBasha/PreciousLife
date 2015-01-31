using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PreciousLifeApplication.Api.Services;
using PreciousLifeApplication.Model;
using PreciousLifeApplication.Repository.Entities;

namespace PreciousLifeApplication.Api.Controllers
{
    public class DonorsController : ApiController
    {
        private readonly DonorService _service;
        private readonly CollectionCenterService _collectionCenterService;

        public DonorsController()
        {
            _service = new DonorService();
            _collectionCenterService = new CollectionCenterService();
        }
        // GET: api/Requestors
        //public IQueryable<DonorModel> GetDonors()
        //{
        //    return db.Requestors;
        //}

        ///api/donors/loadSearch
        public List<CollectionCentre> GetLoadSearch()
        {
            return _collectionCenterService.GetCollectionCenters().ToList();
        }

        ///api/donors/searchdonors?pincode=12&bloodGroup='A'&pincodeRange=22
        public List<DonorModel> GetSearhDonors(int pincode, string bloodGroup, int pincodeRange)
        {
            return _service.GetSearchResults(pincode, bloodGroup, pincodeRange).ToList();
        }

        ////api/donors/searchdonors?pincode=12
        //[ActionName("SearchDonors")]
        //public List<DonorModel> GetSearhDonors(int pincode)
        //{
        //    return _service.GetSearchResults(pincode, "A", 10).ToList();
        //}

        ////api/donors/searchdonors?pincode=12&pincodeRange=22
        //[ActionName("SearchDonors")]
        //public List<DonorModel> GetSearhDonors(int pincode, int pincodeRange)
        //{
        //    return _service.GetSearchResults(pincode, "A", 10).ToList();
        //}

        public IHttpActionResult PostSendSms(List<DonorModel> donorModels)
        {
            string str = string.Empty;
            ///
            /// Step1 : Get only chosen = true.
            /// Step 2: If true, send SMS + insert into Intrested Donors with Status = ?.
            ///  Step 3: Receive SMS => fire the update query from Mgmt Studio.
            /// ...
            /// Step 5: Refine => GetSearhDonors(). Its not working properly.
            return Ok();
        }

    }
}
