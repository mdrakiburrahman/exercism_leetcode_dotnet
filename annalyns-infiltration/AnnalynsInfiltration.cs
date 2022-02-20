using System;

static class QuestLogic
{
    /* 
        A fast attack can be made if the knight is sleeping, as it takes time for him to get his armor on, 
        so he will be vulnerable.
    */
    public static bool CanFastAttack(bool knightIsAwake)
    {
        return !knightIsAwake;
    }

    /* 
        The group can be spied upon if at least one of them is awake. Otherwise, spying is a waste of time.
    */
    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
    {
        return knightIsAwake || archerIsAwake || prisonerIsAwake;
    }
    /* 
        The prisoner can be signalled using bird sounds if the prisoner is awake and the archer is sleeping, 
        as archers are trained in bird signaling so they could intercept the message.
    */
    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
    {
        return prisonerIsAwake && !archerIsAwake;
    }
    /* 
        Can only do in one of 2 ways:
        
        1. If Annalyn has her pet dog with her she can rescue the prisoner if the archer is asleep. 
        The knight is scared of the dog and the archer will not have time to get ready before Annalyn and 
        the prisoner can escape.

        2. If Annalyn does not have her dog then she and the prisoner must be very sneaky! Annalyn can free 
        the prisoner if the prisoner is awake and the knight and archer are both sleeping, but if the prisoner is
        sleeping they can't be rescued: the prisoner would be startled by Annalyn's sudden appearance and wake up 
        the knight and archer.
    */
    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
    {
        // Prisoner is awake
        if (prisonerIsAwake)
        {
            // Has pet dog, archer is asleep - so cannot shoot it down
            if (petDogIsPresent && !archerIsAwake) {
                // Doesn't matter what knight is doing, can rescue prisoner
                return true;
            }
            // Check if knight and archer are both sleeping - doesn't matter if dog is there or not
            if (!knightIsAwake && !archerIsAwake) {
                // Can rescue prisoner since everyone except prisoner is asleep
                return true;
            }
        } 
        // Prisoner is asleep, need to see if dog is there and if archer is asleep too
        else
        {
            if (petDogIsPresent && !archerIsAwake) {
                // Can rescue since Archer is asleep and pet dog is there, knight doesn't matter
                return true;
            }
        }
        return false; // Default
    }
}
