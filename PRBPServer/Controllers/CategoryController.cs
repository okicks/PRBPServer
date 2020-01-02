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
    public class CategoryController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(CreateCategoryService().GetCategories());
        }

        public IHttpActionResult Post(CreateCategory category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(UpdateCategory category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.UpdateCategory(category))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCategoryService();

            if (!service.DeleteCategory(id))
                return InternalServerError();

            return Ok();
        }

        private CategoryService CreateCategoryService()
        {
            return new CategoryService(Guid.Parse(User.Identity.GetUserId()));
        }
    }
}
