using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    public override bool Equals(object other)
    {
        return EyeColor == (other as FacialFeatures).EyeColor && PhiltrumWidth == (other as FacialFeatures).PhiltrumWidth;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    public override bool Equals(object other)
    {
        return Email == (other as Identity).Email && FacialFeatures.Equals((other as Identity).FacialFeatures);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures.GetHashCode());
    }
}

public class Authenticator
{
    // For storing hashes of the Identities to spot duplicates
    private HashSet<Identity> registered = new HashSet<Identity>();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Equals(new Identity(email: "admin@exerc.ism", facialFeatures: new FacialFeatures("green", 0.9m)));
    }

    public bool Register(Identity identity)
    {
        if (!IsRegistered(identity))
        {
            registered.Add(identity);
            return true;
        }
        return false;
    }

    public bool IsRegistered(Identity identity)
    {
        return registered.Contains(identity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return ReferenceEquals(identityA, identityB);
    }
}
