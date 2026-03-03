using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform target;
    [SerializeField] string gameOverScreen;
    bool isColiding = false;
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
        if(isColiding == false)
            transform.Translate(forwardd * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {   
        if(collision.gameObject.tag == "Player")
        {
            isColiding = true;
        }
        else
        {
            isColiding = false;
        }
        //temp dissabled
        /*if(collision.gameObject.tag == "Player")
        {
        SceneManager.UnloadSceneAsync("FirstPerson");
        SceneManager.LoadScene(gameOverScreen);            
        }*/
    }

}
