using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, ITargetable, IDamageable
{
    public int _currentHealth = 50;

    [SerializeField] Player player;

    public HealthBar creatureHealthBar;

    private void Start()
    {
        creatureHealthBar.SetMaxHealth(_currentHealth);
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
