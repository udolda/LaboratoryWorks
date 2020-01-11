package Examples.Ex1;

import org.w3c.dom.Document;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import javax.xml.parsers.*;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

public class Ex1 {
    private static ArrayList<Employee> employees = new ArrayList<Employee>();

    public static void main(String[] args) {
        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        DocumentBuilder builder;
        Document document;
        try {
            builder = factory.newDocumentBuilder();
             document = builder.parse(new File("resource/xml_EX1.xml"));
        } catch (ParserConfigurationException | SAXException | IOException e) {
            e.printStackTrace();
            return;
        }
        System.out.println("All ok");

        // getDocumentElement возвращает ROOT-элемент XML файла.
        // метод getElementsByTagName("employee") возвращает список всех элементов employee внутри корневого элемента
        NodeList employeeElements = document.getDocumentElement().getElementsByTagName("employee");

        // Просмотр всех элементов employee из полученного списка
        for (int i = 0; i < employeeElements.getLength(); i++) {
            Node employee = employeeElements.item(i);

            // Получение атрибутов элемента
            NamedNodeMap attributes = employee.getAttributes();

            // Добавление сотрудника.
            // Так как атрибут это тоже Node, то можно получить значение атрибута с помощью метода getNodeValue()
            employees.add(new Employee(attributes.getNamedItem("name").getNodeValue(), attributes.getNamedItem("job").getNodeValue()));
        }
        for (Employee emp: employees) {
            System.out.println(emp);
        }

    }
}
