using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHealPlayEffect",
    menuName = "CardData/PlayEffects/Heal")]
public class HealPlayEffect : CardPlayEffect
{
    [SerializeField] int _healthRecovered = 1;

    public override void Activate(ITargetable target)
    {
        // test to see if the target is healable
        IHealable objectToHeal = target as IHealable;
        // if it is, apply heal
        if (objectToHeal != null)
        {
            objectToHeal.Heal(_healthRecovered);
            Debug.Log("Healed Target");
        }
        else
        {
            Debug.Log("Target is not healable...");
        }
    }
}
