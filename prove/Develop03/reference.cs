using System;
using System.Collections.Generic;


// Reference class stores the reference of the scripture (book, chapter, and verse)
// It also allows for a range of verses (Hebrews 11: 1-3) to be used, or only a single
// verse as well. It provides the method to return it in the appropriate format. 
class Reference
{

    // this.___ : keyword refers to the current instance of the class, typically used to 
    // distinguid between instance variables and method parameters - helps avoid ambiguity
    // when parameter names are the same as the class fields
        //ex: this.book refers to the instance variable book while book without this. refers
        // to the parameter passed to the constructor. 
    private string book;
    private string chapter;
    private string startVerse;
    private string endVerse;

    public Reference(string book, string chapter, string verse)
    {
        this.book = book;
        this.chapter = chapter;

        //single verse or a range (1-3), declare and initialize the 'verese' array by splitting the input string using '-'
        var verses = verse.Split('-');
        this.startVerse = verses[0]; //start verse is always present
        this.endVerse = verses.Length > 1 ? verses[1] : verses[0]; //if it's a range, use the second verse
    }

    //constructor for the verse range (Hebrews 11: 1-3)
    public Reference(string book, string chapter, string startVerse, string endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }
    // returns the refernc in the format Book Chapter:Verse(s)


    public string GetReference()
    {
        if (startVerse == endVerse) //single verse
        {
        return $"{book} {chapter}:{startVerse}";
        }
        else //range of verses
        {
            return $"{book} {chapter}:{startVerse}-{endVerse}";
        }
    }
}