using Data;
using Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<ReadPost> GetPostsByThread(int threadId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var postQuery =
                    ctx
                        .Posts
                        .Where(e => e.ThreadId == threadId)
                        .Select(
                            e => new ReadPost
                            {
                                Id = e.Id,
                                Content = e.Content,
                                OwnerId = e.OwnerId,
                                CreationDate = e.CreationDate,
                                ThreadId = e.ThreadId,
                                Edited = e.Edited
                            }
                        );

                return postQuery.ToArray();
            }
        }

        public bool CreatePost(CreatePost model)
        {
            var entity =
                new Post
                {
                    Id = model.Id,
                    Content = model.Content,
                    OwnerId = _userId,
                    CreationDate = DateTime.Now,
                    ThreadId = model.ThreadId,
                    Edited = false,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdatePost(UpdatePost model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Id == model.Id && e.OwnerId == _userId);

                entity.Content = model.Content;
                entity.Edited = true;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Id == postId && e.OwnerId == _userId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
