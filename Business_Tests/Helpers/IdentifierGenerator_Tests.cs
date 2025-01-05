using Business.Helpers;

namespace Business_Tests.Helpers;

public class IdentifierGenerator_Tests
{
    [Fact]

    public void GenerateUniqueId_ShouldReturnStringOfTypeGuid()
    {
        //Test verifies that the generated ID is unique nad type of GUID


        //ACT
        string id1 = IdentifierGenerator.GenerateUniqueId();
        string id2 = IdentifierGenerator.GenerateUniqueId();

        //ASSERT 
        Assert.False(string.IsNullOrEmpty(id1));

        //The generated ID should be a valid GUID
        Assert.True(Guid.TryParse(id1, out _));

        //Verfies that both Id´s are unique
        Assert.NotEqual(id1, id2);
    }
}
