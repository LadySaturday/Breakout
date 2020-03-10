using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Power : MonoBehaviour {
    public GameObject ball2;
    public AudioClip powerup;


    void OnTriggerEnter(Collider col)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        

        if (col.gameObject.tag.Equals("paddle"))//if the player collects the powerup...
        {
            AudioSource.PlayClipAtPoint(powerup, Camera.main.transform.position);//play an audioclip

            //each level has a different powerup
            if (sceneName == "Level1")
            {
                GameObject.FindWithTag("paddle").transform.localScale += new Vector3(2F, 0, 0);//makes the paddle bigger

                Destroy(gameObject);//destroys the powerup
                
            }
            else if (sceneName == "Level2")
            {
                
                Time.timeScale = 0.5f;//Puts everything into slowmotion
                Destroy(gameObject);
            }
            else
            {
                Instantiate(ball2, transform.position, Quaternion.identity);//creates a second ball. The ball will not cost a player any lives if lost.
                Destroy(gameObject);

            }
            

        }
    }


	void FixedUpdate () {
        transform.Translate(Vector3.down * 8F * Time.deltaTime, Space.World);//this makes sure the powerup falls
    }
}
