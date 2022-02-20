class Lasagna
{
    // Does not take any parameters and returns how many minutes the lasagna should be in the oven. According to the cooking book, the expected oven time in minutes is 40.
    public int ExpectedMinutesInOven() => 40;

    // Takes the actual minutes the lasagna has been in the oven as a parameter and returns how many minutes the lasagna still has to remain in the oven, based on ExpectedMinutesInOven().
    public int RemainingMinutesInOven(int minutesInOven) => ExpectedMinutesInOven() - minutesInOven;

    // Takes the number of layers you added to the lasagna as a parameter and returns how many minutes you spent preparing the lasagna, assuming each layer takes you 2 minutes to prepare.
    public int PreparationTimeInMinutes(int numLayers) => numLayers * 2;

    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int numLayers, int minutesInOven)
    {   
        var prepTime = PreparationTimeInMinutes(numLayers);
        return prepTime + minutesInOven;
    }
}
