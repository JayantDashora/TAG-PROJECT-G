using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedTargetScript : MonoBehaviour
{

    // Variables

    [SerializeField] private GameObject dummySphere;
    [SerializeField] private GameObject gameplayManager;
    private GameplayManager gameplayManagerScript;

    void Start()
    {
        gameplayManagerScript = gameplayManager.GetComponent<GameplayManager>();
    }


    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("DestroyingBullet")){
            gameplayManagerScript.leftlRedTargets--;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("ChangingBullet")){
            Instantiate(dummySphere,transform.position,transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene(0);

        }
    }   
}
