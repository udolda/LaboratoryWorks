package DiffSpelling.Print;

import DiffSpelling.Spelling.Lower;

public class LowerPrint extends BasePrint
{
    public LowerPrint()
    {
        printBehaviour = new Lower();
    }

    @Override
    public void Display()
    {
        System.out.print("Все строчные: ");

    }
}
