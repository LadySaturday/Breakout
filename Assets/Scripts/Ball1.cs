using UnityEngine;
using System.Collections;

public class Ball1 : MonoBehaviour//This controls the powerup ball
{

    public float ballInitialVelocity = 600f;//burst of force to start


    private Rigidbody rb;
    public bool ballInPlay;//is ball in play??

    void Awake()//called before start
    {

        rb = GetComponent<Rigidbody>();//get reference to rigidbody

    }

    void Update()
    {
        if (ballInPlay == false)//if it doesn't exist, make it happen
        {
           
            ballInPlay = true;//ball is now in play
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));//this vector is a direction in space
        }
    }
}