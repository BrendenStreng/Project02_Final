using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionAnimation : MonoBehaviour
{
    private void Awake()
    {
        selected();
    }

    public void selected()
    {
        LeanTween.moveLocalY(gameObject, 350, 2).setLoopPingPong();
    }
}
