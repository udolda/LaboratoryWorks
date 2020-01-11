package Tasks.POJO;

public class Seller {
    private String title;
    private String tel;
    public  Seller(Seller seller){
        this.title = seller.title;
        this.tel = seller.tel;
    }
    public  Seller(){}
    public Seller(String Title, String Telephone){
        title = Title;
        tel = Telephone;
    }

    @Override
    public String toString() {
        return String.format("%s\n\t\t%s",title,tel);
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getTel() {
        return tel;
    }

    public void setTel(String tel) {
        this.tel = tel;
    }
}
