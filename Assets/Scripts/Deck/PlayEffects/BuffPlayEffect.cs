using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuffPlayEffect",
    menuName = "CardData/PlayEffects/Buff")]
public class BuffPlayEffect : CardPlayEffect
{
    [SerializeField] int _buffAmount = 1;

    public override void Activate(ITargetable target)
    {
        //test if target
        IBuffable objectToBuff = target as IBuffable;
        // apply buff
        if (objectToBuff != null)
        {
            objectToBuff.Buff(_buffAmount);
            Debug.Log("Healed Target");
        }
        else
        {
            Debug.Log("Target is not healable...");
        }
    }
}
