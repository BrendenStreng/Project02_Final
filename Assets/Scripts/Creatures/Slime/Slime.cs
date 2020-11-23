using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slime : MonoBehaviour, ITargetable,  IHealable
{
    public int _currentHealth = 10;

    //public HealthBar slimeHealthBar;

    private void Start()
    {
        //slimeHealthBar.SetMaxHealth(_currentHealth);
    }

    void Update()
    {
        //slimeHealthBar.SetHealth(_currentHealth);

        if (_currentHealth <= 0)
        {
            Kill();
        }
        else
        {
            gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _currentHealth -= 10;
        }
    }

    public void Kill()
    {
        Debug.Log("Slime died!");
        Destroy(gameObject);
    }

    public void Heal(int healthRecovered)
    {
        _currentHealth += healthRecovered;
    }

    public void Target()
    {
        Debug.Log("Creature has been targeted.");
    }
}
