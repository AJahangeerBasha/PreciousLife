using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using PreciousLifeApplication.Api.Services;
using PreciousLifeApplication.Model.Dashboard;

namespace PreciousLifeApplication.Api.Controllers
{
    public class DashboardController : ApiController
    {
        private readonly DashboardService _service;
        public DashboardController()
        {
            _service = new DashboardService();
        }

        ///api/dashboard/dashboarddata
        public List<CollectionCenterDModel> GetDashboardData()
        {
            return _service.GetDashboardData();
        }

        //api/dashboard/updatedonor
        public List<CollectionCenterDModel> PutUpdateDonor(IntrestedDonorDModel dModel)
        {
            _service.UpdateIntrestedDonor(dModel);
            return _service.GetDashboardData();
        }
    }
}
