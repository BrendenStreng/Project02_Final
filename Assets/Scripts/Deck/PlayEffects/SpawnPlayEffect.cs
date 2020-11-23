using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewSpawnPlayEffect",
    menuName = "CardData/PlayEffects/Spawn")]
public class SpawnPlayEffect : CardPlayEffect
{
    [SerializeField] GameObject slime = null;

    public override void Activate(ITargetable target)
    {
        // test to se if the target is damageable
        MonoBehaviour worldObject = target as MonoBehaviour;

        // if it ism apply damage
        if(worldObject != null)
        {
            Vector3 spawnLocation = worldObject.transform.position;
            GameObject gameObject = Instantiate(slime, spawnLocation, Quaternion.Euler(90, -180, 0));
            Debug.Log("Spawn Slime!");
        }
        else
        {
            Debug.Log("Target does not have a transform...");
        }
    }
}
