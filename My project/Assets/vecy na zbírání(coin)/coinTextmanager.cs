using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class coinTextmanager : MonoBehaviour
{
   public TMP_Text coinCounterText;
   public CoinManager CoinManager;

   private void Update()
   {
       coinCounterText.text = CoinManager.coinCounter.ToString();   
   }
}
