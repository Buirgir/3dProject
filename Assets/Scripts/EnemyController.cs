using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] float speed;
    [SerializeField] Transform target;
    [SerializeField] string gameOverScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardd = Vector3.forward * speed;
        Vector3 targetLocation = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetLocation);
        transform.Translate(forwardd * Time.deltaTime);

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
    public void Delete()
    {
        Vector3 Spawnpoint = SpawnPoint.transform.position;
        Instantiate(EnemyPrefab, Spawnpoint, transform.rotation);
        Destroy(this.gameObject);
    }

}
