package Tasks.POJO;

import java.util.ArrayList;

public class Flat {
    private String region;
    private int roomsNum;
    private double square;
    private double kitchen;
    private double housingpart;
    private ArrayList<Room> rooms;
    private Seller seller;
    public Flat(){
        rooms = new ArrayList<>();
        seller = new Seller();
    }
    public Flat(String region, int roomsNum, double square, double kitchen, double housingpart, ArrayList rooms, Seller seller){
        this.region = region;
        this.roomsNum = roomsNum;
        this.square = square;
        this.kitchen = kitchen;
        this.housingpart = housingpart;
        this.rooms = new ArrayList<>(rooms);
        this.seller = new Seller(seller);
    }

    @Override
    public String toString() {
        String roomsStr = "";
        for (Room room: rooms
             ) {
            roomsStr += String.format("\n\t\t*\t%s", room);
        }

        return  String.format(
                "Квартира: %s район:\n\t" +
                        "площадь: %.2f м кв.\n\t" +
                        "площадь кухни: %.2f м кв.\n\t" +
                        "жилая часть: %.2f м кв.\n\t" +
                        "количество комнат: %d\n\t" +
                        "комнаты: %s\n\t" +
                        "продавец: %s"
                ,region,square,kitchen,housingpart,roomsNum,roomsStr,seller
                );
    }
    static public ArrayList<Integer> getListRoomsNum(ArrayList<Flat> Flats){
        ArrayList<Integer> resArr = new ArrayList<>();
        for (Flat flat:Flats
             ) {
            if (!resArr.contains(flat.getRoomsNum())) resArr.add(flat.getRoomsNum());
        }
        return  resArr;
    }
    public String getRegion() {
        return region;
    }

    public void setRegion(String region) {
        this.region = region;
    }

    public int getRoomsNum() {
        return roomsNum;
    }

    public void setRoomsNum(int roomsNum) {
        this.roomsNum = roomsNum;
    }

    public double getSquare() {
        return square;
    }

    public void setSquare(double square) {
        this.square = square;
    }

    public double getKitchen() {
        return kitchen;
    }

    public void setKitchen(double kitchen) {
        this.kitchen = kitchen;
    }

    public double getHousingpart() {
        return housingpart;
    }

    public void setHousingpart(double housingpart) {
        this.housingpart = housingpart;
    }

    public ArrayList<Room> getRooms() {
        return rooms;
    }

    public void setRooms(ArrayList<Room> rooms) {
        this.rooms = rooms;
    }
    public void addRoom(Room room){
        rooms.add(room);
    }

    public Seller getSeller() {
        return seller;
    }

    public void setSeller(Seller seller) {
        this.seller = seller;
    }
}
