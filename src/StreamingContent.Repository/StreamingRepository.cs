using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class StreamingRepository : StreamingContentRepository
{
    public Show GetShowByTitle(string title)
    {
        //! If _contentDirectory brings up an error, make sure its modifier is 'protected' instead of 'private'
        foreach (StreamingContent content in _contentDirectory)
        {
            if (content.Title.ToLower() == title.ToLower() && content.GetType() == typeof(Show))
            {
                return (Show)content;
            }
        }
        return null;
    }

    public Movie GetMovieByTitle(string title)
    {
        // foreach (StreamingContent content in _contentDirectory)
        // {
        //     if (content.Title.ToLower() == title.ToLower() && content is Movie)
        //     {
        //         return (Movie)content;
        //     }
        // }
        // return null;

        //? Another way to accomplish what is written above
        //? L.I.N.Q
        //? Language Integrated Query

        var movie = _contentDirectory.FirstOrDefault(m => m.Title.ToLower() == title.ToLower());
        return (Movie)movie;
    }

    public List<Show> GetAllShows()
    {
        // Traditional Way
        // var allShows = new List<Show>();
        // foreach (var c in _contentDirectory)
        // {
        //     if (c is Show)
        //     {
        //         allShows.Add((Show)c);
        //     }
        // }
        // return allShows;

        // L.I.N.Q
        // The Where function is just something that will return something if any of the content is a show, and then let's transform it into a new show, and throw it into a List
        var allShows = _contentDirectory.Where(s => s is Show).Select(s => new Show());
        return allShows.ToList();
    }

    public List<Movie> GetAllMovies()
    {
        // Traditional Way
        // var allMovies = new List<Movie>();
        // foreach (var m in _contentDirectory)
        // {
        //     if (m is Movie)
        //     {
        //         allMovies.Add((Movie)m);
        //     }
        // }
        // return allMovies;

        // L.I.N.Q
        return _contentDirectory.Where(m => m is Movie).Select(m => new Movie()).ToList();
    }
}
