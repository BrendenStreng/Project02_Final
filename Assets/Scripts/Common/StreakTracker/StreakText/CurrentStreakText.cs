using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentStreakText : MonoBehaviour
{

    [SerializeField] Text currentStreaktxt;
    [SerializeField] StreakTracker tracker;

    private void Awake()
    {
        tracker = FindObjectOfType<StreakTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        currentStreaktxt.text = "Current Streak: " + tracker._currentStreak.ToString();
    }
}
