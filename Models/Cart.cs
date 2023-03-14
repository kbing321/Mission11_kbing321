using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_kbing321.Models
{
    public class Cart
    {
        public List<CartLineItem> Books { get; set; } = new List<CartLineItem>();

        public virtual void AddBook (Book book, int qty)
        {
            CartLineItem line = Books
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Books.Add(new CartLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveBook(Book book)
        {
            Books.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public virtual void ClearCart()
        {
            Books.Clear();
        }
        public double CalculateTotal()
        {
            double sum = Books.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }


    }

    public class CartLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
