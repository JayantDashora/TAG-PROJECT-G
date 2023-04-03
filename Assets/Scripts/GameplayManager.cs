using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayManager : MonoBehaviour
{

    // Variables 
    public int leftBlueTargets = 4;
    public int leftlRedTargets = 4;

    [SerializeField] private TextMeshProUGUI winText;

    void Start()
    {
        
    }


    void Update()
    {
        // Game winning condition 

        if((leftBlueTargets <= 0) && (leftlRedTargets <= 0)){
            // Winning
            winText.gameObject.SetActive(true);
            
        }



    }
}
