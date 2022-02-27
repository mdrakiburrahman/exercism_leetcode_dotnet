using System;

// 'AccountType' enum
enum AccountType
{
    Guest,
    User,
    Moderator
}

// 'Permission' enum - the [Flags] is what let's us combine
[Flags]
enum Permission : byte
{
    None = 0b00000000,
    Read = 0b00000001,
    Write = 0b00000010,
    Delete = 0b00000100,
    All = Read | Write | Delete
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        switch (accountType)
        {
            case AccountType.Guest:
                return Permission.Read;
            case AccountType.User:
                return Permission.Read | Permission.Write;
            case AccountType.Moderator:
                return Permission.All;
            default:
                return Permission.None;
        }
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        return (current | grant);
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        return (Permission)(current & ~revoke);
    }

    public static bool Check(Permission current, Permission check)
    {
        return (current & check) == check;
    }
}
