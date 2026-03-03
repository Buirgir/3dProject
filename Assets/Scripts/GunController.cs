using System.Security;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float timeBetweenShots;
    float timeSinceLastShot;

    Transform spawnPoint;
    // void Start()
    // {
    //     spawnPoint = transform.GetChild(0).transform;
    // }
    // public void Fire()
    // {
    //     if(timeSinceLastShot >= timeBetweenShots)
    //     {
            
                
    //         Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
    //         timeSinceLastShot = 0;
    //     }
    // }
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }
}
