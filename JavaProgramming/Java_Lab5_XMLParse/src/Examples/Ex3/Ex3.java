package Examples.Ex3;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

public class Ex3 {
    public static void main(String[] args) {
        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        factory.setNamespaceAware(true);
        Document doc = null;
        try {
            doc = factory.newDocumentBuilder().newDocument();
        } catch (ParserConfigurationException e) {
            e.printStackTrace();
            return;
        }
        Element root = doc.createElement("root");
        root.setAttribute("xmlns", "http://www.javacore.ru/schemas/");
        doc.appendChild(root);

        Element item1 = doc.createElement("item");
        item1.setAttribute("val", "1");
        root.appendChild(item1);

        Element item2 = doc.createElement("item");
        item2.setAttribute("val", "2");
        root.appendChild(item2);

        Element item3 = doc.createElement("item");
        item3.setAttribute("val", "3");
        root.appendChild(item3);


    }
}
