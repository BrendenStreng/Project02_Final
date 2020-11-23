using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddtoStreak : MonoBehaviour
{
    [SerializeField] StreakTracker tracker;
    [SerializeField] AudioClip winSound;


    // on the load of the win screen add 1 point to the current streak counter
    private void Awake()
    {
        AudioHelper.PlayClip2D(winSound, .1f);

        tracker = FindObjectOfType<StreakTracker>();
        tracker._currentStreak += 1;

        tracker.SaveStreak();
    }
}
