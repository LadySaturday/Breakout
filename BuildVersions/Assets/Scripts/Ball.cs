using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour//controls the main ball
{
    
    public float ballInitialVelocity = 600f;//burst of force
    public AudioClip start;

    private Rigidbody rb;
    public bool ballInPlay;//is ball in play?

    void Awake()//called before start
    {

        rb = GetComponent<Rigidbody>();//get reference to rigidbody

    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && ballInPlay == false)//space bar, while ball hasn't been launched
        {
            AudioSource.PlayClipAtPoint(start, Camera.main.transform.position);
            transform.parent = null;//unparent from paddle
            ballInPlay = true;//ball is now in play
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity/2, ballInitialVelocity, 0));//direction in space
        }
    }
}