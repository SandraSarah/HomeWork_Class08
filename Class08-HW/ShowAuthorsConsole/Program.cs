using BooksProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowAuthorsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BooksLoader loader = new BooksLoader();
            var authors = loader.GetAllAuthors();

           

            Console.WriteLine("--------------------------HOMEWORK!----------------------------------");

            // HOMEWORK!

            //1. What is the average number of books per autors?
            var avgNumberOfBooks = authors.Average(a => a.Books.Count());
            Console.WriteLine(avgNumberOfBooks);

            //2. Which book(s) has the longest title, and how long is it?

            var theLongestTitle = authors.SelectMany(a => a.Books.Select(b => new {
                b.Title,
                TitleLength = b.Title.Count()
                })).OrderByDescending(t => t.TitleLength).First();

          

            Console.WriteLine($"The longest title is: {theLongestTitle.Title} with {theLongestTitle.TitleLength} letters");


            //3. Which author has the shortest average title for a book?   

            var theShortestAvgTitle = authors.Select(a => new {
                a.Name,
                theShortesAvg = a.Books.Average
                (b => b.Title.Length)
            }).OrderBy(a => a.theShortesAvg).First();
            Console.WriteLine($@" The shorthes average titele for a book has: {theShortestAvgTitle}");

            //4. Which author has the shortest average title for a book? (Discount authors with less than three books)

            var theShortestAvgTitleWithLessThen3 = authors.Where(a => a.Books.Count() > 3)
                                   .Select(a => new { a.Name, shortesAvg = a.Books.Average(b => b.Title.Length) })
                                   .OrderBy(a => a.shortesAvg).First();

            Console.WriteLine($@" The shorthes average titele for a book with less than 3 books has: {theShortestAvgTitleWithLessThen3}");


            //5. What series has the most books?

            var seriesWithTheMostBooks = allBooks.Where(s => !string.IsNullOrEmpty(s.Series)).GroupBy(s => s.Series)
            .OrderByDescending(s => s.Count()).Last();

            Console.WriteLine($"{seriesWithTheMostBooks.Key} is series with {seriesWithTheMostBooks.Count()} books");



            Console.WriteLine("--------------------------HOMEWORK!----------------------------------");


            //6. Which year has the most books published?

            var theMostBooksPerYear = allBooks.GroupBy(y => y.Year)
                                      .Select(b => new { b.Key, Count = b.Count() })
                                      .OrderByDescending(b => b.Count);

            var theYear = theMostBooksPerYear.First();

            Console.WriteLine($"The most books are published in: {theYear}");



            //7. What is the average number of books published for years in the 21st centrury ? (Starting with 2001, not 2000)

            var avgNumInCentury21 = authors.SelectMany(a => a.Books)
                .Where(b => b.Year > 2000)
                .GroupBy(b => b.Year).Average(c => c.Count());

            Console.WriteLine($"The average number of books published in 21st century is {avgNumInCentury21}");


            //8. Which author has the most different series?
            //


            //9. Which author has the most books written that belong to a series?

            var authorWithTheMostSeries = authors.Select(a => new
            { a.Name, NumOfSeries = a.Books.Where(b => !string.IsNullOrEmpty(b.Series)).Count() })
                                              .OrderByDescending(a => a.NumOfSeries)
                                              .First();

            Console.WriteLine($"The author that has the most books that belong to a series is: {authorWithTheMostSeries.Name} ({authorWithTheMostSeries.NumOfSeries})");

        }


        static void PrintAuthors<T>(IEnumerable<T> authors)
        {
            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }
       

        }
    }
}
