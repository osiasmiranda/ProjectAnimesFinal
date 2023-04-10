using RedeSocial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocial.Domain.Interfaces.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<PostEntity>> GetAllAsync();
        Task<PostEntity> GetByIdAsync(int? id);
        Task Send(PostEntity postEntity);
        Task UpdateAsync(PostEntity updatedEntity);
        Task DeleteAsync(int? id);

    }
}
