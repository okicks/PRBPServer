using Data;
using Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CategoryService
    {
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<ReadCategory> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var CategoryQuery =
                    ctx
                        .Categories
                        .Select(
                            e => new ReadCategory
                            {
                                Id = e.Id,
                                Name = e.Name,
                            }
                        );

                return CategoryQuery.ToArray();
            }
        }

        public bool CreateCategory(CreateCategory model)
        {
            try
            {
                var entity =
                    new Category
                    {
                        Id = model.Id,
                        Name = model.Name,
                        OwnerId = _userId,
                    };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Categories.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public bool UpdateCategory(UpdateCategory model)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Categories
                            .SingleOrDefault(e => e.Id == model.Id && e.OwnerId == _userId);

                    entity.Name = model.Name;

                    return ctx.SaveChanges() == 1;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public bool DeleteCategory(int CategoryId)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Categories
                            .SingleOrDefault(e => e.Id == CategoryId && e.OwnerId == _userId);

                    ctx.Categories.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
    }
}
