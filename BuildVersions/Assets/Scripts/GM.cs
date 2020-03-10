using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
   //Variables 
    public int lives = 3;
    public int bricks = 20;
    public int count=0;
    public float resetDelay = 1f;
    public bool bigPaddle=false;
    //References to other game objects/texts/audioclips
    public AudioClip beat;
    public AudioClip tick;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject power;
    public GameObject paddle;
    public GameObject deathParticles;

    public static GM instance = null;

    
    private GameObject clonePaddle;//This will be used as to not destroy the actual paddle
    


    void Awake()//runs when the game turns on
    {
        
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();//runs setup method

    }

    void FixedUpdate()//runs every frame
    {
        // Quit if player presses escape
        if (Input.GetKey("escape"))
            Application.Quit();

        


    }

    public void Setup()
    {
        Time.timeScale = 1f;//This is normal time
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;//this makes a clone paddle based on the original
        gameOver.SetActive(false);//text objects off
        youWon.SetActive(false);
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);//makes the bricks appear
    }

    void loadNext()
    {
        // Creates a reference to the current scene and gets its name
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName != "Level3")//level3 is the last scene
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//loads the next scene

        }
        else
        {
            youWon.SetActive(true);//text object on
            Invoke("Reset", 4);//this runs the reset method after 4 seconds
        }
    }

    void CheckGameOver()
    {
        
        if (bricks < 1)//if no more bricks are there, the player won the level
        {
            youWon.SetActive(true);
            Invoke("loadNext", resetDelay);//call loadNext


        }

        if (lives < 1)//if the player lost all their lives, the game is over
        {
            gameOver.SetActive(true);//textobject on
            Time.timeScale = .25f;//Everything will be in slow motion for effect
            Invoke("Reset", resetDelay);
        }

    }

    void Reset()
    {
        Time.timeScale = 1f;//This resets the time scale to normal, in case it was changed by gameover
        SceneManager.LoadScene("Level1");//this loads the first level, no matter what
        

    }

    public void LoseLife()
    {
        bigPaddle = false;
        lives--;//takes away a life
        livesText.text = "Lives: " + lives;//changes the players text to show how many lives they have
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);//spawn particles in place of the paddle
       
        Destroy(clonePaddle);//get rid of the paddle
        Time.timeScale = 1f;//reset time scale in case it was changed by a powerup
        Invoke("SetupPaddle", resetDelay);//respawns a paddle
        CheckGameOver();//checks to see where the player is
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;//spawns a new paddle
        
    }

    void smaller()
    {
        if (bigPaddle == true)//as long as the paddle is double its size, it can be made smaller
        {
            powerdown();//lets the player know they're running out of time with their powerup
            GameObject.FindWithTag("paddle").transform.localScale += new Vector3(-2F, 0, 0);//finds the paddle and makes it its normal size again
        }
    }

    void faster()
    {
        powerdown();
        Time.timeScale = 1f;//resets the time scale for the powerup
        

    }
    void powerdown()
    {
        AudioSource.PlayClipAtPoint(tick, Camera.main.transform.position);//plays an audioclip
    }
    public void DestroyBrick()
    {
        AudioSource.PlayClipAtPoint(beat, Camera.main.transform.position);//plays an audioclip

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        bricks--;//decrements the number of bricks there are when one is destroyed by the player

        if (sceneName == "Level1")//each level has a ifferent powerup
        {
            if (bricks == 18)//After a certain number of bricks have been destroyed by the player
            {
                Instantiate(power, new Vector3(Random.Range(-4.0f, 2.0f), 8F, 0), Quaternion.identity);//spawns a powerup at a random x value
                bigPaddle = true;
                Invoke("smaller", 10F);//the player has the powerup for 10 seconds
            }
            else if (bricks == 10)
            {
                Instantiate(power, new Vector3(Random.Range(-4.0f, 2.0f), 8F, 0), Quaternion.identity);
                Invoke("smaller", 10F);
            }
        }
        else if (sceneName == "Level2")
        {
            if (bricks == 18)
            {
                Instantiate(power, new Vector3(Random.Range(-4.0f, 2.0f), 8F, 0), Quaternion.identity);
                Invoke("faster", 5F);//the player has the powerup for 5 seconds

            }
            else if (bricks == 10)
            {
                Instantiate(power, new Vector3(Random.Range(-4.0f, 2.0f), 8F, 0), Quaternion.identity);
                Invoke("faster", 5F);
            }
        }
        else
        {
            if (bricks == 18)
            {
                Instantiate(power, new Vector3(Random.Range(-4.0f, 2.0f), 8F, 0), Quaternion.identity);
                

            }
            else if (bricks == 10)
            {
                Instantiate(power, new Vector3(Random.Range(-4.0f, 2.0f), 8F, 0), Quaternion.identity);
                
            }

        }

        CheckGameOver();
    }
}