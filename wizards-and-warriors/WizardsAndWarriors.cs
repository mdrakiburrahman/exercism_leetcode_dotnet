using System;

// var myWarrior = new Warrior();
// var myWizard = new Wizard();

// Console.WriteLine(myWarrior.ToString());
// Console.WriteLine($"Vulnerable: {myWarrior.Vulnerable()}"); // Should be False

// Console.WriteLine("\n");

// Console.WriteLine(myWizard.ToString());
// Console.WriteLine($"Has prepapred spell: {myWizard.hasPreparedSpell}");
// Console.WriteLine($"Vulnerable: {myWizard.Vulnerable()}"); // Should be True
// Console.WriteLine($"Wizard Damage: {myWizard.DamagePoints(myWarrior)}"); // Should be 3
// Console.WriteLine($"Warrior Damage: {myWarrior.DamagePoints(myWizard)}"); // Should be 10

// myWizard.PrepareSpell();

// Console.WriteLine($"Has prepapred spell: {myWizard.hasPreparedSpell}");
// Console.WriteLine($"Vulnerable: {myWizard.Vulnerable()}"); // Should be False
// Console.WriteLine($"Wizard Damage: {myWizard.DamagePoints(myWarrior)}"); // Should be 12
// Console.WriteLine($"Warrior Damage: {myWarrior.DamagePoints(myWizard)}"); // Should be 6

// Parent class
abstract class Character
{
    private string character; // Private because child classes shouldn't need to access it
    protected bool isVulnerable; // Protected so that the child classes can access it
    protected Character(string characterType)
    {
        this.character = characterType;
        this.isVulnerable = false; // Not vulnearable by default
    }

    public abstract int DamagePoints(Character target); // Must be overwritten in child classes as logic is different per character

    public virtual bool Vulnerable()
    {
        return this.isVulnerable;
    }

    public override string ToString()
    {
        return $"Character is a {this.character}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable())
        {
            return 10;
        }
        else
        {
            return 6;
        }
    }
}

class Wizard : Character
{   
    public bool hasPreparedSpell;
    public Wizard() : base("Wizard")
    {
        this.hasPreparedSpell = false;
    }

    public override int DamagePoints(Character target) // Target is not used here
    {
        if (this.hasPreparedSpell)
        {
            return 12;
        }
        else
        {
            return 3;
        }
    }

    public void PrepareSpell()
    {
        this.hasPreparedSpell = true;
    }
    public override bool Vulnerable()
    {
        if (this.hasPreparedSpell == false)        // Has not prepared a spell, so vulnerable
        {
            base.isVulnerable = true;
        } else {                                   // Has prepared a spell, so not vulnerable
            base.isVulnerable = false;
        }
        return this.isVulnerable;
    }
}
