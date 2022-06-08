using Xunit;

public class StreamingContentTestingSite
{
    // Fact in xunit, allows us to run a single test
    [Fact]
    public void SetTitle_ShouldSetCorrectString()
    {
        //? AAA Setup

        //? Arrange
        StreamingContent content = new StreamingContent();
        content.Title = "Toy Story 2";

        //? Act
        string expected = "Toy Story 2";
        string actual = content.Title;

        //? Assert
        Assert.Equal(expected, actual);
    }
    // A Theory allows us to run multiple tests with different arguments
    [Theory]
    [InlineData(MaturityRating.G, true)]
    [InlineData(MaturityRating.TV_G, true)]
    [InlineData(MaturityRating.R, false)]
    [InlineData(MaturityRating.TV_MA, false)]
    public void SetMaturityRating_ShouldGetCorrectFamilyFriendlyValue(MaturityRating maturityRating, bool expectedIsFamilyFriendly)
    {
        //? AAA Setup
        //? Arrange
        StreamingContent content = new StreamingContent(
            "Content Title",
            "Some Description",
            4.2,
           maturityRating,
           GenreType.SciFi
        );
        //? Act
        bool actual = content.IsFamilyFriendly;
        bool expected = expectedIsFamilyFriendly;

        //? Assert
        Assert.Equal(expected, actual);
    }
}