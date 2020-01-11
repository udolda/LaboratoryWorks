package Tasks.POJO;

public class Room {
    private double square;
    public Room(double Square){
        square = Square;
    }

    public Room() {

    }
    @Override
    public String toString() {
        return String.format("Комната: %.2f м кв.",square);
    }

    public double getSquare() {
        return square;
    }

    public void setSquare(double square) {
        this.square = square;
    }
}
