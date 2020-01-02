using Microsoft.AspNet.Identity;
using Models.PostModels;
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
    public class PostController : ApiController
    {
        public IHttpActionResult Get(int threadId)
        {
            var service = CreatePostService();

            if (service == null)
                return BadRequest();

            return Ok(service.GetPostsByThread(threadId));
        }

        public IHttpActionResult Post(CreatePost post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (service == null)
                return BadRequest();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(UpdatePost post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (service == null)
                return BadRequest();

            if (!service.UpdatePost(post))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostService();

            if (service == null)
                return BadRequest();

            if (!service.DeletePost(id))
                return InternalServerError();

            return Ok();
        }

        private PostService CreatePostService()
        {
            try
            {
                var user = Guid.Parse(User.Identity.GetUserId());

                return new PostService(user);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
    }
}
