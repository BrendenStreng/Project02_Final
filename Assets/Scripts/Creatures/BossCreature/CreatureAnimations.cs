using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureAnimations : MonoBehaviour
{
    [SerializeField] GameObject creatureImg;

    [SerializeField] GameObject scratchAttack;
    [SerializeField] GameObject fireAttack;
    [SerializeField] GameObject creatureheal;

    // animation for headbutt attack
    public void headbuttPlayer()
    {
        LeanTween.moveY(creatureImg.GetComponent<RectTransform>(), -259, .5f).setLoopPingPong(1);
    }

    public void scratchPlayer()
    {
        //target size
        float targetX = 2.6f;
        float targetY = 2.6f;
        float targetZ = 2.6f;
        Vector3 scaleTarget = new Vector3(targetX, targetY, targetZ);

        scratchAttack.SetActive(true);
        LeanTween.scale(scratchAttack, scaleTarget, .3f).setLoopPingPong(1);
    }

    public void spitFire()
    {
        //target size
        float targetX = 2f;
        float targetY = 2f;
        float targetZ = 2f;
        Vector3 scaleTarget = new Vector3(targetX, targetY, targetZ);

        scratchAttack.SetActive(true);
        LeanTween.scale(fireAttack, scaleTarget, 1f).setLoopPingPong(1);
    }

    public void roarAnimation()
    {
        //target size
        float targetX = 2f;
        float targetY = 2f;
        float targetZ = 2f;
        Vector3 scaleTarget = new Vector3(targetX, targetY, targetZ);

        LeanTween.scale(creatureImg, scaleTarget, .6f).setLoopPingPong(1);
    }
}
