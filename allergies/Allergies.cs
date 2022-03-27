using System;
using System.Collections.Generic;
using System.Linq;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    public List<Allergen> allergenList { get; set; }
    public Allergies(int mask)
    {
        this.allergenList = new List<Allergen>();
        // Generates list of allergen values
        getFood(mask, this.allergenList);

    }
    public void getFood(int x, List<Allergen> foods)
    {
        // Turn enum into list
        var allergenList = Enum.GetValues(typeof(Allergen)).Cast<Allergen>().ToList();
        
        // If score is zero, nothing to add
        if (x == 0)
        {
            return;
        }

        // Error handle where Allergen[0] > x
        if ((int)allergenList[0] > x)
        {
            throw new ArgumentException("Allergen[0] > x");
        }

        int newscore = 0;

        // Get closest Allergen to x
        for(int i = 0; i < allergenList.Count; i++)
        {
            if (i == allergenList.Count - 1) // End of list
            {
                // If the last food in the list is less than equal to score
                if ((int)allergenList[i] <= x)
                {
                    // If foods List doesn't contain the food, add it in
                    if (!foods.Contains(allergenList[i]))
                    {
                        foods.Add(allergenList[i]);
                    }
                    newscore = x - (int)allergenList[i];
                    break;
                }
            } else {
                // If next one is above score, add current
                if ((int)allergenList[i+1] > x)
                {
                    if (!foods.Contains(allergenList[i]))
                    {
                        foods.Add(allergenList[i]);
                    }
                    newscore = x - (int)allergenList[i];
                    break;
                }
            }
        }

        // Recursive call
        getFood(newscore, foods);
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return this.allergenList.Contains(allergen);
    }

    public Allergen[] List()
    {
        this.allergenList.Reverse(); // Comes out in reverse than expected
        return this.allergenList.ToArray();
    }
}