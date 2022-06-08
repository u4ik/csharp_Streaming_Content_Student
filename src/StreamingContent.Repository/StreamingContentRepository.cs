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
}
