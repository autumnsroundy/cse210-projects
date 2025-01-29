using System;  //console, datetime, string namespace
using System.Threading;  //Timer class to schedule code run times

// Program class
// Function : Handles user interaction

//Extra effort: The hardest thing for me when keeping a journal is remembering to take the time to do it. 
//For the solution to this issue, I figured I could add a reminder to remind myself(like on my phone 'reminders')
// to actually write a journal entry. In order for this to remain a personal journal, I have intitiated a interactive
// reminder method to encourage the user to initiate the reminder if they would like to. (boolean value)
class Program
{
    static bool reminderEnabled = false; //keep track of boolean value (T or F) reminder status 
    static Timer reminderTimer; // Timer to send periodic reminders for journaling
    static void Main(string[] args) 
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while(true) //infinite loop to keep program running until user chooses to exit
        {
            Console.Clear();  //clears console screen for fresh display after generation
            Console.WriteLine("Journal Program");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Set journal reminder");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Choose an option above: ");

            string choice = Console.ReadLine(); //.ReadLine reads the user input as a string

            switch (choice)   // execute corresponding case based on user input
            {
                case "1":
                // write new entry
                string prompt = promptGenerator.GetRandomPrompt(); //calls GetRandomPrompt from PromptGenerator class
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("Your response: ");
                string response = Console.ReadLine();
                journal.AddEntry(prompt,response); //.AddEntry method adds the user's response to the journal (storing both prompt and response)
                break;

                case "2":
                // display journal 
                journal.DisplayEntries(); //DisplayEntries method displays the date, prompt, and entry. 
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;

                case "3":
                // save journal
                Console.Write("Enter filename to save journal entry: ");
                string saveFilename = Console.ReadLine();
                journal.SaveToFile(saveFilename); //SaveToFile method saves prompt/entry/date to desired location
                Console.ReadKey();
                break;

                case "4":
                // load journal
                Console.Write("Enter filename to load journal: ");
                string loadFilename = Console.ReadLine();
                journal.LoadFromFile(loadFilename); // LoadFromFile method to load entry previously stored in specified file
                Console.ReadKey();
                break;

                case "5":
                // reminder enable/disable
                SetReminder();  //SetReminder method allows users to decide if they want to set a daily reminder
                break;

                case "6":
                //exit
                return;

                default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
            }
        }
    }

    // I figured this could work in the program.cs file becuase its function involves interaction with a user, 
    // which is the same function as the Program class serves. I will have many notes for the code used, since 
    // I did a lot of research to figure it out through trial and error. 
    private static void SetReminder()
    {
        Console.WriteLine("Would you like to set a reminder for your journal entry everyday? (yes/no)");
        string response = Console.ReadLine().Trim().ToLower(); // reads the user's response to the previous question,
        // and converts it to lowercase for easier comparison

        if (response == "yes") //enable feature by setting reminderEnable flag to 'true'
        {
            reminderEnabled = true;
            Console.WriteLine("Great! You will receive a daily reminder at 8:00pm.");
            Console.ReadKey();  // Pauses to ensure you can see the message

            DateTime now = DateTime.Now; //gets current date and time
            DateTime reminderTime = new DateTime(now.Year, now.Month, now.Day, 20, 0, 0); //creates new DateTime object for 8:00pm today
            
            if (now > reminderTime) //if current time is passed 8:00pm we adjust reminder time for tomorrow
            {
                reminderTime = reminderTime.AddDays(1);
            }
            // caluclate the time to wait (in milliseconds) until timer goes off again for 8:00pm tomorrow
            TimeSpan timeToWait = reminderTime - now;
            int delay = (int)timeToWait.TotalMilliseconds;

            reminderTimer =new Timer (ReminderCallback, null, delay, Timeout.Infinite); // Timer = object : will trigger the ReminderCallback method after specified delay(ms) 
            // timeout.infinite means it will only trigger once
            Console.WriteLine($"Reminder is set! It will trigger at {reminderTime.ToShortTimeString()}");
        }
        else if (response == "no")
        {
            reminderEnabled = false;
            Console.WriteLine("There is no reminder set. To change reminder status, return to menu options. ");
            Console.ReadKey();  // Pauses to ensure you can see the message
        }
        else
        {
            Console.WriteLine("Invalid input. Please type 'yes' or 'no'.");
            Console.ReadKey();  // Pauses to ensure you can see the message
        }
    }
    
    private static void ReminderCallback(object state) //ReminderCallback = method
    {
        if (reminderEnabled)
        {
            Console.ForegroundColor = ConsoleColor.Cyan; //changes reminder color to Cyan to stand out from other messages
            Console.WriteLine("\n*** Reminder: Time to write in your journal! ***");
            Console.ResetColor(); //resets to default color so it doesn't remain cyan

            //after the first reminder, we want to reset the timer for the next day
            reminderTimer.Change(86400000, Timeout.Infinite); //86400000 mas = 24 hours
        }
    }
}