using UnityEditor.Callbacks;
using UnityEngine;

public class PillMover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mv = Vector3.forward;
        transform.Translate(mv * Time.deltaTime);
    }
}
