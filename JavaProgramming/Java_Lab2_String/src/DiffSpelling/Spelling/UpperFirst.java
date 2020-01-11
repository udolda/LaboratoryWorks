package DiffSpelling.Spelling;

public class UpperFirst implements Printable
{

    @Override
    public void print(String str)
    {
        var length = str.length();
        System.out.print(String.valueOf(str.charAt(0)).toUpperCase());
        for (var i = 1; i < length; i++)
        {
            var temp = String.valueOf(str.charAt(i));
            if (!Character.isLetter(str.charAt(i - 1))) System.out.print(temp.toUpperCase());
            else System.out.print(temp.toLowerCase());
        }
        System.out.println();
    }
}
