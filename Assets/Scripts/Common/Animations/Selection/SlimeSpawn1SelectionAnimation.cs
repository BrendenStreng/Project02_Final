using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawn1SelectionAnimation : MonoBehaviour
{
    private void Awake()
    {
        selected();
    }

    public void selected()
    {
        LeanTween.moveLocalY(gameObject, 69, 2).setLoopPingPong();
    }
}
