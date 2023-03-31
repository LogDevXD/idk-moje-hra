using TMPro;
using UnityEngine;
using System.Collections;
using  UnityEngine.SceneManagement;

public class LoadSceneOnSpacebar : MonoBehaviour {
    // Jméno scény, kterou chcete načíst
    public string sceneName;

    void Update () {
        // Načte scénu, když uživatel stiskne mezerník
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene("Level1");
        }
    }

    
}

