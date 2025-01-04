namespace Business.Helpers;

public class IdentifierGenerator
{
    //Creates an unique Id for every user in the list
    public static string GenerateUniqueId() => Guid.NewGuid().ToString();
}
