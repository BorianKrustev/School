using System;
using System.Collections.Generic;
using System.Text;

namespace _2.BookShop
{
	public class GoldenEditionBook : Book
	{
		public GoldenEditionBook(string author, string title, decimal price)
			: base(author, title, price)
		{
			Price += (price * 30 / 100);
		}
	}
}
