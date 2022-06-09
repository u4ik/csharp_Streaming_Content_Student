using Xunit;
using System.Collections.Generic;

public class SC_REPO_TestingSite
{
    private StreamingContent _content;
    private StreamingContentRepository _repo;
    public SC_REPO_TestingSite()
    {
        _content = new StreamingContent(
            "Rubber",
            "A tire that kills people",
            5.8,
            MaturityRating.R,
            GenreType.Horror
        );
        _repo = new StreamingContentRepository();
        _repo.AddContentToDirectory(_content);
    }
    //* TESTING CRUD METHODS, which exist in our Repository
    //? CREATE
    [Fact]
    public void AddToDirectory_ShouldGetCorrectBoolean()
    {
        //? AAA Setup

        //? Arrange
        StreamingContent content = new StreamingContent();
        StreamingContentRepository repository = new StreamingContentRepository();

        //? Act
        bool addResult = repository.AddContentToDirectory(content);
        bool expected = true;

        //? Assert
        Assert.Equal(expected, addResult);
    }

    //? READ
    [Fact]
    public void GetDirectory_ShouldGetCorrectCollectionCount()
    {
        //? AAA Setup

        //? Arrange

        StreamingContent content = new StreamingContent();
        StreamingContentRepository repository = new StreamingContentRepository();

        //? Act
        List<StreamingContent> contents = repository.GetAllContent();
        int expectedCount = 0;

        //? Assert
        Assert.Equal(expectedCount, contents.Count);

    }

    //? READ
    [Fact]
    public void GetByTitle_ShouldReturnCorrectContent()
    {
        //? AAA Setup

        //? Arrange is already taken care of in the constructor above^

        //? Action
        StreamingContent searchResult = _repo.GetContentByTitle("Rubber");

        //? Assert
        Assert.Equal(searchResult, _content);
    }

    //? UPDATE
    [Fact]
    public void UpdateExistingContent_ShouldReturnTrue()
    {
        //? Arrange
        StreamingContent newContent = new StreamingContent(
            "Modified Name",
            "Modified Description",
            1.0,
            MaturityRating.PG_13,
            GenreType.SciFi
        );
        //? Act
        bool updatedResult = _repo.UpdateExistingContent("Rubber", newContent);

        //? Assert  
        Assert.True(updatedResult);
    }

    //? DELETE
    [Fact]
    public void DeleteExistingContent_ShouldReturnTrue()
    {
        //? Arrange
        StreamingContent content = _repo.GetContentByTitle("Rubber");

        //? Act
        bool removeResult = _repo.DeleteExistingContent(content);

        //? Assert
        Assert.True(removeResult);
    }
}