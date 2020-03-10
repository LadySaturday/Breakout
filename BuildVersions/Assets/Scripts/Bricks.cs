using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour
{

    public GameObject brickParticle;
    
  

    void OnCollisionEnter(Collision other)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);//creates little particles after the brick is destroyed
        
        GM.instance.DestroyBrick();//calls destroy brick from the game manager script
        
        
        Destroy(gameObject);
    }
}