using System.Security;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    public float timeSinceLastShot;

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    //Detects shot animation end
    public void OnAnimationEnd()
    {
        player.GetComponent<Look>().OnAnimationEnd();
    }
}
