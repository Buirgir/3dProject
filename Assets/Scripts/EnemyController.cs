using System;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject EnemyPrefab;

    [SerializeField]
    GameObject SpawnPlane;

    [SerializeField]
    float speed;

    [SerializeField]
    Transform target;

    [SerializeField]
    string gameOverScreen;

    [SerializeField]
    float attackRange = 3;
    bool isAttacking;
    Vector3 attackKnockBack;

    [SerializeField]
    float attackKnockbackadjust;

    [SerializeField]
    GameObject Move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        isAttacking = false; //Sets base state of attacking to false
    }

    // Update is called once per frame
    void Update()
    {
        // moves enemy towards player
        if (isAttacking == false)
        {
            Vector3 forwardd = Vector3.forward * speed;
            transform.Translate(forwardd * Time.deltaTime);
        }
        Vector3 targetLocation = new Vector3(
            target.position.x,
            transform.position.y,
            target.position.z
        );
        //Looks towards player so it moves in the right dirrection
        transform.LookAt(targetLocation);
        //Respawns enemy when player falls too far
        if (this.transform.position.y < -5) //this skrivet av mathias
        {
            Respawn();
        }
        //Detects if player is close to enemy, and if it is then enemy attacks
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            Animator enemyAnimator = GetComponent<Animator>();
            enemyAnimator.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //temp dissabled
        /*if(collision.gameObject.tag == "Player")
        {
        SceneManager.UnloadSceneAsync("FirstPerson");
        SceneManager.LoadScene(gameOverScreen);
        }*/
    }

    //Respawns 2 enemies at random locations arround the map
    public void Respawn()
    {
        Instantiate(EnemyPrefab, GetRandomSpawnPos(), transform.rotation);
        Instantiate(EnemyPrefab, GetRandomSpawnPos(), transform.rotation);
        Destroy(this.gameObject);
    }

    //Gets a random location on a selected plane
    Vector3 GetRandomSpawnPos()
    {
        Renderer spawnPlaneRenderer = SpawnPlane.GetComponent<Renderer>();
        Bounds spawnBounds = spawnPlaneRenderer.bounds;
        float randomX = UnityEngine.Random.Range(spawnBounds.min.x, spawnBounds.max.x);
        float randomZ = UnityEngine.Random.Range(spawnBounds.min.z, spawnBounds.max.z);
        float y = spawnBounds.max.y;
        return new Vector3(randomX, y, randomZ);
    }

    void Attack()
    {
        //Move move = Move.transform.GetComponent<Move>();
        //move.TakeKnockBack(attackKnockBack);
        Animator enemyAnimator = GetComponent<Animator>();
        Debug.Log("attacking");
        while (true)
        {
            enemyAnimator.SetBool("isAttacking", true);
        }
    }

    //Interrupts attack
    void StopAttack()
    {
        Animator enemyAnimator = GetComponent<Animator>();
        enemyAnimator.SetBool("isAttacking", false);
        isAttacking = false;
    }

    //gets the direction the enemy should fly in when getting hit
    public Vector3 KnockbackDirection()
    {
        attackKnockBack = transform.forward * attackKnockbackadjust;
        return attackKnockBack;
    }
}
