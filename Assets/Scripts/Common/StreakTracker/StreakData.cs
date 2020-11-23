using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StreakData
{
    public int currentStreak;
    public int bestStreak;

    public StreakData(StreakTracker streak)
    {
        currentStreak = streak._currentStreak;
        bestStreak = streak._bestStreak;
    }
}
