using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _3.OldestFamilyMember
{
	public class Family
	{
		private List<Person> persons;

		public Family()
		{
			this.Persons = new List<Person>();
		}

		public List<Person> Persons
		{
			get => this.persons;
			set => this.persons = value;
		}

		public void AddMember(Person member)
		{
			this.Persons.Add(member);
		}

		public Person GetOldestMember()
		{
			return this.Persons.OrderByDescending(x => x.Age).FirstOrDefault();
		}
	}
}
