using System.Linq;
using UnityEngine;

public class Cube_Controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] cyllinders = GameObject.FindGameObjectsWithTag("cyl");
        for (int i = 0; i < cyllinders.Length; i++)
        {
            Destroy(cyllinders[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
