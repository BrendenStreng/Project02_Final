using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EnemyTurnCardGameState : CardGameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    [SerializeField] float _pauseDuration = 1.5f;
    [SerializeField] GameObject player = null;
    [SerializeField] CreatureAI creatue;
    [SerializeField] GameObject creatureImg;

    private GameObject _slimeToAttack = null;

    public GameObject targetToAttack;

    public override void Enter()
    {
        Debug.Log("Enemy Turn: ...Enter");
        EnemyTurnBegan?.Invoke();

        // on entering state automatically target player
        targetToAttack = player;

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("Enemy Turn: Exit...");
    }

    IEnumerator EnemyThinkingRoutine(float puseDuration)
    {
        Debug.Log("Enemy thinking...");
        yield return new WaitForSeconds(puseDuration);

        // look to see if there are any slimes in play
        _slimeToAttack = GameObject.Find("Slime");
        
        // if a slime is not found target player
        if (_slimeToAttack = null)
        {
            targetToAttack = player;
        }
        // if a slime is found target that slime
        else
        {
            targetToAttack = _slimeToAttack;
        }

        // creature chooses its attack and preforms it
        creatue.ChooseAttack();
        Debug.Log("Enemy performs action");

        // at end of turn, end dragonRage if it was activated
        creatue.isRaging = false;

        EnemyTurnEnded?.Invoke();
        // turn over. Go back to Player
        StateMachine.ChangeState<PlayerTurnCardGameState>();
    }
}
