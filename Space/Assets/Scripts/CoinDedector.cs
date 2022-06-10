using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDedector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Foots")
        {
            GetComponentInParent<Coin>().ClosedCoin();
            FindObjectOfType<Score>().WinCoin();
        }
    }
}
