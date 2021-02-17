﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.OldestFamilyMember
{
	public class Family
	{
		private List<Person> members;

		public Family()
		{
			this.members = new List<Person>();
		}

		public List<Person> Members
		{
			get { return this.members; }
			set { this.members = value; }
		}

		public void AddMember(Person member)
		{
			if (member == null)
			{
				throw new Exception();
			}

			this.Members.Add(member);
		}

		public Person GetOldestMember()
		{
			return this.Members.OrderByDescending(x => x.Age).FirstOrDefault();
		}
	}
}
