using System;
using System.Collections.Generic;

class Reference
{
    private string book;
    private string chapter;
    private string verse;

    public Reference(string book, string chapter, string verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.verse =verse;
    }

    public string GetReference()
    {
        return $"{book} {chapter}:{verse}";
    }
}