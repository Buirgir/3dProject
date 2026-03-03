using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

public class PillCreator : MonoBehaviour
{
    [SerializeField] GameObject pill;
    public Animation anim;
    void Start() {
        anim = GetComponentInParent<Animation>();
    }
    void Update()
    {
        // if (!anim.IsPlaying("GameOver"))
        
        Instantiate(pill, transform.position, quaternion.identity);
    }
}
