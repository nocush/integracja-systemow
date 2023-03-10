using System;
using System.Xml;
using IS_Lab1_XML.Helpers;

namespace IS_Lab1_XML
{
	public class XMLReadWithSAXApproach
	{
		public static void Read(string filepath)
		{
			//konfiguracja początkowa dla XmlReadera
			var settings = new XmlReaderSettings
			{
				IgnoreComments = true,
				IgnoreProcessingInstructions = true,
				IgnoreWhitespace = true
			};

			var reader = XmlReader.Create(filepath, settings); //odczyt zawartości dokumentu
			reader.MoveToContent();

			var mpm = new ProductManager();

			while (reader.Read()) //analiza każdego z węzłów dokumentu
			{
				if (reader.NodeType != XmlNodeType.Element || reader.Name != "produktLeczniczy")
				{
					continue;
				}
				var form = reader.GetAttribute("postac")!;
				var commonName = reader.GetAttribute("nazwaPowszechnieStosowana")!;
				var entityResponsible = reader.GetAttribute("podmiotOdpowiedzialny")!;

				mpm.AddProduct(commonName, form, entityResponsible);
			}
			mpm.MometasoniFuroasCount();
			mpm.CountProductsWithSameCommonNameButDifferentForms();
			mpm.EntitiesResponsibleWithMostCreamAndPills();
			mpm.TopThreeEntitiesWithMostCreams();
		}
	}
}

