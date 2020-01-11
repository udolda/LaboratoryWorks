package DiffSpelling.Print;

import DiffSpelling.Spelling.Sentence;

public class SentencePrint extends BasePrint
{
    public SentencePrint()
    {
        printBehaviour = new Sentence();
    }

    @Override
    public void Display()
    {
        System.out.print("Предложение: ");
    }
}
