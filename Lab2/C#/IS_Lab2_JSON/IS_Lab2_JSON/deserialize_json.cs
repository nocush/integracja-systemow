using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

public class DeserializeJson
{
    public DeserializeJson(string filepath)
    {
        Console.WriteLine("let's deserialize something");
        var tempdata = new StreamReader(filepath,encoding:System.Text.Encoding.UTF8);
        var json = tempdata.ReadToEnd();
        Data = JsonConvert.DeserializeObject<List<Dictionary<string, object?>>>(json)!;
    }



    public List<Dictionary<string, object?>> Data { get; set; }

    public void somestats()
    {
        HashSet<String> typy = new HashSet<String>();
        HashSet<String> wojewodztwa_nazwy = new HashSet<String>();

        foreach (var dep in Data)
        {
            typy.Add(dep["typ_JST"]!.ToString()?.Trim());
            var woj = dep["Województwo"]!.ToString()?.Trim();
            if(woj != null) wojewodztwa_nazwy.Add(woj);
        }
        typy.ToList<String>().ForEach(x => Console.WriteLine(x));
        wojewodztwa_nazwy.ToList<String>().ForEach(x => Console.WriteLine(x));

        foreach( string wojewodztwo in wojewodztwa_nazwy)
        {
            Console.WriteLine(wojewodztwo);
            foreach(string typ in typy)
            {
                var count = 0;
                foreach(var dep in Data)
                {
                    if (dep["typ_JST"].ToString() == typ && dep["Województwo"].ToString() == wojewodztwo)
                    {
                        count += 1;
                    }
                }
                Console.WriteLine(typ + ": " + count.ToString());
            }
        }
    }
}