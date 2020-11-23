using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    private void Awake()
    {
        selected();
    }

    public void selected()
    {
        LeanTween.moveLocalY(gameObject, -326, 2).setLoopPingPong();
    }
}
