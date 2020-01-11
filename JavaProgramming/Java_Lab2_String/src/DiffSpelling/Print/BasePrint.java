package DiffSpelling.Print;

import DiffSpelling.Spelling.Printable;

public abstract class BasePrint
{

    protected Printable printBehaviour;

    public void PrintString(String str) {
        printBehaviour.print(str);
    }

    public abstract void Display();
}
