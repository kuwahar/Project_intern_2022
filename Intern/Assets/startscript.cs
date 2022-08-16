using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startscript : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("main");
    }
}
