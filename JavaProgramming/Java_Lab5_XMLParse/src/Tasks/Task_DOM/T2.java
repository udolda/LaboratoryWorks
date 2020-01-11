package Tasks.Task_DOM;

import Tasks.POJO.Flat;
import Tasks.POJO.Room;
import org.w3c.dom.*;
import org.xml.sax.SAXException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.TransformerFactoryConfigurationError;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.ArrayList;

public class T2 {
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
        //Сформировали все
        ArrayList<Flat> Flats = T1.GetAllFlat(document);

        Document doc = builder.newDocument();
        Element root = doc.createElement("supply");
        root.setAttribute("description", "Описание");
        root.setTextContent("Список Всех квартир с атрибутом - район");
        doc.appendChild(root);

        ArrayList<Integer> roomsNum =  Flat.getListRoomsNum(Flats);
        for (int roomCount: roomsNum
             ) {
            Element roomCountElement = doc.createElement("count_of_rooms");
            roomCountElement.setAttribute("count",String.valueOf(roomCount));
            root.appendChild(roomCountElement);
            for (Flat flat: Flats
            ) {
                if (flat.getRoomsNum() == roomCount)
                    AddFlatInTheDoc(doc, roomCountElement, flat);
            }
        }


        writeDocument(doc,"resource/task2_output.xml");

    }

    private static void AddFlatInTheDoc(Document doc, Element root, Flat flat) {
        Element flatElement =  doc.createElement("flat");

        flatElement.setAttribute("region",flat.getRegion());
        flatElement.setAttribute("square",String.format("%.2f", flat.getSquare()));
        flatElement.setAttribute("kitchen",String.format("%.2f", flat.getKitchen()));
        flatElement.setAttribute("housingpart",String.format("%.2f", flat.getHousingpart()));

        //добавление комнат
        Element roomsEl = doc.createElement("rooms");
        for (Room room: flat.getRooms()
             ) {
            Element roomEl = doc.createElement("room");
            roomEl.setTextContent(String.format("%.2f", room.getSquare()));
            roomsEl.appendChild(roomEl);
        }
        flatElement.appendChild(roomsEl);
        //добавление продавца
        Element sellerEl = doc.createElement("seller");
        sellerEl.setAttribute("name",flat.getSeller().getTitle());
        sellerEl.setAttribute("tel",flat.getSeller().getTel());

        flatElement.appendChild(sellerEl);
        root.appendChild(flatElement);

    }

    private static void writeDocument(Document document, String path) throws TransformerFactoryConfigurationError {
        try {
            //объект класса Transformer может использоваться для записи результатов преобразования в различные приемники с помощью метода transform
            Transformer tr = TransformerFactory
                    .newInstance()
                    .newTransformer();
            //Объекты класса DOMSource используются для хранения исходного дерева преобразования в форме дерева объектной модели документа (DOM).
            DOMSource source = new DOMSource(document);
            File f = new File(path);

            FileOutputStream fos = new
                    FileOutputStream(f);
            StreamResult result = new StreamResult(fos);
            System.out.println("Сохраниение в файле: " + f.getAbsolutePath());
            // метод transform(Source xmlSource, Result outputTarget) преобразует XML ресурс в какой-то из классов-наследников класса Result.
            tr.transform(source, result);

        } catch (TransformerException | IOException e) {
            e.printStackTrace(System.out);
        }
    }

}