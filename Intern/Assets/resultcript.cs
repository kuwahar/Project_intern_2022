using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resultcript : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("title");
    }
}
