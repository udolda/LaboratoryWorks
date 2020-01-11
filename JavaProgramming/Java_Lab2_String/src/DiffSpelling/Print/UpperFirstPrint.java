package DiffSpelling.Print;

import DiffSpelling.Spelling.UpperFirst;

public class UpperFirstPrint extends BasePrint
{
    public UpperFirstPrint()
    {
        printBehaviour = new UpperFirst();
    }

    @Override
    public void Display()
    {
        System.out.print("Начиная с прописных: ");
    }
}
