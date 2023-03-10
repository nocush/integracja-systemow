using System.Xml;
using System.Xml.XPath;
using IS_Lab1_XML.Helpers;

namespace IS_Lab1_XML
{
	public class XMLReadWithXLSTDOM
	{
		public static void Read(string filepath)
		{
			var document = new XPathDocument(filepath);
			var navigator = document.CreateNavigator();

			const string namespaceUri = "http://rejestrymedyczne.ezdrowie.gov.pl/rpl/eksport-danych-v1.0";
			var manager = new XmlNamespaceManager(navigator.NameTable);
			manager.AddNamespace("x", namespaceUri);

			var query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy");
			query.SetContext(manager);
			var iterator = navigator.Select(query);

			var mpm = new ProductManager();

			while (iterator.MoveNext())
			{
				XPathNavigator iteratorCopy = iterator.Current!.Clone();
				XPathNodeIterator attributesIterator = iteratorCopy.Select("@*");

				var form = string.Empty;
				var commonName = string.Empty;
				var entityResponsible = string.Empty;

				while (attributesIterator.MoveNext())
				{
					switch (attributesIterator.Current!.Name)
					{
						case "postac":
							form = attributesIterator.Current.Value;
							break;
						case "nazwaPowszechnieStosowana":
							commonName = attributesIterator.Current.Value;
							break;
						case "podmiotOdpowiedzialny":
							entityResponsible = attributesIterator.Current.Value;
							break;
					}
				}
				mpm.AddProduct(commonName, form, entityResponsible);
			}

			mpm.MometasoniFuroasCount();
			mpm.CountProductsWithSameCommonNameButDifferentForms();
			mpm.EntitiesResponsibleWithMostCreamAndPills();
			mpm.TopThreeEntitiesWithMostCreams();
        }
	}
}

