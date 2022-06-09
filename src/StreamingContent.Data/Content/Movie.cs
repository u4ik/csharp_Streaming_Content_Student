using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// A movie can have its own different properties (duration, actors..etc)
// It does however have similar properties to StreamingContent
// We can use Inheritance to receive some of the prefabricated properties in StreamingContent and bring them to this Movie Class
public class Movie : StreamingContent
{

    public double RunTime { get; set; }

    public Movie() { }

    public Movie(
        string title,
        string description,
        double starRating,
        MaturityRating maturityRating,
        GenreType type,
        double runTime
    // Because we're inheriting from StreamingContent, we need to have a :base, so we can reach out to its base constructor
    ) : base(title, description, starRating, maturityRating, type)
    {
        RunTime = runTime;
    }
}
