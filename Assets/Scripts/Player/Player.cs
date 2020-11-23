using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ITargetable, IHealable, IBuffable
{
    public int _currentHealth = 30;
    private int _startingHealth;

    public int damageBuff = 1;

    public HealthBar playerHealthBar;

    [SerializeField] AudioClip gulp;

    private void Start()
    {
        playerHealthBar.SetMaxHealth(_currentHealth);
        _startingHealth = _currentHealth;
    }

    private void Update()
    {
        playerHealthBar.SetHealth(_currentHealth);

        if (damageBuff < 1)
        {
            damageBuff = 1;
        }

        if(_currentHealth > _startingHealth)
        {
            _currentHealth = _startingHealth;
        }
    }

    public void Target()
    {
        
    }

    public void Heal(int healthRecovered)
    {
        _currentHealth += healthRecovered;
        AudioHelper.PlayClip2D(gulp, .1f);
    }

    public void Buff(int buffAmount)
    {
        damageBuff += buffAmount;
        AudioHelper.PlayClip2D(gulp, .1f);
    }
}
