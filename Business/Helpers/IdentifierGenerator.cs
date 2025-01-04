namespace Business.Helpers;

public class IdentifierGenerator
{
    public static string GenerateUniqueId() => Guid.NewGuid().ToString();
}
