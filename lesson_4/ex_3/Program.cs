using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_3
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public interface ICreationData
    {
        DateTime CreationData { get; set; }
    }
    public class Book : IEntity <int>, ICreationData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearOfPublication { get; set; }
        public DateTime CreationData { get; set; }

        public Book()
        {
            CreationData = DateTime.Now;
        }
    }

    public class Person : IEntity<Guid>, ICreationData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        public DateTime CreationData { get; set; }

        public Person()
        {
            Id = Guid.NewGuid();
            CreationData = DateTime.Now;
        }
    }

    public interface IBaseRepository<T, TEntity> where T : IEntity<TEntity>
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity Get(T id);
        void Delete(T id); 
    }

    public interface IBookRepository : IBaseRepository<Book, int>
    {
        IEnumerable<Book> GetBooksByAuthor(string author);
        IEnumerable<Book> GetBooksPublishedInYear(int year);
    }

    public interface IPersonRepository : IBaseRepository<Person, Guid>
    {
        IEnumerable<Book> GetBooksBorrowedByPerson(Guid personId);
        void AddBookToBorrowedList(Guid personId, Book book);
        void UpdatePerson(Guid personId, Person updatedPerson);
    }

    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>();

        public void Create(Book entity)
        {
            books.Add(entity);
        }

        public void Update(Book entity)
        {
            //book logic
        }

        public IEnumerable<Book> GetAll()
        {
            return books;
        }

        public Book Get(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        public void Delete(int id)
        {
            var bookToRemove = books.FirstOrDefault(b => b.Id == id);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }
        }
    }
    public class PersonRepository : IPersonRepository
    {
        private List<Person> persons = new List<Person>();

        public void Create(Person entity)
        {
            persons.Add(entity);
        }

        public void Update(Person entity)
        {
            //person logic
        }

        public IEnumerable<Person> GetAll()
        {
            return persons;
        }

        public Person Get(Guid id)
        {
            return persons.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(Guid id)
        {
            var personToRemove = persons.FirstOrDefault(p => p.Id == id);
            if (personToRemove != null)
            {
                persons.Remove(personToRemove);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IBookRepository bookRepository = new BookRepository();
            IPersonRepository personRepository = new PersonRepository();

            Book book = new Book { Title = "Fight club", Author = "Chuck Palahniuk", YearOfPublication = 1996 };
            Person person = new Person { Name = "Robert", Surname = "Polson", Age = 33 };

            bookRepository.Create(book);
            personRepository.Create(person);

            var allBooks = bookRepository.GetAll();
            var allPersons = personRepository.GetAll();
        }
    }
}
