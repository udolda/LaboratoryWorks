import java.io.IOException;
import java.util.Scanner;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author ivans
 */

public class Main {
    public static void main(String[] args) throws IOException {
        // TODO code application logic here
        System.out.println("Result: ");
        Article();
    }
    
    public static void Article() throws IOException {
        String g = "https://yandex.ru/search/?text=шла саша по шоссе";
        Document doc = Jsoup.connect(g).get();
            Elements h2Elems = doc.getElementsByAttributeValue("class", "path path_show-https organic__path");
            
            h2Elems.forEach(h2Elem ->{
            Element aElem = h2Elem.child(0);
            String g1 = aElem.attr("href");
            System.out.println(aElem.text());
        });
            
    }

}

