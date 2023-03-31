using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemykill : MonoBehaviour
{
    
    void  OnTriggerEnter(Collider other)
    {
       if(other.tag != "Bullet") 
        {
            return;
        }

        Destroy(gameObject);
    }
}
