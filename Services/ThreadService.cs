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

        public IEnumerable<ReadThread> GetThreadsByCatagory(int catagoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var ThreadQuery =
                    ctx
                        .Threads
                        .Where(e => e.CatagoryId == catagoryId)
                        .Select(
                            e => new ReadThread
                            {
                                Id = e.Id,
                                Name = e.Name,
                                OwnerId = e.OwnerId,
                                CreationDate = e.CreationDate,
                                CatagoryId = e.CatagoryId,
                            }
                        );

                return ThreadQuery.ToArray();
            }
        }

        public bool CreateThread(CreateThread model)
        {
            var entity =
                new Thread
                {
                    Id = model.Id,
                    Name = model.Name,
                    OwnerId = _userId,
                    CreationDate = DateTime.Now,
                    CatagoryId = model.CatagoryId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Threads.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateThread(UpdateThread model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Threads
                        .Single(e => e.Id == model.Id && e.OwnerId == _userId);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteThread(int ThreadId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Threads
                        .Single(e => e.Id == ThreadId && e.OwnerId == _userId);

                ctx.Threads.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
