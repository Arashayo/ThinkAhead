using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class licznik : MonoBehaviour
{
    int sceneID;
    public GameObject napis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        sceneID = SceneManager.GetActiveScene().buildIndex;
        napis.GetComponent<Text>().text = sceneID.ToString("F0");
    }
}
