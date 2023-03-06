using System.Linq;

namespace Mission10_kbing321.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
