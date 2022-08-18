using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Get : MonoBehaviour
{
    public bool isStarGot = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isStarGot)
        {
            var test = GetComponent<AnimationScript>();
            test.floatSpeed = 10;

            Invoke("SceneChange", 0.5f);
        }
    }
    void SceneChange()
    {
        SceneManager.LoadScene("result");
    }
}
