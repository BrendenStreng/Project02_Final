using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreakTracker : MonoBehaviour
{
    public int _currentStreak = 0;
    public int _bestStreak = 0;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Score");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        LoadStreak();
    }

    private void Update()
    {
        if(_currentStreak > _bestStreak)
        {
            _bestStreak = _currentStreak;
        }
    }

    public void SaveStreak()
    {
        SaveSystem.SaveTracker(this);
    }

    public void LoadStreak()
    {
        StreakData data = SaveSystem.LoadStreak();

        _currentStreak = data.currentStreak;
        _bestStreak = data.bestStreak;
    }
}
