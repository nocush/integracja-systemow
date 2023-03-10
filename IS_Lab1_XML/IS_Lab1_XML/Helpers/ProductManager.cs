using System;
namespace IS_Lab1_XML.Helpers
{
	public class ProductManager
	{
		private readonly List<MedicalProduct> _medicalProducts = new();

		public void AddProduct(string? commonName = null, string? form = null, string? entityResponsible = null, int? activeSubstancesCount = null)
		{
			var product = new MedicalProduct
			{
				CommonName = commonName,
				Form = form,
				EntityResponsible = entityResponsible,
				ActiveSubstancesCount = activeSubstancesCount
			};
			_medicalProducts.Add(product);
		}

		public void MometasoniFuroasCount()
		{
			var count = _medicalProducts.Count(p => p.CommonName!.Equals("Mometasoni furoas") && p.Form!.Equals("Krem"));
			var result = "Liczba produktów leczniczych w postaci kremu," +
				$" których jedyną substancją czynną jest Mometasoni furoas {count}";
			Console.WriteLine(result);

		}

		public void CountProductsWithSameCommonNameButDifferentForms() {
			var medicalProductsByCommonName = new Dictionary<string, HashSet<string>>();
			foreach (var product in _medicalProducts)
			{
				if (medicalProductsByCommonName.ContainsKey(product.CommonName!))
					medicalProductsByCommonName[product.CommonName!].Add(product.Form!);
				else
					medicalProductsByCommonName.Add(product.CommonName!, new HashSet<string> { product.Form! });
			}

			var sameNameDifferentFormCount = medicalProductsByCommonName.Values.Count(set => set.Count > 1);
			var result = $"Liczba preparatów leczniczych o takiej samej nazwie powszechnej pod różnymi postaciami: {sameNameDifferentFormCount}";
			Console.WriteLine(result);
		}

		public void EntitiesResponsibleWithMostCreamAndPills()
		{
			var creamCountByEntityResponsible = new Dictionary<string, int>();
			var pillsCountByEntityResponsible = new Dictionary<string, int>();

			foreach (var product in _medicalProducts)
			{
				switch (product.Form)
				{
					case "Krem":
						{
							if (creamCountByEntityResponsible.ContainsKey(product.EntityResponsible!))
                            {
                                creamCountByEntityResponsible[product.EntityResponsible!]++;
                            }
                            else
								creamCountByEntityResponsible.Add(product.EntityResponsible!, 1);
							break;
						}
					case { } f when f.ToUpper().Contains("TABLETKI"):
						{
							if (pillsCountByEntityResponsible.ContainsKey(product.EntityResponsible!))
                            {
                                pillsCountByEntityResponsible[product.EntityResponsible!]++;
                            }
                            else
								pillsCountByEntityResponsible.Add(product.EntityResponsible!, 1);
							break;
						}
				}
			}
            var entityWithMostCreams = creamCountByEntityResponsible.MaxBy(pair => pair.Value);
			var entityWithMostPills = pillsCountByEntityResponsible.MaxBy(pair => pair.Value);
			Console.WriteLine($"Podmiot odpowiedzialny z największą ilością Kremów: {entityWithMostCreams}");
			Console.WriteLine($"Podmiot odpowiedzialny z największą ilością Tabletek: {entityWithMostPills}");





		}

		public void TopThreeEntitiesWithMostCreams()
		{
			var creamsByEntity = new Dictionary<string, int>();

			foreach (var product in _medicalProducts)
			{
				if (product.Form!.Equals("Krem"))
				{
					if (creamsByEntity.ContainsKey(product.EntityResponsible!))
						creamsByEntity[product.EntityResponsible!]++;
					else
						creamsByEntity.Add(product.EntityResponsible!, 1);
				}
			}

			var topThreeEntitiesWithMostCreams = (from pair in creamsByEntity orderby pair.Value descending select pair).Take(3);
			Console.WriteLine("Podmioty odpowiedzialne z największymi ilościami Kremów:");
			foreach (var entityPair in topThreeEntitiesWithMostCreams)
			{
				Console.WriteLine(entityPair);
			}
		}


		//ZADANIE ZAAWANSOWANE
		public void CountProductsWithOneAndMultipleActiveSubstances()
		{
			var oneActiveSubstanceCount = _medicalProducts.Count(p => p.ActiveSubstancesCount == 1);
			var multipleActiveSubstancesCount = _medicalProducts.Count(p => p.ActiveSubstancesCount > 1);
			Console.WriteLine($"Produkty z tylko jedną substancją aktywną: {oneActiveSubstanceCount}");
            Console.WriteLine($"Produkty z wieloma substancjami aktywnymi: {multipleActiveSubstancesCount}");

        }
		public void CountProductsWithCountOfActiveSuvstances()
		{
			var dc = new SortedDictionary<int, int>(); //ilość aktywnych substancji, ilość produktów
			foreach (var product in _medicalProducts)
			{
				var activeSubstancesCount = product.ActiveSubstancesCount ?? -1;
				if (dc.ContainsKey(activeSubstancesCount))
					dc[activeSubstancesCount]++;
				else
					dc.Add(activeSubstancesCount, 1);
			}
			Console.WriteLine("Liczba produktów do liczby aktywnych substancji:");
			foreach (var (activeSubstances, productCount) in dc)
			{
				Console.WriteLine($"{activeSubstances}: {productCount}");
			}
		}
    }
}

