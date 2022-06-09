using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Show : StreamingContent
{
    List<Episode> episodes = new List<Episode>();

    public int SeasonCount { get; set; }
    public int EpisodeCount { get; set; }
    public double AverageTime { get; set; }

    public Show() { }

    public Show(
        int seasonCount,
        int episodeCount,
        double averageTime,
        string title,
        string description,
        double starRating,
        MaturityRating maturityRating,
        GenreType type
    ) : base(title, description, starRating, maturityRating, type)
    {
        SeasonCount = seasonCount;
        EpisodeCount = episodeCount;
        AverageTime = averageTime;
    }

}