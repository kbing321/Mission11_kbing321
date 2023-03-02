using System.Linq;

namespace Mission09_kbing321.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
