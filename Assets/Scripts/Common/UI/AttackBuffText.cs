using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBuffText : MonoBehaviour
{
    [SerializeField] Text _attackBuffTxt;
    [SerializeField] Player player;

    // Update is called once per frame
    void Update()
    {
        _attackBuffTxt.text = "Attack Buff x" + player.damageBuff.ToString();
    }
}
