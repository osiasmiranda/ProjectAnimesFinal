using Microsoft.EntityFrameworkCore;
using RedeSocial.Domain.Entities;
using RedeSocial.Domain.Interfaces.Repository;
using RedeSocial.Infrastructure.Context;

namespace RedeSocial.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly RedeDbContext _postContext;

        public PostRepository(RedeDbContext postContext)
        {
            _postContext = postContext;
        }

        public async Task DeleteAsync(int? id)
        {
            var postEntity = await _postContext.Posts.FindAsync(id);
            _postContext.Posts.Remove(postEntity);
            await _postContext.SaveChangesAsync();

        }

        public async  Task<IEnumerable<PostEntity>> GetAllAsync()
        {
            return await _postContext.Posts.ToListAsync();
        }

        public async Task<PostEntity> GetByIdAsync(int? id)
        {
            return await _postContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async  Task Send(PostEntity postEntity)
        {
            _postContext.Add(postEntity);
            await _postContext.SaveChangesAsync();
        }

      

        public async Task UpdateAsync(PostEntity updatedEntity)
        {
            _postContext.Update(updatedEntity);
            await _postContext.SaveChangesAsync();
        }
    }
}
