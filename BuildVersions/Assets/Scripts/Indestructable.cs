using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indestructable : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("MainCamera");//audio is attached to the camera
        if (objects.Length > 1)//if there is more than one instance of the "Main Camera", one of them will be destroyed
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);//This prevents the object from being destroyed when the scenes change, so the audio will be seamless
    }
}
