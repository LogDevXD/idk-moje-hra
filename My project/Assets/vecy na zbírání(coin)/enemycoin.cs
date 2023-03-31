using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycoin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Bullet")
        {
            return;
        }

        other.GetComponent<CoinManager>().coinCounter++;
        Destroy(gameObject);
    }
}
