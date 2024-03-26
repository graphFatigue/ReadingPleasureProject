using ReadingPleasure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingPleasure.Abstractions.Infrastructure
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default);
        Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId, CancellationToken cancellationToken = default);
        Task<int> GetCountAsync(CancellationToken cancellationToken = default);
    }
}
