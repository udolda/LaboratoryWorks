/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.mycompany.maven1;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;

import java.io.IOException;
import java.util.List;

/**
 *
 * @author ivans
 */

public class NewMain {

    /**
     * @param args the command line arguments
     */

    public static void main(String[] args) throws IOException {
        // TODO code application logic here
        System.setProperty("webdriver.chrome.driver","D:\\Документы\\Установочники\\chromedriver.exe");
        WebDriver chromeDriver = new ChromeDriver();

        chromeDriver.get("http://afisha.gid43.ru/rubr/view/id/1/");

        List<WebElement> listLabels = chromeDriver.findElements(By.tagName("filtersCatalog__label"));

        for (WebElement e: listLabels ){
            System.out.println(e.getText() + " " +
                    e.getAttribute("value"));
        }

        chromeDriver.quit();
        /*
        List<Article> articlelist = new ArrayList<>(); 
        Document doc = Jsoup.connect("http://4pda.ru").get();
        Elements h2Elems = doc.getElementsByAttributeValue("class", "list-post-title");
        
        h2Elems.forEach(h2Elem ->{
            Element aElem = h2Elem.child(0);
            String url = aElem.attr("href");
            String title = aElem.child(0).text();
            
            articlelist.add(new Article(url, title));
        });
        
        articlelist.forEach(System.out::println);
        */
    }
    
    
    
}

class Performance {
    private String url;
    private String name;
    private String time;
    private String age;
    
    public Performance (String url, String name) {
            this.url = url;
            this.name = name;
    }
    
    public String Geturl(){
        return url;
    }
    
    public String Getname(){
        return name;
    }
    
    public void Seturl(String url){
        this.url = url;
    }
    
    public void Setname(String name){
        this.name = name;
    }
    
    @Override
        public String toString(){
            return "Название спекталя: \"" + name + "\"." +
                   "Время: " + time +
                   "Возраст: " + age +".";
        }

}
