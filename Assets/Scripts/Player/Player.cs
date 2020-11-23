using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ITargetable, IHealable, IBuffable
{
    public int _currentHealth = 30;

    public int damageBuff = 1;

    public HealthBar playerHealthBar;

    private void Start()
    {
        playerHealthBar.SetMaxHealth(_currentHealth);
    }

    private void Update()
    {
        playerHealthBar.SetHealth(_currentHealth);

        if (Input.GetKeyDown(KeyCode.C))
        {
            _currentHealth -= 10;
        }
    }

    public void Target()
    {
        
    }

    public void Heal(int healthRecovered)
    {
        _currentHealth += healthRecovered;
    }

    public void Buff(int buffAmount)
    {
        damageBuff += buffAmount;
    }
}
