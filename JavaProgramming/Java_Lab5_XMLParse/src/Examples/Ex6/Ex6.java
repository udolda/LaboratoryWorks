package Examples.Ex6;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;

import java.io.File;
import java.util.Scanner;

public class Ex6 {

    private static class SearchingXMLHandler extends DefaultHandler {
        private String element;
        private boolean isEntered = false;

        public SearchingXMLHandler(String element) {
            this.element = element;
        }

        @Override
        public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
            if (qName.equals(element)) {
                isEntered = true;
            }
            if (isEntered) {
                System.out.println(String.format("Найден элемент <%s>, его атрибуты:", qName));

                int length = attributes.getLength();
                for(int i = 0; i < length; i++)
                    System.out.println(String.format("Имя атрибута: %s, его значение: %s", attributes.getQName(i), attributes.getValue(i)));
            }

        }
        @Override
        public void endElement(String uri, String localName, String qName) throws SAXException {
            if (qName.equals(element))
                isEntered = false;
        }

    }

    public static void main(String[] args) throws Exception {

        SAXParserFactory factory = SAXParserFactory.newInstance();
        SAXParser parser = factory.newSAXParser();




        System.out.println("Введите название элемента: ");
        Scanner scanner = new Scanner(System.in);
        String element = scanner.nextLine();

        SearchingXMLHandler handler = new SearchingXMLHandler(element);
        parser.parse(new File("resource/xml_EX2.xml"), handler);

    }


}


