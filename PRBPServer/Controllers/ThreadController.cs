using Microsoft.AspNet.Identity;
using Models.ThreadModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRBPServer.Controllers
{
    [Authorize]
    public class ThreadController : ApiController
    {
        public IHttpActionResult Get(int threadId)
        {
            var service = CreateThreadService();

            if (service == null)
                return BadRequest();

            return Ok(service.GetThreadsByCategory(threadId));
        }

        public IHttpActionResult Post(CreateThread thread)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateThreadService();

            if (service == null)
                return BadRequest();

            if (!service.CreateThread(thread))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(UpdateThread thread)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateThreadService();

            if (service == null)
                return BadRequest();

            if (!service.UpdateThread(thread))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateThreadService();

            if (service == null)
                return BadRequest();

            if (!service.DeleteThread(id))
                return InternalServerError();

            return Ok();
        }

        private ThreadService CreateThreadService()
        {
            try
            {
                var user = Guid.Parse(User.Identity.GetUserId());

                return new ThreadService(user);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
    }
}
