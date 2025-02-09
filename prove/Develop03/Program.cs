using System;


// Program class initializes the scripture object with a reference and the entire scripture (text)
// continues prompting the user to press enter as words become slowly hidden at random. As
// a stretch challenge, I made sure there would not be any words selected to hide that were already
// hidden. If user wants to quit, they can type 'quit' to end the program loop.
class Program
{
    // static : is used to define class members that belong to the class itself, rather than to 
    // instances of the class - used if method should be accessible at the class level
    // void : keyword indicates a method does not return any value - method perfroms some actions
    // but does not produce a return
    static void Main(string[] args)
    {
       //create scripture reference and text
       var reference = new Reference("Hebrews", "11", "1-3");
       var scripture = new Scripture(reference, "Now faith is the substance of things hoped for, the evidence of things not seen. For by it the elders obtained a good report. Through faith we understand that the worlds were framed by the word of God, so that things which are seen were not made of things which do appear.");

       //uses Displayscripture method to display scripture initally
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
            scripture.HideRandomWord(); //calls HideRandomWord method from scripture.cs
            DisplayScripture(scripture);
        }
       }
       Console.WriteLine("Looks like you memorized the entire scripture and all words are hidden. Great job!");
    }

    //Display scripture method clears the console and prints the scripture with hidden.words
    //displayed as _______
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