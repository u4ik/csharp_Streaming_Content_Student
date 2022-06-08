
// This is our POCO (Plain old C# Object)
public class StreamingContent
{
    // Properties
    // Title is our KEY, it is a unique identifier for a single instance of a StreamingContent obj
    public string Title { get; set; }
    public string Description { get; set; }
    public double StarRating { get; set; }
    public MaturityRating MaturityRating { get; set; }
    public bool IsFamilyFriendly
    {
        get
        {
            switch (MaturityRating)
            {
                case MaturityRating.G:
                case MaturityRating.PG:
                case MaturityRating.TV_Y:
                case MaturityRating.TV_G:
                case MaturityRating.TV_PG:
                    return true;
                case MaturityRating.PG_13:
                case MaturityRating.R:
                case MaturityRating.NC_17:
                case MaturityRating.TV_14:
                case MaturityRating.TV_MA:
                default:
                    return false;
            }
        }
    }
    public GenreType TypeOfGenre { get; set; }
    // Constructors
    // Empty constructor
    public StreamingContent() { }
    // Full constructor
    public StreamingContent(
        string title,
        string description,
        double starRating,
        MaturityRating maturityRating,
        GenreType typeOfGenre
    )
    {
        // Local Property (Uppercase) = Parameter Variable (Lowercase)
        Title = title;
        Description = description;
        StarRating = starRating;
        MaturityRating = maturityRating;
        TypeOfGenre = typeOfGenre;
    }
}
