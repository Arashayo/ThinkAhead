using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scenes : MonoBehaviour
{

    public float transT = 1f;
    public Animator transition;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLvl();
        }
    }

    public void RestartLvl()
    {

        StartCoroutine(LoadLvl(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLvl(int levelIndex)
    {

        transition.SetTrigger("restart");


        yield return new WaitForSeconds(transT);

        SceneManager.LoadScene("SampleScene");

    }

}
