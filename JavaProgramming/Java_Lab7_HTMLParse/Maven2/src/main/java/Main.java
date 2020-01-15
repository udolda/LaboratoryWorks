import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
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

    /**
     * @param args the command line arguments
     */

    public static void main(String[] args) throws IOException {
        // TODO code application logic here
        Scanner imp = new Scanner(System.in);
        System.out.println("Enter searching request:");
        String search = imp.nextLine();
        System.out.println("Enter number of Links:");
        int number = imp.nextInt();
        System.out.println("Result: ");
        Article(search, number);
    }
    
    public static void Article(String url, int number) throws IOException {
        String g = "https://www.google.com/search?q=" + url +"&num=" + number + "";
        Document doc = Jsoup.connect(g).get();
            Elements h2Elems = doc.getElementsByAttributeValue("class", "TbwUpd");
            h2Elems.forEach(h2Elem ->{
            Element aElem = h2Elem.child(0);
            System.out.println(aElem.text());
        });
            
    }

}


