using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

public class SerializeData
{
    public string? kod_teryt { get; set; }
    public string? wojewodztwo { get; set; }
    public string? powiat { get; set; }
    public string? typ_jst { get; set; }
    public string? nazwa_urzedu { get; set; }
    public string? miejscowosc { get; set; }
    public string? telefon_z_kierunkowym { get; set; }

}
public class SerializeJson
{
    public static void run(string inputfilepath, string filepath)
    {
        var tempdata = new StreamReader(inputfilepath, encoding: System.Text.Encoding.UTF8);
        var json = tempdata.ReadToEnd();
        var Data = JsonConvert.DeserializeObject<List<Dictionary<string, object?>>>(json);
        Console.WriteLine("let's serialize something");

        var lst = new List<SerializeData>();

        foreach (var dep in Data)
        {
            var data = new SerializeData
            {
                kod_teryt = dep["Kod_TERYT"].ToString(),
                wojewodztwo = dep["Województwo"].ToString(),
                powiat = dep["Powiat"].ToString(),
                typ_jst = dep["typ_JST"].ToString(),
                nazwa_urzedu = dep["nazwa_urzędu_JST"].ToString(),
                miejscowosc = dep["miejscowość"].ToString(),
                telefon_z_kierunkowym = dep["telefon kierunkowy"].ToString() + ' ' + dep["telefon"]

            };
            lst.Add(data);
        }
        var json2 = JsonConvert.SerializeObject(lst);
        //File.Open(filepath,FileMode.Append,FileAccess.Write);
        File.WriteAllText(filepath, json2);

    }
}