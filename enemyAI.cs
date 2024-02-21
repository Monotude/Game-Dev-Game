using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement; 

public class enemyAI : MonoBehaviour
{
    //***variables***
    public NavMeshAgent ai;
    //list variable which will contain a list of our destinations's transforms
    public List<Transform> destinations;
    //Animator variable
    public Animator aiAnim;
    //floats for walk speed, chase speed, idle time, rayCast distance
    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime, sightDistance, catchDistance;
    //chase variables
    public float chaseTime, minChaseTime, maxChaseTime, jumpScareTime;
    //bools to determineif the ai is wlking to random destiantion or chasing the player
    public bool isWalking, isChasing ;
    //Tranform variable for the player
    public Transform player ;
    //non public transform variable for the AI's current destination 
    Transform currentDest;
    //Vector 3 variable for AI's destination 
    Vector3 dest;
    //int variable to randomize AI's destinations. Randnum2 will be used to randomize something when the ai reaches its destination 
    int randNum, randNum2;
    public int destinationAmount;
    // just in case
    public float idleTime;

    //for the ray cast's offset, position it better 
    public Vector3 rayCastOffset;

    //string var for death scene. determins scene player loads after death
    public string deathScene;


   
    



    void Start() {
        isWalking = true;
        //randNum will = to a random number from a random range of numbers between 0-destAmt
        randNum = Random.Range(0, destinationAmount);
        //currentDest will = to a destination from the destinations list based on what the randNum = to
        currentDest = destinations[randNum];

    }

    void Update( ) {







        //direction of the raycast, pointing to the player at all times
        Vector3 direction = (player.position - transform.position).normalized; 
        RaycastHit hit;
        //if raycast hits
        // if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance)) {
        //     if(hit.collider.gameObject.tag == "Player") {
        //         isWalking = false;
        //         StopCoroutine("stayIdle");
        //         StopCoroutine("chaseRoutine");
        //         StartCoroutine("stayIdle");
        //         // 
        //         // aiAnim.ResetTrigger("walk");
        //         // aiAnim.ResetTrigger("idle");
        //         // aiAnim.SetTrigger("sprint");
        //         isChasing = true;
        //     }
        // } 

        if(isChasing == true) {

            dest = player.position; 
            ai.destination = dest;
            ai.speed = chaseSpeed; 
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("idle");
            aiAnim.SetTrigger("sprint");
            //if ais remaining distance is <= to the catch, rand2 will = to a random # between 0-1
            if (ai.remainingDistance <= catchDistance ) {
               //set player obj false
               player.gameObject.SetActive(false);
               aiAnim.ResetTrigger("sprint");
                aiAnim.SetTrigger("jumpscare");
                StartCoroutine(deathRoutine());
                isChasing = false;
            }
        }

        //the ai's dest will = to the dest, the ai will move towards the dest
        if (isWalking == true) {
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = walkSpeed;
            aiAnim.ResetTrigger("sprint");
            aiAnim.ResetTrigger("idle");
            aiAnim.SetTrigger("walk");
            //if ais remaining distance is <= to the stoppingdistance, rand2 will = to a random # between 0-1
            if (ai.remainingDistance <= ai.stoppingDistance ) {
                // //last number is never pick so its  0 -2 
                // randNum2 = Random.Range(0, 2);
                // //if randNum 2 = 0, ai wil pick a new random dest to keep moving
                // if (randNum2 == 0) {
                //     randNum = Random.Range(0, destinationAmount);
                //     currentDest = destinations[randNum];
                // }
                // // if 1, au will idle and coroutine will start
                // if (randNum2 == 1) {
                //     aiAnim.ResetTrigger("walk");
                //     aiAnim.SetTrigger("idle");
                //     StopCoroutine("stayIdle");
                //     StartCoroutine("stayIdle");
                //     isWalking = false;
                // }

                //instead of picking a random action for ai to do, the ai will just go idle then start walking to another dest again
                aiAnim.ResetTrigger("sprint");
                aiAnim.ResetTrigger("walk");
                aiAnim.SetTrigger("idle");
                ai.speed= 0 ;
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                isWalking = false;
            }
        }
    }

  
    IEnumerator stayIdle () {
        //idleTime num3 will be the amt of time ai is idle for
        //idleTime for rand # between min-max idle
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        
        //after the amt of sconds in idleTime, ai dest will be randomized and walking will be true
        isWalking = true;
        randNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randNum];
        // aiAnim.ResetTrigger("sprint");
        // aiAnim.ResetTrigger("idle");
        // aiAnim.SetTrigger("walk");
    }

    IEnumerator chaseRoutine() {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        isWalking = true;
        isChasing = false; 
        randNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randNum];
        // aiAnim.ResetTrigger("idle");
        // aiAnim.ResetTrigger("sprint");
        // aiAnim.SetTrigger("walk");

    }

    IEnumerator deathRoutine() {
        //after set amt of sec in jumpscaretime, death scene will load
        yield return new WaitForSeconds(jumpScareTime);
        SceneManager.LoadScene(deathScene);
    }
}
