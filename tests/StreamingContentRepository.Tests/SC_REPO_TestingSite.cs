using Xunit;
using System.Collections.Generic;

public class SC_REPO_TestingSite
{
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
}