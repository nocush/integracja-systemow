package org.example;

import org.example.MyFirstWS;

import javax.xml.ws.Endpoint;

public class MyFirstSOAPPublisher {
    public static void main(String[] args) {
        Endpoint.publish("http://localhost:8080/ws/first", new MyFirstWS());
    }
}
