using System.Web.Http;
using System.Web.Http.Description;
using PreciousLifeApplication.Api.Services;
using PreciousLifeApplication.Model;

namespace PreciousLifeApplication.Api.Controllers
{
    public class RequestorController : ApiController
    {
        
        // POST: api/Requestors
        [ResponseType(typeof(RequestorModel))]
        public IHttpActionResult PostRequestor(RequestorModel requestor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = new RequestorService();
            service.SaveRequestor(requestor);

            return Ok();
        }
    }
}
