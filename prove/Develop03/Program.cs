using System;

class Program
{
    static void Main(string[] args)
    {
       //create scripture reference and text
       var reference = new Reference("Hebrews", "11", "1-3");
       var scripture = new Scripture(reference, "Now faith is the substance of things hoped for, the evidence of things not seen. For by it the elders obtained a good report. Through faith we understand that the worlds were framed by the word of God, so that things which are seen were not made of things which do appear.");

       //display scripture initally
       DisplayScripture(scripture);

       //keep hiding words until all are hidden
       while (!scripture.AllWordsHidden())
       {
        Console.WriteLine("Press Enter to hide a random word or type 'quit'to exit");
        string userInput = Console.ReadLine().ToLower();

        if (userInput == "quit")
            break;
        else if (userInput =="")
        {
            scripture.HideRandomWord();
            DisplayScripture(scripture);
        }
       }
       Console.WriteLine("Looks like you memorized the entire scripture and all words are hidden. Great job!");
    }
    static void DisplayScripture(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(scripture.GetReference());
        foreach (var word in scripture.GetWords())
        {
            Console.Write(word.IsHidden() ? "______" : word.GetWord() + " ");
        }
        Console.WriteLine();
    }
}