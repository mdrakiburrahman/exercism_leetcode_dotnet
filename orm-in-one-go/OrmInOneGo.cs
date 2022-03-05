using System;

public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        using var db = this.database;
        try
        {
            db.BeginTransaction();
            db.Write(data);
            db.EndTransaction();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool WriteSafely(string data)
    {
        try
        {
            this.Write(data);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
