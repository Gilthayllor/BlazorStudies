using BookStore.API.Contracts.Repositories;
using BookStore.API.Data;

namespace BookStore.API.Implementations.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context)
            :base(context)
        {

        }
    }
}
