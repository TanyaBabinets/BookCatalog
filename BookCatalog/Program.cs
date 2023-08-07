using BookCatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
//Использовать EF(Code First)

//РЕАЛИЗОВАТЬ МНОГОТАБЛИЧНУ БД БИБЛИОТЕКА !
//Создать приложение - библиотека
//Сущности:
//// Книга (id, название,категория,издательство, количество страниц,автор)
//// Автор
//// Категория 
//// Издательство
//Связи: 1 - N ,N - M

//Предусмотреть следующие возможности 
//добавление книги
//удаление
//изменение
//поиск: по автору, по названию, по категории, по издательству (ЯВНАЯ ЗАГРУЗКА)

namespace BookCatalog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OneToMany();
            ExplicitLoading();
        }

            static void OneToMany()
            {
                using (BookContext db = new BookContext())
                {
                    Author a1 = new Author { Name = "Dan", LastName= "Brown" };
                    Author a2 = new Author { Name = "Agata", LastName= "Cristy" };
                    Author a3 = new Author { Name = "Joan", LastName="Rowling" };

                   db.authors.Add(a1);
                   db.authors.Add(a2);
                    db.authors.Add(a3);               
                    db.SaveChanges();

                Category c1 = new Category { NameC = "detective" };
                Category c2 = new Category { NameC = "novel" };
                Category c3 = new Category { NameC = "adventure" };

                db.categorys.Add(c1);
                db.categorys.Add(c2);
                 db.categorys.Add(c3);
                db.SaveChanges();

                PressName p1 = new PressName { Name = "KievPress", Year="1989" };
                PressName p2 = new PressName { Name = "OdessaPress", Year="2005"};

                
                

                Book b1 = new Book
                {
                    Name = "Deception Point",
                    Pages = 345,
                    author1 = a1,
                    category1 = c2,
                    pressname = new List<PressName>() { p1 }
                    };

                Book b2 = new Book
                {
                    Name = "Code da Vinci",
                    Pages = 415,
                    author1 = a1,
                    category1 = c2,
                    pressname = new List<PressName>() { p1 }
                };

                Book b3 = new Book
                {
                    Name = "And Then There Were None",
                    Pages = 210,
                    author1 = a2,
                    category1 = c1,
                    pressname = new List<PressName>() { p1 }
                };
                Book b4 = new Book
                {
                    Name = "Murder in East Express",
                    Pages = 290,
                    author1 = a2,
                    category1 = c1,
                    pressname = new List<PressName>() { p2 }
                };
                Book b5 = new Book
                {
                    Name = "Harry Potter p.1",
                    Pages = 290,
                    author1 = a3,
                      category1 = c3,
                    pressname = new List<PressName>() { p2 }
                };
                Book b6 = new Book
                {
                    Name = "Harry Potter p.2",
                    Pages = 290,
                    author1 = a3,
                      category1 = c3,
                    pressname = new List<PressName>() { p2 }
                };
                Book b7 = new Book
                {
                    Name = "Harry Potter p.3",
                    Pages = 290,
                    author1 = a3,
                      category1 = c3,
                    pressname = new List<PressName>() { p2 }
                };

                db.books.AddRange(new List<Book> { b1, b2, b3, b4, b5, b6, b7 });             
                db.SaveChanges();
                }
            }
       
        static void ExplicitLoading()
        {
            using (BookContext db = new BookContext())
            {
          
                var ba = db.books.ToList();
                if (ba != null)
                {
                    foreach (var b in ba)
                    {
                        //явная загрузка
                        db.Entry(b).Reference("author1").Load();

                        Console.WriteLine($"\n" +
                            $"BOOK:  \"{b.Name}\",  {b.Pages} pages, author is {b.author1.Name} {b.author1.LastName}");
                    }
                }
            }
        }
    }
    
}
