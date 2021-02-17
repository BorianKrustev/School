using System;
using System.Collections.Generic;
using System.Text;

namespace _5.DateModifier
{
	class DateModifier
	{
		private string firstDate;
		private string secondDate;

		public string FirstDate
		{
			get { return this.firstDate; }
			set { this.firstDate = value; }
		}

		public string SecondDate
		{
			get { return this.secondDate; }
			set { this.secondDate = value; }
		}

		public int PrintDif (string holdFirstDate, string holdSecondDate)
		{
			DateTime firstDate = DateTime.Parse(holdFirstDate);
			DateTime secondDate = DateTime.Parse(holdSecondDate);

			int diff = (firstDate - secondDate).Days;

			return Math.Abs(diff);
		}
	}
}