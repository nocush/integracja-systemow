using System;
using System.Xml;
using IS_Lab1_XML.Helpers;

namespace IS_Lab1_XML
{
	public class XMLReadWithDOMApproach
	{
		public XMLReadWithDOMApproach()
		{
		}
		// odczyt zawartości dokumentu
		internal static void Read(string filepath)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(filepath);

			string form;
			string commonName;
			string entityResponsible;

			var warehouse = doc.GetElementsByTagName("produktLeczniczy");
			var mpm = new ProductManager();

			foreach (XmlNode w in warehouse)
			{
				form = w.Attributes!.GetNamedItem("postac")!.Value;
				commonName = w.Attributes!.GetNamedItem("nazwaPowszechnieStosowana")!.Value;
				entityResponsible = w.Attributes!.GetNamedItem("podmiotOdpowiedzialny")!.Value;
				if (form == null || commonName == null || entityResponsible == null)
					throw new Exception();

				mpm.AddProduct(commonName, form, entityResponsible);
			}

			mpm.MometasoniFuroasCount();
			mpm.CountProductsWithSameCommonNameButDifferentForms();
            mpm.EntitiesResponsibleWithMostCreamAndPills();
			mpm.TopThreeEntitiesWithMostCreams();



            //int count = 0;
            /*foreach (XmlNode w in warehouse)
			{
				form = w.Attributes.GetNamedItem("postac").Value;
				commonName = w.Attributes.GetNamedItem("nazwaPowszechnieStosowana").Value;

				if (form == "Krem" && commonName == "Mometasoni furoas") count++;

			}
			Console.WriteLine("Liczba produktów leczniczych w postaci kremu," +
				" których jedyną substancją czynną jest Mometasoni furoas {0}", count);
		}*/

        }
    }
}