using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(800, 600, false);
        Invoke("Loaded", 2);
    }
     void Loaded()
    {
        SceneManager.LoadSceneAsync(1);
    }


}
