using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAliens : MonoBehaviour
{

    public float timeLeft = 8.0f;
    public GameObject alien;

    public GameObject player;
    public Health_And_Damage playerHealthScript;

    void Start() {
        playerHealthScript = player.GetComponent<Health_And_Damage>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealthScript.playerDead == false){
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0){
                GameObject spawnedAlien = Instantiate(alien, transform.position, Quaternion.identity);
                Debug.Log("Aliens Spawned");
                timeLeft = 8.0f;
            }      
        }
        else{
            Debug.Log("Player Dead, stop spawning");
        }
    }
}
