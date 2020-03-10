using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public Button StartBtn;//get references to the buttons
    public Button QuitBtn;
    public Button OneBtn;
    public Button TwoBtn;
    public Button ThreeBtn;

    void Start()
    {
        Button sbtn = StartBtn.GetComponent<Button>();
        Button qbtn = QuitBtn.GetComponent<Button>();
        Button obtn = OneBtn.GetComponent<Button>();
        Button tbtn = TwoBtn.GetComponent<Button>();
        Button thbtn = ThreeBtn.GetComponent<Button>();
        sbtn.onClick.AddListener(load);//when its clikced, call method
        qbtn.onClick.AddListener(quit);
        obtn.onClick.AddListener(load);
        tbtn.onClick.AddListener(two);
        thbtn.onClick.AddListener(three);
    }
    
    void load()
    {
        SceneManager.LoadScene("Level1");//load specified level
    }
    void two()
    {
        SceneManager.LoadScene("Level2"); 
    }
    void three()
    {
        SceneManager.LoadScene("Level3");
    }

    void quit()
    {
    
            Application.Quit();//exit
    }
}