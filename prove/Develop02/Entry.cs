using System;

// Entry Class 
// Function : Storing details about the Journal Entry (Prompt, Response, Date)
class Entry
    {   // important information to store
        // public = access modifier : allows for the prompt/response/date to be accessed in other classes of program
        // constructor = public Entry(string prompt, string response) : defined to initialize the properties of the Entry class
        public string Prompt {get; set;} // the property has a get accessor (retrieve value), and a set accessor (assign value)
        public string Response {get; set;}
        public string Date {get; set;}

        public Entry(string prompt, string response)
        {
            Prompt = prompt;
            Response = response;
            DateTime theCurrentTime = DateTime.Now;
            Date = theCurrentTime.ToShortDateString();
        }
    public override string ToString()   // ToString method override (program display)
        {
        return $"[{Date}] - Prompt: {Prompt}\nResponse: {Response}\n";
        }
    }