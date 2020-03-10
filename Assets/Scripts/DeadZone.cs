using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour
{
    public AudioClip splash;
    void OnTriggerEnter(Collider col)
    {
        AudioSource.PlayClipAtPoint(splash, Camera.main.transform.position);//plays a splash


        if (col.gameObject.tag.Equals("ball"))//if the ball collided with the water
        {
            GM.instance.LoseLife();//call lose life method from game manager script
        }
        else if (col.gameObject.tag.Equals("ball2"))//if the powerup ball is lost, don't lose a life
        {
            Destroy(col.gameObject);
        }
    }
}