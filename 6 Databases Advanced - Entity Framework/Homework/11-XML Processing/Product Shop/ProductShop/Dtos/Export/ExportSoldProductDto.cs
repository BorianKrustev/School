﻿using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
	[XmlType("User")]
	public class ExportSoldProductDto
	{
		[XmlElement("firstName")]
		public string FirstName { get; set; }

		[XmlElement("lastName")]
		public string LastName { get; set; }

		[XmlArray("soldProducts")]
		public ProductDto[] ProductDto { get; set; }
	}

	[XmlType("Product")]
	public class ProductDto
	{
		[XmlElement("name")]
		public string Name { get; set; }

		[XmlElement("price")]
		public decimal Price { get; set; }
	}
}