using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainscript : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("title");
    }

    /*void Update()
    {
        if (0)
        {
            SceneManager.LoadScene("result");
        }
    }*/
}
