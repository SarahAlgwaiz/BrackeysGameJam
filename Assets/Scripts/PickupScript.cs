using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PickupScript : MonoBehaviour
{

    [SerializeField] float healthAmount = 1;
    [SerializeField] float duration = 10;
    [SerializeField] float stackLimit = 5;
    bool timerStarted = false;
     Player player;
    EnemyGenericAI enemy;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

 private void OnTriggerEnter(Collider other) {
     if(other.gameObject.tag != "Ground"){
    int random = 5; // Random.Range(1,5);
    Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Player"){
            Debug.Log("this");
            affectPlayer(random);
        }
 }
 }
    // Update is called once per frame
    void affectPlayer(int random){
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.transform.position.Set(this.gameObject.transform.position.x,300,this.gameObject.transform.position.z);
        switch(random){
            case 1:
              raiseHealthPlayer();
              Debug.Log("RaiseHealth");
            break;
            case 2:
            lowerHealthPlayer();
            Debug.Log("LowerHealth");
            break;
             case 3:
            StartCoroutine(raiseAttackPowerPlayer());
             Debug.Log("RaiseAttack");
            break;
             case 4:
            StartCoroutine(lowerAttackPowerPlayer());
               Debug.Log("LowerAttack");
            break;
             case 5:
             StartCoroutine(invertPlayer());
             Debug.Log("ControlsInverted");
            break;
            
        }    }
        void affectEnemy(int random){
        switch(random){
            case 1:
              raiseHealthEnemy();
            break;
            case 2:
            lowerHealthEnemy();
            break;
            case 3:
            StartCoroutine(raiseAttackPowerEnemy());
            break;
             case 4:
               StartCoroutine(lowerAttackPowerEnemy());
            break;
             case 5:
                StartCoroutine(invertEnemy());
            break;
            
        }
    }
    void raiseHealthPlayer()
    {
        if(player.health != 0){
        player.health += healthAmount;
        if(player.health > player.MAXHEALTH){
            player.health = player.MAXHEALTH;
        }
        }
         this.gameObject.SetActive(false);
    }
    void raiseHealthEnemy()
    {
        if(enemy.health != 0){
        enemy.health += healthAmount;
        if(enemy.health > enemy.MAXHEALTH){
            enemy.health = enemy.MAXHEALTH;
        }
        }
        this.gameObject.SetActive(false);
    }
       void lowerHealthPlayer()
    {
        if(player.health != 0){
        player.health -= healthAmount;
        if(player.health < 0){
            player.health = 0;
        }
        }
        this.gameObject.SetActive(false);
        }

      void lowerHealthEnemy()
    {
        if(enemy.health != 0){
        enemy.health -= healthAmount;
        if(enemy.health < 0){
            enemy.health = 0;
        }
        }
          this.gameObject.SetActive(false);
        }
        
        IEnumerator raiseAttackPowerPlayer(){
            if(player.attackPowerOffset < stackLimit){
            player.attackPowerOffset++;
            yield return new WaitForSeconds(duration);
            player.attackPowerOffset--;
            this.gameObject.SetActive(false);
            }
          else  this.gameObject.SetActive(false);
        }
        IEnumerator raiseAttackPowerEnemy(){
         if(enemy.attackPowerOffset < stackLimit){
            enemy.attackPowerOffset++;
            yield return new WaitForSeconds(duration);
            enemy.attackPowerOffset--;
            this.gameObject.SetActive(false);
           
             }
           else this.gameObject.SetActive(false);
        }
        IEnumerator lowerAttackPowerPlayer(){
         if(player.attackPowerOffset < (-stackLimit)){
            player.attackPowerOffset--;
             yield return new WaitForSeconds(duration);
            player.attackPowerOffset++;
        this.gameObject.SetActive(false);  
             }
         else   this.gameObject.SetActive(false);
        }
        IEnumerator lowerAttackPowerEnemy(){
          if(enemy.attackPowerOffset < -stackLimit){
            enemy.attackPowerOffset--;
            yield return new WaitForSeconds(duration);
            enemy.attackPowerOffset++;
       this.gameObject.SetActive(false);
           
             }
          else  this.gameObject.SetActive(false);
        }
        IEnumerator invertPlayer(){
          if(player.movementMultiplyer == 1){
              player.movementMultiplyer = -1;
            yield return new WaitForSecondsRealtime(30f);
            Debug.Log("movementMultiplyer");
            player.movementMultiplyer = 1;
      this.gameObject.SetActive(false);
             }
            else this.gameObject.SetActive(false);
        } 
              IEnumerator invertEnemy(){
          if(enemy.movementMultiplyer == 1){
              enemy.movementMultiplyer = -1;
            yield return new WaitForSeconds(duration);
            enemy.movementMultiplyer = 1;
        this.gameObject.SetActive(false);
           
             }
           else  this.gameObject.SetActive(false);
}
 }
