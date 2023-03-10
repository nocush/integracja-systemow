// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Xml;

internal class Program
{
    private static void Main(string[] args)
    {

        string xmlpath = Path.Combine("Assets", "data.xml");

        // odczyt danych z wykorzystaniem DOM
        Console.WriteLine("===========================DOM APPROACH===========================");
        IS_Lab1_XML.XMLReadWithDOMApproach.Read(xmlpath);
        
        // odczyt danych z wykorzystaniem SAX
        Console.WriteLine("===========================SAX APPROACH===========================");
        IS_Lab1_XML.XMLReadWithSAXApproach.Read(xmlpath);

        // odczyt danych z wykorzystaniem XPath i DOM
        Console.WriteLine("===========================XML LOADED WITH XPATH===========================");
        IS_Lab1_XML.XMLReadWithXLSTDOM.Read(xmlpath);


        //głębsza analiza
        Console.WriteLine("===========================DEEPER ANALYSIS===========================");
        IS_Lab1_XML.DeeperAnalysis.AnalyzeProducts(xmlpath);

    }
}