using System;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject SpawnPlane;
    [SerializeField] float speed;
    [SerializeField] Transform target;
    [SerializeField] string gameOverScreen;
    [SerializeField] float attackRange = 10;
    bool attack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        attack = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(attack = false)
        {
            Vector3 forwardd = Vector3.forward * speed;
            Vector3 targetLocation = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(targetLocation);
            transform.Translate(forwardd * Time.deltaTime);
            transform.LookAt(targetLocation);
            transform.Translate(forwardd * Time.deltaTime);
        }
        if(this.transform.position.y < -5) //this skrivet av mathias
        {
            Respawn();
        }

        float rangeToEnemy = Vector3.Distance(transform.position, target.position);
        if(rangeToEnemy < attackRange)
        {
            Attack();
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
    public void Respawn()
    {
        Instantiate(EnemyPrefab, GetRandomSpawnPos(), transform.rotation);
        Instantiate(EnemyPrefab, GetRandomSpawnPos(), transform.rotation);
        Destroy(this.gameObject);
    }

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
        while(true)
        {
            Animator enemyAnimator = GetComponent<Animator>();
            enemyAnimator.SetBool("isAttacking", true);
            attack = true;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            float rangeToEnemy = Vector3.Distance(transform.position, target.position);
            if(rangeToEnemy < attackRange * 3)
            {
                
            }
        }
    }
}
