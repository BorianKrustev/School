using System;
using System.Collections.Generic;
using System.Text;

namespace _2.BookShop
{
	public class Book
	{
		private string title;
		private string author;
		private decimal price;

		public Book(string author, string title, decimal price)
		{
			this.Title = title;
			this.Author = author;
			this.Price = price;
		}

		public decimal Price
		{
			get { return price; }
			set
			{
				if (value < 1)
				{
					throw new ArgumentException("Price not valid!");
				}
				price = value;
			}
		}

		public string Author
		{
			get { return author; }
			set { author = value; }
		}

		public string Title
		{
			get { return title; }
			set
			{
				if (value.Length < 3)
				{
					throw new ArgumentException("Title not valid!");
				}
				title = value;
			}
		}

	}
}
