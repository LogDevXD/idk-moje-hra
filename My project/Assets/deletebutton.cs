using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class deletebutton : MonoBehaviour
{

    public GameObject  button1;

    public void DeleteButton1()
    {
        Destroy(button1.gameObject);
    }
   
    
 }
 
   