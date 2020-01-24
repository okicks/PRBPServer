using Data;
using Models.ThreadModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ThreadService
    {
        private readonly Guid _userId;

        public ThreadService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<ReadThread> GetThreadsByCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var ThreadQuery =
                    ctx
                        .Threads
                        .Where(e => e.CategoryId == categoryId)
                        .Select(
                            e => new ReadThread
                            {
                                Id = e.Id,
                                Name = e.Name,
                                OwnerId = e.OwnerId,
                                CreationDate = e.CreationDate,
                                CategoryId = e.CategoryId,
                            }
                        );

                return ThreadQuery.ToArray();
            }
        }

        public bool CreateThread(CreateThread model)
        {
            try
            {
                var entity =
                    new Thread
                    {
                        Id = model.Id,
                        Name = model.Name,
                        OwnerId = _userId,
                        CreationDate = DateTime.Now,
                        CategoryId = model.CategoryId,
                    };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Threads.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public bool UpdateThread(UpdateThread model)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Threads
                            .SingleOrDefault(e => e.Id == model.Id && e.OwnerId == _userId);

                    entity.Name = model.Name;

                    return ctx.SaveChanges() == 1;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public bool DeleteThread(int ThreadId)
        {
            try
            {

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Threads
                            .SingleOrDefault(e => e.Id == ThreadId && e.OwnerId == _userId);

                    ctx.Threads.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
    }
}
