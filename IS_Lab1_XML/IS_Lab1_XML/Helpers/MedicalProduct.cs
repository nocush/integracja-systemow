using System;
namespace IS_Lab1_XML.Helpers
{
	public class MedicalProduct
	{
		public string? CommonName { get; set; } = string.Empty;
		public string? Form { get; set; } = string.Empty;
		public int? ActiveSubstancesCount { get; set; }
		public string? EntityResponsible { get; set; } = string.Empty;

        public override string ToString()
        {
			return "Produkt leczniczy[" + $"CommonName: {CommonName}, " +
				$"Forma: {Form}, " +
				$"Ilość substancji czynnych: {ActiveSubstancesCount}, " +
				$"Jednostka odpowiedzialna: {EntityResponsible}]";

		}


	}
}

