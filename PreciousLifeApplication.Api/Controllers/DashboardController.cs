using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PreciousLifeApplication.Api.Services;

namespace PreciousLifeApplication.Api.Controllers
{
    public class DashboardController : ApiController
    {
        private readonly DashboardService _service;
        public DashboardController()
        {
            _service = new DashboardService();
        }
    }
}
