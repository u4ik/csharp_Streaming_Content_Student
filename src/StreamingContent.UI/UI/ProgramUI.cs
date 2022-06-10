using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class ProgramUI
{
    // Creating a connection to the FAKE DB
    private readonly StreamingContentRepository _sRepo = new StreamingContentRepository();

    public void Run()
    {
        //? Seed some data
        SeedContentList();

        //? Run the application
        RunMenu();
    }

    private void RunMenu()
    {
        bool continueToRun = true;
        // We want our app to continuously run until we tell it to STOP!
        while (continueToRun)
        {
            // Clear the console each time
            Console.Clear();
            System.Console.WriteLine("Enter the number of the option you'd like to select: \n" +
            "1. Show All Streaming Content \n" +
            "2. Find Streaming Content By Title \n" +
            "3. Add New Streaming Content \n" +
            "4. Update Existing Content \n" +
            "5. Remove Streaming Content \n" +
            "6. Exit Application \n"
            );

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                case "one":
                    ShowAllContent();
                    break;
                case "2":
                case "two":
                    ShowContentByTitle();
                    break;
                case "3":
                case "three":
                    // CreateNewStreamingContent();
                    break;
                case "4":
                case "four":
                    // UpdateExistingContent();
                    break;
                case "5":
                case "five":
                    // RemoveContentFromList();
                    break;
                case "6":
                case "six":
                    continueToRun = false;
                    System.Console.WriteLine("Thanks for using Streaming Content!");
                    PauseUntilKeyPress();
                    break;
                // In case a user puts "yabababadooo"
                default:
                    System.Console.WriteLine("Please enter a valid number between 1-6");
                    PauseUntilKeyPress();
                    break;
            }
        }

    }
    private void ShowContentByTitle()
    {
        Console.Clear();
        System.Console.WriteLine("Enter a title:");
        string title = Console.ReadLine();
        StreamingContent content = _sRepo.GetContentByTitle(title);
        if (content != null)
        {
            DisplayContent(content);
        }
        else
        {
            System.Console.WriteLine("Invalid title. Could not find a result");
        }

        PauseUntilKeyPress();
    }
    private void PauseUntilKeyPress()
    {
        System.Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    private void ShowAllContent()
    {
        Console.Clear();
        // Because _sRepo returns a List<StreamingContent> we can store this into a container or variable called ListOfContent, for further use
        List<StreamingContent> ListOfContent = _sRepo.GetAllContent();

        // ListOfContent is a collection, so the only way I can see or manipulate the data is by looping or iterating through
        foreach (StreamingContent content in ListOfContent)
        {
            // Helper Method To Display Content
            DisplayContent(content);
        }

        PauseUntilKeyPress();
    }

    // Helper Method To Display Content
    private void DisplayContent(StreamingContent content)
    {
        System.Console.WriteLine($"Title: {content.Title}\n" +
        $"Description: {content.Description}\n" +
        $"Genre: {content.TypeOfGenre}\n" +
        $"Star: {content.StarRating}\n" +
        $"Family Friendly: {content.IsFamilyFriendly}\n" +
        $"Rating: {content.MaturityRating}\n"
        );
    }

    private void SeedContentList()
    {
        // Creating our content for seeding...
        StreamingContent rubber = new StreamingContent("Rubber", "Tire that kills people", 5.8, MaturityRating.R, GenreType.Horror);
        StreamingContent interstellar = new StreamingContent("Interstellar", "A movie about space", 10, MaturityRating.PG_13, GenreType.SciFi);
        StreamingContent starWars = new StreamingContent("Star Wars", "Jar Jar saves the world!", 9.2, MaturityRating.PG_13, GenreType.SciFi);

        // Add the content above to our repository 
        _sRepo.AddContentToDirectory(rubber);
        _sRepo.AddContentToDirectory(interstellar);
        _sRepo.AddContentToDirectory(starWars);

    }
}
