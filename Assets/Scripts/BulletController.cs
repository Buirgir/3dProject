using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * bulletSpeed);
    }
}
