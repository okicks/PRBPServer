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
            return Ok(CreatePostService().GetPostsByThread(threadId));
        }

        public IHttpActionResult Post(CreatePost post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(UpdatePost post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.UpdatePost(post))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostService();

            if (!service.DeletePost(id))
                return InternalServerError();

            return Ok();
        }

        private PostService CreatePostService()
        {
            return new PostService(Guid.Parse(User.Identity.GetUserId()));
        }
    }
}
