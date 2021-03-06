﻿using Microsoft.AspNet.Identity;
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

        [Authorize]
        public IHttpActionResult Get(int categoryId)
        {
            var service = CreateThreadService();

            if (service == null)
                return BadRequest();

            return Ok(service.GetThreadsByCategory(categoryId));
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

        public IHttpActionResult Delete(int threadId)
        {
            var service = CreateThreadService();

            if (service == null)
                return BadRequest();

            if (!service.DeleteThread(threadId))
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
