using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, ITargetable, IDamageable
{
    public int _currentHealth = 50;

    public int _startingHealth;

    [SerializeField] Player player;
    [SerializeField] AudioClip hit;

    public HealthBar creatureHealthBar;

    private void Start()
    {
        _startingHealth = _currentHealth;
        creatureHealthBar.SetMaxHealth(_currentHealth);
    }

    private void Update()
    {
        // if the dragon heals past its starting health stay at starting health
        if(_currentHealth > _startingHealth)
        {
            _currentHealth = _startingHealth;
        }
    }

    public void Kill()
    {
        Debug.Log("Kill the creature!");
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        // take damage multiplied by player buff
        _currentHealth -= damage * player.damageBuff;
        Debug.Log("Took damage. Remaining health: " + _currentHealth);
        AudioHelper.PlayClip2D(hit, .1f);

        //show damage on health bar
        creatureHealthBar.SetHealth(_currentHealth);

        if(_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Target()
    {
        
    }
}
