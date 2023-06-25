import netscape.javascript.JSObject;

import java.io.InputStream;
import java.net.URL;
import org.json.JSONObject;
import org.json.JSONArray;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.stream.Collectors;

public class Client {
    String url_temp;
    URL url;
    InputStream is;
    String src;
    JSONObject json;
    JSONArray recieveData;

    public Client(){
        try{
            url_temp = "http://localhost:8080/cities/read/1";
            url = new URL(url_temp);

            System.out.println("Wysyłanie zapytania do serwera...");
            is = url.openStream();

            System.out.println("Oczekiwanie na odpowiedź serwera...");
            src = new BufferedReader(new InputStreamReader(is)).lines().collect(Collectors.joining());

            System.out.println("Przetwarzanie danych...");
            json = new JSONObject(src);
            recieveData = (JSONArray) json.get("cities");

            System.out.println("ID miasta: " + recieveData.getJSONObject(0).get("ID"));
            System.out.println("Nazwa miasta: " + recieveData.getJSONObject(0).get("Name"));
            System.out.println("Kod kraju miasta: " + recieveData.getJSONObject(0).get("CountryCode"));
            System.out.println("Dystrykt miasta: " + recieveData.getJSONObject(0).get("District"));
            System.out.println("Liczba ludności: " + recieveData.getJSONObject(0).get("Population"));
        }
        catch(Exception e){
            System.out.println("Wystąpił nieoczekiwany błąd!!!");
            e.printStackTrace(System.err);
        }
    }
}
