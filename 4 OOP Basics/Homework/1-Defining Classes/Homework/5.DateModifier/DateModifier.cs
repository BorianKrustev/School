using System;
using System.Collections.Generic;
using System.Text;

namespace _5.DateModifier
{
	public class DateModifier
	{
		private string firstDate;
		private string secondDate;

		public string FirstDate
		{
			get => this.firstDate;
			set => this.firstDate = value;
		}

		public string SecondDate
		{
			get => this.secondDate;
			set => this.secondDate = value;
		}

		public int PrintDif(string holdFirs, string holdSecond)
		{
			DateTime firstDate = DateTime.Parse(holdFirs);
			DateTime secondDate = DateTime.Parse(holdSecond);

			int diff = (firstDate - secondDate).Days;

			return Math.Abs(diff);
		}
	}
}
