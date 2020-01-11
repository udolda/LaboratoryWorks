package DiffSpelling.Spelling;

public class Inverse implements Printable
{

    @Override
    public void print(String str)
    {
        var length = str.length();
        for (var i = 0; i < length; i++)
        {
            var temp = String.valueOf(str.charAt(i));
            if (Character.isUpperCase(str.charAt(i))) System.out.print(temp.toLowerCase());
            else System.out.print(temp.toUpperCase());
        }
        System.out.println();
    }
}
