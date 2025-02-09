using System;

//Word class represents the individual words in the scripture and includes a method to hide the word
//and check if it is hidden. Simplest of the four classes used in the program. 
class Word
{
    private string word;
    private bool hidden;

    public Word(string word)
    {
        this.word = word;
        this.hidden = false;
    }

    public string GetWord()
    {
        return word;
    }

    public void Hide()
    {
        hidden = true;
    }
    public bool IsHidden()
    {
        return hidden;
    }

}