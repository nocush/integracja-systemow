package org.example;

import javax.jws.WebService;
import javax.swing.text.DateFormatter;
import java.text.DateFormat;
import java.time.Duration;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;


@WebService(endpointInterface = "org.example.MyFirstSOAPInterface")
public class MyFirstWS implements MyFirstSOAPInterface {
    public String getHelloWorldAsString(String name) {
        String message = "Witaj "+name+"!";
        return message;
    }
    public long getDaysBetweenDates(String date1, String date2) {
        long days = 0;
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("dd MM yyyy");

        try{
            LocalDate tempdate1 = LocalDate.parse(date1, dtf);
            LocalDate tempdate2 = LocalDate.parse(date2, dtf);
            days = Duration.between(tempdate1.atStartOfDay(), tempdate2.atStartOfDay()).toDays();
        } catch (Exception e){
            e.printStackTrace();
        }

        return days;
    }

}
