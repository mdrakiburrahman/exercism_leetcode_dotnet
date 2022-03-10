using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Authenticator
{
    private class EyeColor
    {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Brey = "grey";
    }
    private Identity admin;
    public Authenticator(Identity admin)
    {
        this.admin = admin;
    }

    // This is called in the tests
    public Identity Admin
    {
        get { return admin; }
    }

    private static IReadOnlyDictionary<string, Identity> developers
        = new ReadOnlyDictionary<string, Identity>(new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = "blue"
            },

            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = "brown"
            }
        });

    public IReadOnlyDictionary<string, Identity> GetDevelopers()
    {
        return developers;
    }
}

public readonly struct Identity
{
    public string Email { get; init; }

    public string EyeColor { get; init; }

}
