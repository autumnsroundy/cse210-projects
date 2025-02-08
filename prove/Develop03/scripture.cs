using System;
using System.Collections.Generic;


class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.words = new List<Word>();

        foreach (var word in text.Split(' '))
        {
            this.words.Add(new Word(word));
        }
    }
    public string GetReference()
    {
        return reference.GetReference();
    }
    public List<Word> GetWords()
    {
        return words;
    }
    public void HideRandomWord()
    {
        Random rand = new Random();
        int index = rand.Next(words.Count);
        while (words[index].IsHidden()) //make sure it is not already hidden
        {
            index =rand.Next(words.Count);
        }
        words[index].Hide();
    }
    public bool AllWordsHidden()
    {
        foreach (var word in words)
        {
            if (!word.IsHidden())
            return false;
        }
        return true;
    }
}