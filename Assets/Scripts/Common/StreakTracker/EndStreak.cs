using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStreak : MonoBehaviour
{
    [SerializeField] StreakTracker tracker;
    [SerializeField] AudioClip lostSound;

    // on the load of the lose screen add reset current streak counter
    private void Awake()
    {
        AudioHelper.PlayClip2D(lostSound, .1f);

        tracker = FindObjectOfType<StreakTracker>();

        tracker._currentStreak = 0;

        tracker.SaveStreak();
    }
}
