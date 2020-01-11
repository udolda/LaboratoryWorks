package Examples.Ex2;

import org.w3c.dom.Document;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import java.io.File;
import java.io.IOException;
import java.util.Scanner;

public class Ex2 {
    public static void main(String[] args) {
        String newElement;
        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        DocumentBuilder builder;
        Document document;
        try {
            builder = factory.newDocumentBuilder();
            document = builder.parse(new File("resource/xml_EX2.xml"));
        } catch (ParserConfigurationException | SAXException | IOException e) {
            e.printStackTrace();
            return;
        }
        System.out.println("Введите название элемента: ");
        Scanner scanner = new Scanner(System.in);
        newElement = scanner.nextLine();

        //2

        // Результат - список элементов. В данном случае, для удобства, рассматривается только первое совпадение в документе.
        // Поиск ведется внутри всего документа, а не рут элемента. Поэтому рут элемент тоже может быть найден.
        NodeList matchedElementsList = document.getElementsByTagName(newElement);

        // Если элемента нет, то будет возвращаться пустой список.
        // Проверка на наличие элементов в списке.
        if (matchedElementsList.getLength() == 0) {
            System.out.println("Тег " + newElement + " не был найден в файле.");
        } else {
            // Получение первого элемента.
            Node foundedElement = matchedElementsList.item(0);

            System.out.println("Элемент был найден!");


            // 3



            // Если элемент имеет данные внутри, то вызываем для него рекурсивный метод получения всей информации
            if (foundedElement.hasChildNodes())
                printInfoAboutAllChildNodes(foundedElement.getChildNodes());
            else{
                System.out.println("Найден элемент: " + foundedElement.getNodeName() + ", его атрибуты:");

                // Получение атрибутов
                NamedNodeMap attributes = foundedElement.getAttributes();

                // Вывод информации о полученных атрибутах.
                for (int k = 0; k < attributes.getLength(); k++)
                    System.out.println("\tИмя атрибута: " + attributes.item(k).getNodeName() + ", его значение: " + attributes.item(k).getNodeValue());
            }
        }

    }
    /**
     * Рекурсивный метод, который выводит информацию про все узлы внутри всех узлов.
     * @param list Список узлов.
     */
    private static void printInfoAboutAllChildNodes(NodeList list) {
        for (int i = 0; i < list.getLength(); i++) {
            Node node = list.item(i);

            // У элементов есть два вида узлов - другие элементы или текстовая информация. Потому нужно разбирать две ситуации отдельно.
            if (node.getNodeType() == Node.TEXT_NODE) {
                // Фильтрация информации, так как начальные и конечные пробелы и переносы строк не нужны. Это не информация.
                String textInformation = node.getNodeValue().replace("\n", "").trim();

                if(!textInformation.isEmpty())
                    System.out.println("Внутри элемента найден текст: " + node.getNodeValue());
            }
            // Если это не текст, а элемент, то его нужно обрабатывать как элемент.
            else {
                System.out.println("Найден элемент: " + node.getNodeName() + ", его атрибуты:");

                // Получение атрибутов
                NamedNodeMap attributes = node.getAttributes();

                // Вывод информации о полученных атрибутах.
                for (int k = 0; k < attributes.getLength(); k++)
                    System.out.println("\tИмя атрибута: " + attributes.item(k).getNodeName() + ", его значение: " + attributes.item(k).getNodeValue());
            }

            // Если у данного элемента еще остались узлы, то вывести всю информацию обо всех его узлах.
            if (node.hasChildNodes())
                printInfoAboutAllChildNodes(node.getChildNodes());
        }
    }

}
