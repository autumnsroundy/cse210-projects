using System;

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