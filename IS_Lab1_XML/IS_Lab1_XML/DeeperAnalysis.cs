using System.Xml;
using IS_Lab1_XML.Helpers;
namespace IS_Lab1_XML
{
	public class DeeperAnalysis
	{
		public static void AnalyzeProducts(string filepath)
		{
			var doc = new XmlDocument();
			doc.Load(filepath);
			var warehouse = doc.GetElementsByTagName("produktLeczniczy");

			var mpm = new ProductManager();

			foreach (XmlNode w in warehouse)
			{
				var commonName = w.Attributes!.GetNamedItem("nazwaPowszechnieStosowana")!.Value;
				var form = w.Attributes!.GetNamedItem("postac")!.Value;
				if (form == null || commonName == null)
					throw new Exception();

				var activeSubstanceCount = w.FirstChild!.ChildNodes.Count;
				mpm.AddProduct(commonName, form, activeSubstancesCount: activeSubstanceCount);
			}

			mpm.CountProductsWithOneAndMultipleActiveSubstances();
			mpm.CountProductsWithCountOfActiveSuvstances();

		}
	}
}

