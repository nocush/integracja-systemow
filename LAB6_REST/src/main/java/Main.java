public class Main {
    public static void main(String[] args) {
        Client client = new Client();
        for(int i=0; i<client.recieveData.length(); i++){
            System.out.println("ID miasta: " + client.recieveData.getJSONObject(i).get("ID"));
            System.out.println("Nazwa miasta: " + client.recieveData.getJSONObject(i).get("Name"));
            System.out.println("Kod kraju miasta: " + client.recieveData.getJSONObject(i).get("CountryCode"));
            System.out.println("Dystrykt miasta: " + client.recieveData.getJSONObject(i).get("District"));
            System.out.println("Liczba ludności: " + client.recieveData.getJSONObject(i).get("Population"));
            System.out.println("=======================================================================");
        }
    }
}
