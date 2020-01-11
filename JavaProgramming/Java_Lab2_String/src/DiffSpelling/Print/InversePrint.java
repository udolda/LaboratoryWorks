package DiffSpelling.Print;

import DiffSpelling.Spelling.Inverse;

public class InversePrint extends BasePrint
{
    public InversePrint()
    {
        printBehaviour = new Inverse();
    }

    @Override
    public void Display()
    {
        System.out.print("Строка с изменённым регистром: ");
    }
}
