package DiffSpelling.Print;

import DiffSpelling.Spelling.Upper;

public class UpperPrint extends BasePrint
{
    public UpperPrint()
    {
        printBehaviour = new Upper();
    }

    @Override
    public void Display()
    {
        System.out.print("Все прописные: ");
    }
}
