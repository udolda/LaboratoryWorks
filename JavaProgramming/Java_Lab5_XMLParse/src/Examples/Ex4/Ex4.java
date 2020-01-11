package Examples.Ex4;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;

import java.io.File;
import java.util.ArrayList;

public class Ex4 {
    private static ArrayList<Examples.Ex4.Employee> employees = new ArrayList<>();
    private static class XMLHandler extends DefaultHandler {
        @Override
        public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
            if (qName.equals("employee")) {
                String name = attributes.getValue("name");
                String job = attributes.getValue("job");
                employees.add(new Examples.Ex4.Employee(name, job));
            }
        }
    }
    public static void main(String[] args) throws Exception {
        SAXParserFactory factory = SAXParserFactory.newInstance();
        SAXParser parser = factory.newSAXParser();
        XMLHandler handler = new XMLHandler();
        parser.parse(new File("resource/xml_EX1.xml"), handler);

        for (Examples.Ex4.Employee emp: employees) {
            System.out.println(emp);
        }
    }
}

