using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour
{
    //TODO build a more structured connection
    public static ITargetable CurrentTarget;
    // interfaces don't serialize, so need class reference 
    [SerializeField] Creature _creatureToTarget = null;
    [SerializeField] Player _playerToTarget = null;
    [SerializeField] SlimeSpawn _spawnLoc1 = null;
    [SerializeField] SlimeSpawn _spawnLoc2 = null;

    [SerializeField] Image _creatureTargeted;
    [SerializeField] Image _playerTargeted;
    [SerializeField] Image _spawn1Targeted;
    [SerializeField] Image _spawn2Targeted;

    private int targetID = 1;

    private void Start()
    {
        // start out by targeting creature
        ITargetable possibleTarget =
               _creatureToTarget.GetComponent<ITargetable>();
        if (possibleTarget != null)
        {
            Debug.Log("New target acquired!");
            CurrentTarget = possibleTarget;
            _creatureToTarget.Target();
        }
    }

    private void Update()
    {
        if(targetID == 1)
        {
            ITargetable possibleTarget =
               _creatureToTarget.GetComponent<ITargetable>();
            if (possibleTarget != null)
            {
                CurrentTarget = possibleTarget;
                _creatureToTarget.Target();

                _creatureTargeted.gameObject.SetActive(true);
                _playerTargeted.gameObject.SetActive(false);
                _spawn1Targeted.gameObject.SetActive(false);
                _spawn2Targeted.gameObject.SetActive(false);
            }
        }
        else if(targetID == 2)
        {
            ITargetable possibleTarget =
               _playerToTarget.GetComponent<ITargetable>();
            if (possibleTarget != null)
            {
                CurrentTarget = possibleTarget;
                _playerToTarget.Target();

                _creatureTargeted.gameObject.SetActive(false);
                _playerTargeted.gameObject.SetActive(true);
                _spawn1Targeted.gameObject.SetActive(false);
                _spawn2Targeted.gameObject.SetActive(false);
            }
        }
        else if (targetID == 3)
        {
            ITargetable possibleTarget =
               _spawnLoc1.GetComponent<ITargetable>();
            if (possibleTarget != null)
            {
                CurrentTarget = possibleTarget;
                _spawnLoc1.Target();

                _creatureTargeted.gameObject.SetActive(false);
                _playerTargeted.gameObject.SetActive(false);
                _spawn1Targeted.gameObject.SetActive(true);
                _spawn2Targeted.gameObject.SetActive(false);
            }
        }
        else if (targetID == 4)
        {
            ITargetable possibleTarget =
               _spawnLoc2.GetComponent<ITargetable>();
            if (possibleTarget != null)
            {
                CurrentTarget = possibleTarget;
                _spawnLoc2.Target();

                _creatureTargeted.gameObject.SetActive(false);
                _playerTargeted.gameObject.SetActive(false);
                _spawn1Targeted.gameObject.SetActive(false);
                _spawn2Targeted.gameObject.SetActive(true);
            }
        }

        if (targetID > 4)
        {
            targetID = 1;
        }
        else if(targetID < 1)
        {
            targetID = 4;
        }
    }

    public void ToggleTargetLeft()
    {
        targetID -= 1;
    }

    public void ToggleTargetRight()
    {
        targetID += 1;
    }
}
