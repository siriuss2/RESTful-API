using Class03.Models;

namespace Class03
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
          new Book()
          {
              Author = "J.K Rowling",
              Title = "Harry Potter and the Philosopher's Stone"
          },

          new Book()
          {
              Author = "Tony Robbins",
              Title = "Awaken the Giant Within"
          },

          new Book()
          {
              Author = "Harper Lee",
              Title = "To Kill a Mockingbird"
          },

          new Book()
          {
              Author = "George Orwell",
              Title = "1984"
          }
        };
    }
}
