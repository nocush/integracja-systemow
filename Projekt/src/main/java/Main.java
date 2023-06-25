import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.Scanner;
import java.util.Map;
import java.util.HashMap;


public class Main {
    public static void main(String[] args) {
        HttpRequest acctoken = HttpRequest.newBuilder()
                .uri(URI.create("https://accounts.spotify.com/api/token"))
                .header("Content-Type", "application/x-www-form-urlencoded")
                .POST(HttpRequest.BodyPublishers.ofString("grant_type=client_credentials&client_id=e68d79389f1244b0b907fb2173ecbefe&client_secret=a0be6c1860474404873915ee5467ec12"))
                .build();

        HttpResponse<String> response1 = null;
        try {
            response1 = HttpClient.newHttpClient().send(acctoken, HttpResponse.BodyHandlers.ofString());
        } catch (IOException e) {
            e.printStackTrace();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        var token = response1.body().split(":")[1].split(",")[0].replace("\"", "");


            HttpRequest request = HttpRequest.newBuilder()
                    .uri(URI.create("https://api.spotify.com/v1/playlists/37i9dQZEVXbN6itCcaL3Tt/tracks?fields=items%28track%28album%28name%29%29%29"))
                    .header("Authorization","Bearer " + token)
                    .method("GET", HttpRequest.BodyPublishers.noBody())
                    .build();
                    HttpResponse<String> response = null;
            try {
                response = HttpClient.newHttpClient().send(request, HttpResponse.BodyHandlers.ofString());

            } catch (IOException e) {
                e.printStackTrace();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }


            //store names of albums in map of albums and counts
            String[] albums = response.body().split("name");
            for (int i = 1; i < albums.length; i++) {
                albums[i] = albums[i].split("\"")[2];
            }


            //count the number of times each album appears
            Map<String, Integer> albumCounts = new HashMap<>();
            for (int i = 1; i < albums.length; i++) {
                if (albums[i] != null) {
                    if (albumCounts.containsKey(albums[i])) {
                        albumCounts.put(albums[i], albumCounts.get(albums[i]) + 1);
                    } else {
                        albumCounts.put(albums[i], 1);
                    }
                }
            }
            //print out the albums and counts
            for (String s : albumCounts.keySet()) {
                System.out.println(s + ": " + albumCounts.get(s));
            }

            Map<String, Integer> genreCounts = new HashMap<>();
            //get genreid and genrename for each album from deezer api
            for (String s : albumCounts.keySet()) {
                //replace spaces with %20
                s = s.replace(" ", "%20");
                //get album name and genre id
                HttpRequest request2 = HttpRequest.newBuilder()
                        .uri(URI.create("https://api.deezer.com/search/album?q=" + s + "&limit=1"))
                        .header("Accept", "application/json")
                        .method("GET", HttpRequest.BodyPublishers.noBody())
                        .build();
                HttpResponse<String> response2 = null;
                try {
                    response2 = HttpClient.newHttpClient().send(request2, HttpResponse.BodyHandlers.ofString());
                } catch (IOException e) {
                    e.printStackTrace();
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                //get  genre_id
                String[] genre = response2.body().split("genre_id");
                //if index 1 is out of bounds, skip
                if (genre.length < 2) {
                    continue;
                }
                String genreID = genre[1].split(",")[0];
                //System.out.println(albumName);
                //get rid of spare characters from genreID
                genreID = genreID.replace(":", "");
                genreID = genreID.replace("\"", "");
                //save genre id as an int
                int genreIDint = Integer.parseInt(genreID);
                //System.out.println(genreIDint);
                //get genre name for genreIDint
                HttpRequest request3 = HttpRequest.newBuilder()
                        .uri(URI.create("https://api.deezer.com/genre/" + genreIDint))
                        .header("Accept", "application/json")
                        .method("GET", HttpRequest.BodyPublishers.noBody())
                        .build();
                HttpResponse<String> response3 = null;
                try {
                    response3 = HttpClient.newHttpClient().send(request3, HttpResponse.BodyHandlers.ofString());
                } catch (IOException e) {
                    e.printStackTrace();
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                String[] genreName = response3.body().split("name");
                String genreNameString = genreName[1].split("\"")[2];
                //replace %20 with spaces in album name
                s = s.replace("%20", " ");
                System.out.println(s + ": " + genreNameString + " (" + genreIDint + ")");
                if (genreCounts.containsKey(genreNameString)) {
                    genreCounts.put(genreNameString, genreCounts.get(genreNameString) + 1);
                } else {
                    genreCounts.put(genreNameString, 1);
                }

            }
        //print out the genres and counts
        for (String s : genreCounts.keySet()) {
            System.out.println(s + ": " + genreCounts.get(s));
    }
        }
    }