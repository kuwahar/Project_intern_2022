using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainscript : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Main");
    }
}
