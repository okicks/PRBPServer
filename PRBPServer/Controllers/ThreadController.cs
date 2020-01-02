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
    public class ThreadController : ApiController
    {
        public IHttpActionResult Get(int threadId)
        {
            return Ok(CreateThreadService().GetThreadsByCategory(threadId));
        }

        public IHttpActionResult Post(CreateThread thread)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateThreadService();

            if (!service.CreateThread(thread))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(UpdateThread thread)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateThreadService();

            if (!service.UpdateThread(thread))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateThreadService();

            if (!service.DeleteThread(id))
                return InternalServerError();

            return Ok();
        }

        private ThreadService CreateThreadService()
        {
            return new ThreadService(Guid.Parse(User.Identity.GetUserId()));
        }
    }
}
