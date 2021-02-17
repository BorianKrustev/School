using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
	public class ExportCustomUserProducktDto
	{
		[XmlElement("count")]
		public int Count { get; set; }

		[XmlArray("users")]
		public ExportUsersWithProductsDto[] ExportUsersWithProductsDto { get; set; }
	}
}