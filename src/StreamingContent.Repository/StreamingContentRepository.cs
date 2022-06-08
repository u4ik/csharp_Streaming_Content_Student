public class StreamingContentRepository
{
    // This will be our FAKE DB
    // Allow us to interact with it, and to utilize CRUD methods
    private readonly List<StreamingContent> _contentDirectory = new List<StreamingContent>();

    //? Create
    public bool AddContentToDirectory(StreamingContent content)
    {
        // Check the overall count of the items in _contentDirectory
        int startingCount = _contentDirectory.Count();

        // Add content to FAKE DB
        _contentDirectory.Add(content);

        // Checking to see if content was actually added
        bool wasAdded = (_contentDirectory.Count() > startingCount) ? true : false;

        return wasAdded;
    }

    //? Read ALL
    public List<StreamingContent> GetAllContent()
    {
        return _contentDirectory;
    }

    //? Read - Find One By Title
    public StreamingContent GetContentByTitle(string title)
    {
        // Look in _contentDirectory if Title exists
        foreach (StreamingContent content in _contentDirectory)
        {
            if (content.Title == title)
            {
                return content;
            }
        }
        return null;
    }

    //? Update - By Title
    // This update will clear the previous values
    public bool UpdateExistingContent(string originalTitle, StreamingContent newContent)
    {
        // Use a helper method (GetContentByTitle)
        StreamingContent oldContent = GetContentByTitle(originalTitle);

        // Check if oldContent actually exists
        if (oldContent != null)
        {
            oldContent.Title = newContent.Title;
            oldContent.Description = newContent.Description;
            oldContent.StarRating = newContent.StarRating;
            oldContent.TypeOfGenre = newContent.TypeOfGenre;

            return true;
        }
        return false;
    }

    //? Delete
    public bool DeleteExistingContent(StreamingContent content)
    {
        bool deleteResult = _contentDirectory.Remove(content);
        return deleteResult;
    }

    //? Read - Get Content By Genre
    public List<StreamingContent> GetStreamingContentByGenre(GenreType type)
    {
        var genreList = new List<StreamingContent>();
        foreach (var content in _contentDirectory)
        {
            if (content.TypeOfGenre == type)
            {
                genreList.Add(content);
            }
        }
        return genreList;
    }

    /*
    NOTE: CHALLENGES
        - Get by other parameters
        - Get by MaturityRating
        - Get by family friendly
    */
}
