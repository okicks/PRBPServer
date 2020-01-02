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

        public IEnumerable<ReadCategory> GetCategorys()
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
            var entity =
                new Category
                {
                    Id = model.Id,
                    Name = model.Name,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateCategory(UpdateCategory model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.Id == model.Id && e.OwnerId == _userId);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int CategoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.Id == CategoryId && e.OwnerId == _userId);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
