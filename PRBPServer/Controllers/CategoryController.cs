using Microsoft.AspNet.Identity;
using Models.CategoryModels;
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
    public class CategoryController : ApiController
    {
        public IHttpActionResult Get()
        {
            var service = CreateCategoryService();

            if (service == null)
                return BadRequest();

            return Ok(service.GetCategories());
        }

        public IHttpActionResult Post(CreateCategory category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (service == null)
                return BadRequest();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(UpdateCategory category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (service == null)
                return BadRequest();

            if (!service.UpdateCategory(category))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int categoryId)
        {
            var service = CreateCategoryService();

            if (service == null)
                return BadRequest();

            if (!service.DeleteCategory(categoryId))
                return InternalServerError();

            return Ok();
        }

        private CategoryService CreateCategoryService()
        {
            try
            {
                var user = Guid.Parse(User.Identity.GetUserId());

                return new CategoryService(user);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
    }
}
