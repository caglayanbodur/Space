using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
   [SerializeField] private GameObject coin;

   public void OpenCoin()
   {
      coin.SetActive(true);
   }
   public void ClosedCoin()
   {
      coin.SetActive(false);
   }
}
