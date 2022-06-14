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
                    CreateNewStreamingContent();
                    break;
                case "4":
                case "four":
                    UpdateExistingContent();
                    break;
                case "5":
                case "five":
                    RemoveContentFromList();
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

    private void RemoveContentFromList()
    {
        Console.Clear();

        List<StreamingContent> contentList = _sRepo.GetAllContent();

        if (contentList.Count() > 0)
        {
            System.Console.WriteLine("Which would you like to remove?");

            int count = 0;

            foreach (var content in contentList)
            {
                count++;
                System.Console.WriteLine($"{count}. {content.Title}");
            }

            int targetContentId = int.Parse(Console.ReadLine());
            int targetIndex = targetContentId - 1;

            if (targetIndex >= 0 && targetIndex < contentList.Count)
            {
                StreamingContent desiredContent = contentList[targetIndex];
                if (_sRepo.DeleteExistingContent(desiredContent))
                {
                    System.Console.WriteLine($"{desiredContent.Title} successfully removed!");
                }
                else
                {
                    System.Console.WriteLine("I'm sorry, unable to remove content!");
                }
            }
            else
            {
                System.Console.WriteLine("No content found that has that ID");
            }
        }

        PauseUntilKeyPress();
    }

    private void CreateNewStreamingContent()
    {
        Console.Clear();

        StreamingContent content = new StreamingContent();

        System.Console.WriteLine("Please enter a title: ");
        content.Title = Console.ReadLine();

        System.Console.WriteLine("Please enter a description: ");
        content.Description = Console.ReadLine();

        System.Console.WriteLine("Please enter a star rating (1-10): ");
        content.StarRating = double.Parse(Console.ReadLine());

        // GiveMeAMaturityRating is my helper method 
        content.MaturityRating = GiveMeAMaturityRating(content);

        System.Console.WriteLine("Select a Genre: \n" +
        "1. Horror\n" +
        "2. RomCom\n" +
        "3. SciFi \n" +
        "4. Documentary \n" +
        "5. Drama \n" +
        "6. Action\n"
        );

        string genreInput = Console.ReadLine();
        int genreId = int.Parse(genreInput);
        content.TypeOfGenre = (GenreType)genreId;

        System.Console.WriteLine("Is this a: \n" +
        "1. Movie\n" +
        "2. Show\n"
        );

        var streamingContentValue = ConvertMe(content);
        System.Console.WriteLine($"Streaming Content is now of type {streamingContentValue.GetType().Name}");

        bool isSuccessfull = _sRepo.AddContentToDirectory(streamingContentValue);
        if (isSuccessfull)
        {
            System.Console.WriteLine($"The content named: {streamingContentValue.Title} WAS ADDED to the DB");
        }
        else
        {
            System.Console.WriteLine($"The content named: {streamingContentValue.Title} WAS NOT ADDED to the DB");
        }


        PauseUntilKeyPress();
    }

    private StreamingContent ConvertMe(StreamingContent content)
    {
        string userInputSC_contentType = Console.ReadLine();
        switch (userInputSC_contentType)
        {
            case "1":
                System.Console.WriteLine("--Movie Creation Menu--");
                System.Console.WriteLine("Please enter this movie's runtime.");
                double movieRuntime = double.Parse(Console.ReadLine());
                var movie = new Movie(
                    content.Title,
                     content.Description,
                      content.StarRating,
                       content.MaturityRating,
                        content.TypeOfGenre,
                         movieRuntime);
                return movie;
            case "2":
                System.Console.WriteLine("--Show Creation Menu--");

                System.Console.WriteLine("Please enter the Season Count:");
                int seasonCount = int.Parse(Console.ReadLine());

                System.Console.WriteLine("Please enter the Season Episode Count: ");
                int episodeCount = int.Parse(Console.ReadLine());

                System.Console.WriteLine("Please enter a average runtime.");
                double showAvgTime = double.Parse(Console.ReadLine());

                return new Show(seasonCount, episodeCount, showAvgTime, content.Title,
                     content.Description,
                      content.StarRating,
                       content.MaturityRating,
                        content.TypeOfGenre);
            default:
                System.Console.WriteLine("Sorry, invalid selection. Returning Default Type (Streaming Content)");
                return content;
        }
    }

    // Helper Method
    private MaturityRating GiveMeAMaturityRating(StreamingContent content)
    {
        System.Console.WriteLine("Select a Maturity Rating:\n" +
        "1.G\n" +
        "2.PG\n" +
        "3.PG 13\n" +
        "4.R\n" +
        "5.NC 17\n" +
        "6.TV Y\n" +
        "7.TV G\n" +
        "8.TV PG\n" +
        "9.TV 14\n" +
        "10.TV MA\n"
        );

        string maturityRating = Console.ReadLine();

        switch (maturityRating)
        {
            case "1":
                return MaturityRating.G;
            case "2":
                return MaturityRating.PG;
            case "3":
                return MaturityRating.PG_13;
            case "4":
                return MaturityRating.R;
            case "5":
                return MaturityRating.NC_17;
            case "6":
                return MaturityRating.TV_Y;
            case "7":
                return MaturityRating.TV_G;
            case "8":
                return MaturityRating.TV_PG;
            case "9":
                return MaturityRating.TV_14;
            case "10":
                return MaturityRating.TV_MA;
            default:
                System.Console.WriteLine("Invalid selection");
                return MaturityRating.G;
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

    private void UpdateExistingContent()
    {
        Console.Clear();

        System.Console.WriteLine("Please enter a title:");
        string userInputTitle = Console.ReadLine();

        StreamingContent oldContent = _sRepo.GetContentByTitle(userInputTitle);

        if (oldContent != null)
        {
            Console.Clear();

            StreamingContent newContent = new StreamingContent();
            System.Console.WriteLine("Please enter in a new title:");
            newContent.Title = Console.ReadLine();

            System.Console.WriteLine("Please enter in a new description:");
            newContent.Description = Console.ReadLine();

            System.Console.WriteLine("Please enter in a new star rating (1-10)");
            newContent.StarRating = double.Parse(Console.ReadLine());

            newContent.MaturityRating = GiveMeAMaturityRating(newContent);

            System.Console.WriteLine("Select a new genre: \n" +
            "1. Horror \n" +
            "2. RomCom \n" +
            "3. SciFi \n" +
            "4. Documentary \n" +
            "5. Drama \n" +
            "6. Action \n");

            string genreInput = Console.ReadLine();
            int genreId = int.Parse(genreInput);

            newContent.TypeOfGenre = (GenreType)genreId;

            System.Console.WriteLine("Is this a: \n" +
            "1. Movie \n" +
            "2. Show"
            );

            var streamingContentValue = ConvertMe(newContent);
            System.Console.WriteLine($"Streaming Content is now of type: {streamingContentValue.GetType().Name}");

            bool isSuccessful = _sRepo.UpdateExistingContent(oldContent.Title, streamingContentValue);

            if (isSuccessful)
            {
                System.Console.WriteLine($"{newContent.Title} has been updated!");
            }
            else
            {
                System.Console.WriteLine("ERROR!!!");
            }



        }



        PauseUntilKeyPress();
    }

}
