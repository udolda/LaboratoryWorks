package Tasks.Task_DOM;

import Tasks.POJO.Flat;
import Tasks.POJO.Room;
import Tasks.POJO.Seller;
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
import java.util.ArrayList;
import java.util.Scanner;

public class T1 {

    public static void main(String[] args) {
        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        DocumentBuilder builder;
        Document document;
        try {
            builder = factory.newDocumentBuilder();
            document = builder.parse(new File("resource/task1.xml"));
        } catch (ParserConfigurationException | SAXException | IOException e) {
            e.printStackTrace();
            return;
        }
        Scanner scanner = new Scanner(System.in);
        while (true){
            System.out.println("Введите название региона или Enter для вывода всех квартир на экран:");
            String reg = scanner.nextLine().trim();
            ArrayList<Flat> Flats = new ArrayList<>();
            if (reg.isEmpty()) {
                Flats.addAll(GetAllFlat(document));
            } else {
                Flats.addAll(FindFlatByReg(document,reg));
            }
            if (Flats.isEmpty()) System.out.println("Пусто, выросла капуста");
            for (Flat flat : Flats) {
                System.out.println(flat);
                System.out.println();
            }

        }

    }
    private static ArrayList<Flat> FindFlatByReg(Document document, String regionName){
        ArrayList<Flat> flatsList = new ArrayList<>();
        // Все регионы:
        NodeList regionsElements = document.getDocumentElement().getElementsByTagName("region");
        for(int i=0;i<regionsElements.getLength();i++){
            Node region = regionsElements.item(i);
            String regionStr = region.
                    getAttributes().
                    getNamedItem("name").
                    getNodeValue().trim().toLowerCase();
            if (!regionName.toLowerCase().equals(regionStr)) continue;
            flatsList.addAll(GetRegionFlat(region));
            }
        return flatsList;
    }
    private static ArrayList<Flat> GetRegionFlat(Node region){
        ArrayList<Flat> flatsList = new ArrayList<>();
        // Все регионы:
            String regionStr = region.
                    getAttributes().
                    getNamedItem("name").
                    getNodeValue();

            NodeList flatElements = region.getChildNodes();
            for (int j = 0;j<flatElements.getLength();j++){
                Node flatNode = flatElements.item(j);
                if (flatNode.getNodeName()!="flat") continue;
                NamedNodeMap attributes = flatNode.getAttributes();
                Flat flat = new Flat();
                flat.setRegion(regionStr);
                flat.setRoomsNum(Integer.parseInt(attributes.getNamedItem("count").getNodeValue()));
                flat.setSquare(Double.parseDouble(attributes.getNamedItem("square").getNodeValue()));
                flat.setKitchen(Double.parseDouble(attributes.getNamedItem("kitchen").getNodeValue()));
                flat.setHousingpart(Double.parseDouble(attributes.getNamedItem("housingpart").getNodeValue()));

                // Продавец и комнаты в узлах flat
                NodeList flatChildes = flatNode.getChildNodes();
                for (int k = 0;k<flatChildes.getLength();k++){
                    if (flatChildes.item(k).getNodeName() == "seller"){
                        Seller seller = new Seller();
                        NamedNodeMap sellerAttributes = flatChildes.item(k).getAttributes();
                        seller.setTel(sellerAttributes.getNamedItem("tel").getNodeValue());
                        seller.setTitle(sellerAttributes.getNamedItem("title").getNodeValue());
                        flat.setSeller(seller);
                    }
                    if (flatChildes.item(k).getNodeName() == "rooms"){
                        //  в блоке rooms ищем все комнаты room
                        NodeList roomsElements = flatChildes.item(k).getChildNodes();
                        for (int r = 0; r<roomsElements.getLength();r++){
                            if (roomsElements.item(r).getNodeName() == "room"){
                                String inf = roomsElements.item(r).getTextContent().replace("\n", "").trim();
                                if (inf.length()==0) continue;
                                Room room = new Room(Double.parseDouble(inf));
                                flat.addRoom(room);
                            }
                        }

                    }
                }
                flatsList.add(flat);
            }
        return flatsList;
    }
    public static ArrayList<Flat> GetAllFlat(Document document){
        ArrayList<Flat> flatsList = new ArrayList<>();
        // Все регионы:
        NodeList regionsElements = document.getDocumentElement().getElementsByTagName("region");
        for(int i=0;i<regionsElements.getLength();i++) {
            Node region = regionsElements.item(i);
            flatsList.addAll(GetRegionFlat(region));
        }
        return flatsList;
    }
}