using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestStreak : MonoBehaviour
{
    [SerializeField] Text bestStreaktxt;
    [SerializeField] StreakTracker tracker;

    private void Awake()
    {
        tracker = FindObjectOfType<StreakTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        bestStreaktxt.text = "Best Streak: " + tracker._bestStreak.ToString();
    }
}
