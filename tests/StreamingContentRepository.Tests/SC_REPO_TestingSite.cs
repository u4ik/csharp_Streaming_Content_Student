using Xunit;

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
}