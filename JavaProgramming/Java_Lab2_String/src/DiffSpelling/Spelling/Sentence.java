package DiffSpelling.Spelling;


public class Sentence implements Printable
{

    @Override
    public void print(String str)
    {
        boolean endSentence = true;
        var length = str.length();

        for (var i = 0; i < length; i++)
        {
            var temp = String.valueOf(str.charAt(i));
            if (endSentence)
            {
                System.out.print(temp.toUpperCase());
                if (Character.isLetter(str.charAt(i)))endSentence = false;
            }
            else System.out.print(temp.toLowerCase());
            if (temp.equals(".") || temp.equals("!") || temp.equals("?")) endSentence = true;
        }
        System.out.println();
    }
}
