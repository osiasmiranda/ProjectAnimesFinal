using RedeSocial.Domain.Entities;
using RedeSocial.Domain.Interfaces.Repository;
using RedeSocial.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocial.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async  Task DeleteAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PostEntity>> GetAllAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<PostEntity> GetByIdAsync(int id)
        {
            return await _postRepository.GetByIdAsync(id);
        }

        public async  Task Send(PostEntity postEntity)
        {
            await _postRepository.Send(postEntity);
        }

        public async  Task UpdateAsync(PostEntity updatedEntity)
        {
            await _postRepository.UpdateAsync(updatedEntity);
        }
    }
}
