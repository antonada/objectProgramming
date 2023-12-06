using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_1_from_lab6
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public interface ICreationDate
    {
        DateTime CreationDate { get; set; }
    }

    public class Book : IEntity<int>, ICreationDate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearOfPublication { get; set; }
        public DateTime CreationDate { get; set; }

        public Book()
        {
            CreationDate = DateTime.Now;
        }
    }

    public class Person : IEntity<Guid>, ICreationDate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        public DateTime CreationDate { get; set; }

        public Person()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
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
    public class BaseRepository<T, TEntity> : IBaseRepository<T, TEntity> where T : IEntity<TEntity>
    {
        private List<TEntity> entities = new List<TEntity>();

        public void Create(TEntity entity)
        {
            entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var existingEntity = entities.FirstOrDefault(e => EqualityComparer<T>.Default.Equals(((IEntity<T>)e).Id, ((IEntity<T>)entity).Id));
            if (existingEntity != null)
            {
                entities.Remove(existingEntity);
                entities.Add(entity);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities;
        }

        public TEntity Get(T id)
        {
            return entities.FirstOrDefault(e => EqualityComparer<T>.Default.Equals(((IEntity<T>)e).Id, id));
        }

        public void Delete(T id)
        {
            var entityToRemove = entities.FirstOrDefault(e => EqualityComparer<T>.Default.Equals(((IEntity<T>)e).Id, id));
            if (entityToRemove != null)
            {
                entities.Remove(entityToRemove);
            }
        }
    }
    public class BookRepository : BaseRepository<Book, int>, IBookRepository
    {
        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return GetAll().Where(b => b.Author == author);
        }
    }

    public class PersonRepository : BaseRepository<Person, Guid>, IPersonRepository
    {
        public IEnumerable<Book> GetBooksBorrowedByPerson(Guid personId)
        {
            var person = Get(personId);
            return person = Enumerable.Empty<Book>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IBookRepository bookRepository = new BookRepository();
            IPersonRepository personRepository = new PersonRepository();

            Book book = new Book { Title = "Sample Book", Author = "Sample Author", YearOfPublication = 2022 };
            Person person = new Person { Name = "John", Surname = "Doe", Age = 30 };

            bookRepository.Create(book);
            personRepository.Create(person);

            personRepository.AddBookToBorrowedList(person.Id, book);

            var borrowedBooks = personRepository.GetBooksBorrowedByPerson(person.Id);
            Console.WriteLine($"Books borrowed by {person.Name}:");
            foreach (var borrowedBook in borrowedBooks)
            {
                Console.WriteLine($"{borrowedBook.Title} by {borrowedBook.Author}");
            }

            Person updatedPerson = new Person { Name = "UpdatedJohn", Surname = "UpdatedDoe", Age = 35 };
            personRepository.UpdatePerson(person.Id, updatedPerson);

            var updatedPersonInfo = personRepository.Get(person.Id);
            Console.WriteLine($"Updated person information: {updatedPersonInfo.Name} {updatedPersonInfo.Surname}, Age: {updatedPersonInfo.Age}");

        }
    }
}
