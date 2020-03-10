using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

    public float paddleSpeed = 1f;//speed of paddle
    public float vel = 1f;//velocity

    private Vector3 playerPos = new Vector3(0, -9.5f, 0);//player position

    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);//add to the current position
        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);//limits value to min and max defined after
        transform.position = playerPos;//sets position based on input

    }
}