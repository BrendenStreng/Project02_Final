using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Creature))]
public class CreatureAI : MonoBehaviour
{
    [SerializeField] public int _numOfRegenerations = 3;

    [SerializeField] Player player;
    [SerializeField] EnemyTurnCardGameState enemyTurn;

    public GameObject target;

    private Creature creature;
    [SerializeField] GameObject scratchImg;

    private float healthPercentage;

    private int randomDie;

    // different health percentages for dragon states
    [SerializeField]  private float state1 = .7f;
    [SerializeField] private float state2 = .4f;
    [SerializeField] private float state3 = .1f;

    private int damageMult = 1;

    // different damage amounts per type of attack
    [SerializeField] int headbuttDamage = 7;
    [SerializeField] int clawDamage = 10;
    [SerializeField] int fireBreathDamage = 15;
    [SerializeField] int healAmt = 7;

    [SerializeField] AudioClip dragonRoar;
    [SerializeField] AudioClip dragonRegen;
    [SerializeField] AudioClip fireBreath;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip ouch;
    [SerializeField] AudioClip growl;


    // number of times the dragon can regen
    [SerializeField] int regenLeft = 3;

    public bool isRaging = false;

    private CreatureAnimations animations;

    private void Start()
    {
        AudioHelper.PlayClip2D(dragonRoar, .1f);

        // get Creature code at start
        creature = GetComponent<Creature>();

        // get code for animations
        animations = gameObject.GetComponent<CreatureAnimations>();
    }

    private void Update()
    {
        // calculate the health percentage
        healthPercentage = creature._currentHealth / creature._startingHealth;

        // check to see if target has changed
        target = enemyTurn.targetToAttack;

        // if the dragon is raging double its damage
        if (isRaging)
        {
            damageMult = 2;
        }
        else
        {
            damageMult = 1;
        }
    }

    public void ChooseAttack()
    {
        // generate a number that will help decide the dragon's action
        randomDie = Random.Range(1, 100);

        // if the boss' is in health percatage is about 70% boss does one of these actions on their turn
        if(healthPercentage >= state1)
        {
            
            // choose action based on random number
            if( randomDie <= 10)
            {
                if (!isRaging)
                {
                    Wait();
                }
                else
                {
                    ChooseAttack();
                }
            }
            else if( randomDie > 10 && randomDie <= 40)
            {
                Headbutt(headbuttDamage);
            }
            else if ( randomDie > 40 && randomDie <= 70)
            {
                ClawSlash(clawDamage);
            }
            else if ( randomDie > 70 && randomDie <= 85)
            {
                Roar();
            }
            else if ( randomDie > 85 && randomDie <= 90)
            {
                Regenerate(healAmt);
            }
            else if ( randomDie > 90)
            {
                DragonRage();
            }
        }
        // if the boss' health is between 70%-40% choose from these actions
        else if (healthPercentage < state1 && healthPercentage >= state2)
        {
            if( randomDie <= 20)
            {
                Headbutt(headbuttDamage);
            }
            else if( randomDie > 20 && randomDie <= 60)
            {
                ClawSlash(clawDamage);
            }
            else if( randomDie > 60 && randomDie <= 70)
            {
                Roar();
            }
            else if( randomDie > 70 && randomDie <= 80)
            {
                Regenerate(healAmt);
            }
            else if( randomDie > 80 && randomDie <= 95)
            {
                FireBreath(fireBreathDamage);
            }
            else if (randomDie > 95)
            {
                DragonRage();
            }
        }
        // if the boss' health is between 40%-10% choose from these actions
        else if (healthPercentage < state2 && healthPercentage >= state3)
        {
            if( randomDie <= 30)
            {
                ClawSlash(clawDamage);
            }
            else if ( randomDie > 30 && randomDie >= 40)
            {
                Roar();
            }
            else if ( randomDie > 40 && randomDie <= 60)
            {
                Regenerate(healAmt);
            }
            else if ( randomDie > 60 && randomDie <= 80)
            {
                FireBreath(fireBreathDamage);
            }
            else if ( randomDie > 80)
            {
                DragonRage();
            }
        }
        // if the boss' health is lower than 10% choose from thse actions
        else if (healthPercentage < state3)
        {
            if( randomDie <= 40)
            {
                ClawSlash(clawDamage);
            }
            else if ( randomDie > 40 && randomDie <= 50)
            {
                Regenerate(healAmt);
            }
            else if ( randomDie > 50 && randomDie <= 80)
            {
                FireBreath(fireBreathDamage);
            }
            else if ( randomDie > 80)
            {
                DragonRage();
            }
        }
    }

    // The different actions the dragon can take
    void Wait()
    {
        Debug.Log("Dragon just waits...");
        AudioHelper.PlayClip2D(growl, .1f);
    }

    void Roar()
    {
        player.damageBuff -= 1 * damageMult;
        Debug.Log("Dragon Roars!");

        AudioHelper.PlayClip2D(dragonRoar, .1f);
        animations.roarAnimation();
    }

    void ClawSlash(int damage)
    {
        Debug.Log("Dragon lashes out with its claws!");

        // if the dragon is targeting player, deal damage to player
        if(target.tag == "Player")
        {
            target.GetComponent<Player>()._currentHealth -= damage * damageMult;
        }
        // if the dragon is targeting a slime, deal damage to the slime
        else
        {
            target.GetComponent<Slime>()._currentHealth -= damage * damageMult;
        }

        AudioHelper.PlayClip2D(hit, .1f);
        AudioHelper.PlayClip2D(ouch, .1f);
        animations.scratchPlayer();
    }

    void Headbutt(int damage)
    {
        Debug.Log("Dragon headbutts!");

        // if the dragon is targeting player, deal damage to player
        if (target.tag == "Player")
        {
            target.GetComponent<Player>()._currentHealth -= damage * damageMult;
        }
        // if the dragon is targeting a slime, deal damage to the slime
        else
        {
            target.GetComponent<Slime>()._currentHealth -= damage * damageMult;
        }

        AudioHelper.PlayClip2D(hit, .1f);
        AudioHelper.PlayClip2D(ouch, .1f);
        animations.headbuttPlayer();
    }

    void FireBreath(int damage)
    {
        Debug.Log("Dragon uses fireBreath!");

        // if the dragon is targeting player, deal damage to player
        if (target.tag == "Player")
        {
            target.GetComponent<Player>()._currentHealth -= damage;
        }
        // if the dragon is targeting a slime, deal damage to the slime
        else
        {
            target.GetComponent<Slime>()._currentHealth -= damage;
        }

        AudioHelper.PlayClip2D(fireBreath, .1f);
        AudioHelper.PlayClip2D(ouch, .1f);
        animations.spitFire();
    }

    void Regenerate(int health)
    {
        if(regenLeft > 0)
        {
            AudioHelper.PlayClip2D(dragonRegen, .1f);
            creature._currentHealth += health;
        }
        regenLeft -= 1;
        Debug.Log("Dragon heals its wounds");
    }

    void DragonRage()
    {
        
        isRaging = true;
        Debug.Log("Dragon goes into a rage and begins to attack!");
   
        // re-roll to get an attack
        ChooseAttack();
    }
}
