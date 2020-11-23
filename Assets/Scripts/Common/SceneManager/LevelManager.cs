using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Creature creature;
    [SerializeField] StreakTracker tracker;

    private void Awake()
    {
        tracker = FindObjectOfType<StreakTracker>();
    }


    private void Update()
    {
        if(player._currentHealth <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }

        if(creature._currentHealth <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
