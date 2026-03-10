using System.Security;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]GameObject player;
    public float timeSinceLastShot;
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }
    public void OnAnimationEnd()
    {
        player.GetComponent<Look>().OnAnimationEnd();
    }
}
