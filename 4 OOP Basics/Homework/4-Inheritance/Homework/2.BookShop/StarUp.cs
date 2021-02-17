using System;

namespace _2.BookShop
{
	class StarUp
	{
		static void Main(string[] args)
		{
			string author = Console.ReadLine();
			string title = Console.ReadLine();
			decimal price = decimal.Parse(Console.ReadLine());

			string[] hold = author.Split();
			char check = hold[1][0];

			if (int.TryParse(check.ToString(), out int result))
			{
				Console.WriteLine("Author not valid!");
				Environment.Exit(0);
			}

			try
			{
				Book book = new Book(author, title, price);
				GoldenEditionBook goldEditionBook = new GoldenEditionBook(author, title, price);

				Console.WriteLine("Type: Book");
				Console.WriteLine($"Title: {book.Title}");
				Console.WriteLine($"Author: {book.Author}");
				Console.WriteLine($"Price: {book.Price:f2}");

				Console.WriteLine();

				Console.WriteLine("Type: GoldenEditionBook");
				Console.WriteLine($"Title: {goldEditionBook.Title}");
				Console.WriteLine($"Author: {goldEditionBook.Author}");
				Console.WriteLine($"Price: {goldEditionBook.Price:f2}");

			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
