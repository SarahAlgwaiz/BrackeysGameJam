using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    //key will only appear after every enemy is defeated
    //once key is taken it will be added to the player's key count
    // Start is called before the first frame update
    [SerializeField] Player player;
    [SerializeField] int numEnemies = 5;
    [SerializeField] GameObject enemy;
    Vector3[] positions;
    bool enemyActivated = false;
    void StartEnemy()
    {
                enemyActivated = true;
    this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    this.gameObject.transform.SetPositionAndRotation(
        new Vector3(this.gameObject.transform.position.x,300,this.gameObject.transform.position.z),this.gameObject.transform.rotation);
        for (int i = 0; i < numEnemies; i++)
{
    Instantiate(enemy, GetRandomTargetPos(),Quaternion.identity);
}
    }

    Vector3 GetRandomTargetPos()
{
    Vector2 rndPos = Random.insideUnitCircle * (5 - 1);
    rndPos += rndPos.normalized * 1;
    return new Vector3(player.transform.position.x + rndPos.x, player.transform.position.y, player.transform.position.z + rndPos.y);
}

    // Update is called once per frame
    void Update()
    {
    int num = GameObject.FindGameObjectsWithTag("Enemy").Length; 
    if(num == 0 ){
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.gameObject.transform.SetPositionAndRotation(
        new Vector3(this.gameObject.transform.position.x,0,this.gameObject.transform.position.z),this.gameObject.transform.rotation);
    }
    }
     private void OnTriggerEnter(Collider other) {
                     if(other.gameObject.tag != "Ground"){

            Debug.Log("this");

            
                int num = GameObject.FindGameObjectsWithTag("Enemy").Length; 
            if(enemyActivated){
                //move to other room
                player.numKeys++;
            }
            else{
                StartEnemy();
            }
            }
     }
}
