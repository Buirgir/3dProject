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
            Renderer r = cyllinders[i].GetComponent<Renderer>();
            if(i < cyllinders.Length/2)
            {
                r.material.color = new Color(i * 0.05f, 0, 0);
            }
            if(i > cyllinders.Length/2)
            {
                r.material.color = new Color(0, 0, i * 0.05f);
            }
            if(i == cyllinders.Length/2)
            {
                r.material.color = new Color(0, 1, 0);
            }
            //Renderer r = cyllinders[i].GetComponent<Renderer>();
            //r.material.color = new Color(i * 0.1f, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
