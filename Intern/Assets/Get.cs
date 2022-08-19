using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;



public class Get : MonoBehaviour
{
    AnimationScript test = null;
    public bool isStarGot = false;
    void Start()
    {
        test = GetComponent<AnimationScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarGot)
        {
            isStarGot = false;
            test = GetComponent<AnimationScript>();
            GetStar();
        }
    }

    private async void GetStar()
    {
        test.isFloating = true;
        test.floatSpeed = 0.01f;
        await Task.Delay(ctime(1));Å@//ÇQïbíxâÑ
        GetComponent<BoxCollider>().isTrigger = true;
        test.isFloating = false;
        test.isScaling = true;
        await Task.Delay(ctime(1));
        SceneChange();
    }

    void SceneChange()
    {
        SceneManager.LoadScene("result");
    }
    private int ctime(float time) //ïbÇ…ïœä∑
    {
        time *= 1000;
        return (int)time;
    }
}