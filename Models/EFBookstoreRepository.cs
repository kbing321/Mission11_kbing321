using System.Linq;

namespace Mission09_kbing321.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext context { get; set; }

        public EFBookstoreRepository(BookstoreContext bc)
        {
            context = bc;
        }

        public IQueryable<Book> Books => context.Books;
    }
}
