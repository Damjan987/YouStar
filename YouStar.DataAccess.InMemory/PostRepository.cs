using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using YouStar.Core;
using YouStar.Core.Models;

namespace YouStar.DataAccess.InMemory
{
    public class PostRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Post> posts;

        public PostRepository()
        {
            posts = cache["posts"] as List<Post>;
            if (posts == null) {
                posts = new List<Post>();
            }
        }

        public void Commit()
        {
            cache["posts"] = posts;
        }

        public void Insert(Post p) {
            posts.Add(p);
        }

        public void Update(Post post) {
            Post postToUpdate = posts.Find(p => p.Id == post.Id); 

            if (postToUpdate != null) {
                postToUpdate = post;
            }
            else
            {
                throw new Exception("Post was not found!");
            }
        }

        public Post Find(string Id) {
            Post post = posts.Find(p => p.Id == Id);

            if (post != null) {
                return post;
            }
            else
            {
                throw new Exception("Post was not found!");
            }
        }

        public IQueryable<Post> Collection()
        {
            return posts.AsQueryable();
        }

        public void Delete(string Id) {
            Post postToDelete = posts.Find(p => p.Id == Id);

            if (postToDelete != null)
            {
                posts.Remove(postToDelete);
            }
            else
            {
                throw new Exception("Post was not found!");
            }
        }
    }
}
