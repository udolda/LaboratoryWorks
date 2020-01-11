package Tasks.Task_SAX;

import Tasks.POJO.Flat;
import Tasks.POJO.Room;
import Tasks.POJO.Seller;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;

public class T1_2 {
    private static ArrayList<Flat> flatArrayList = new ArrayList<>();
    private static String NameRegion;
    private static class XMLHandler extends DefaultHandler {
        Flat currFlat;
        Room currRoom;
        Boolean IsOurRegion = false;
        Boolean IsReadFlat = false;
        Boolean IsReadRoom = false;

        @Override
        public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
            if (qName.equals("region")) {
                if (NameRegion.toLowerCase().equals(attributes.getValue("name").toLowerCase()))
                    IsOurRegion = true;
                else IsOurRegion = false;
            }
            if (qName.equals("flat") && IsOurRegion) {
                IsReadFlat = true;
                currFlat = new Flat();
                currFlat.setRegion(NameRegion);
                currFlat.setRoomsNum(Integer.parseInt(attributes.getValue("count")));
                currFlat.setHousingpart(Double.parseDouble(attributes.getValue("housingpart")));
                currFlat.setKitchen(Double.parseDouble(attributes.getValue("kitchen")));
                currFlat.setSquare(Double.parseDouble(attributes.getValue("square")));

            }
            if (qName.equals("room")) {

                if (IsReadFlat) {
                    IsReadRoom = true;
                    currRoom = new Room();
                }
            }
            if (qName.equals("seller")) {
                if (IsReadFlat) {
                    Seller curSeller = new Seller();
                    curSeller.setTel(attributes.getValue("tel"));
                    curSeller.setTitle(attributes.getValue("title"));
                    currFlat.setSeller(curSeller);
                }
            }
        }

        @Override
        public void endElement(String uri, String localName, String qName) throws SAXException {
            if (qName.equals("flat") && IsOurRegion) {
                flatArrayList.add(currFlat);
                IsReadFlat = false;
            }
            if (qName.equals("room") && IsReadFlat) {
                currFlat.addRoom(currRoom);
                IsReadRoom = false;
            }

        }


        @Override
        public void characters(char[] ch, int start, int length) throws SAXException {
            String information = new String(ch, start, length);

            information = information.replace("\n", "").trim();
            if (!information.isEmpty()) {
                if (IsReadRoom)
                    currRoom.setSquare(Double.parseDouble(information));
            }

        }
    }

        public static void main(String[] args) throws Exception {
            SAXParserFactory factory = SAXParserFactory.newInstance();
            SAXParser parser = factory.newSAXParser();
            XMLHandler handler = new XMLHandler();

            Scanner scanner = new Scanner(System.in);
            while (true){
                System.out.println("Введите название региона или Enter для вывода всех квартир на экран:");
                NameRegion = scanner.nextLine().trim();
                flatArrayList.clear();
                parser.parse(new File("resource/task1.xml"), handler);
                if (flatArrayList.isEmpty()) System.out.println("Пусто, выросла капуста");
                for (Flat flat : flatArrayList) {
                    System.out.println(flat);
                    System.out.println();
                }

            }
        }
    }
