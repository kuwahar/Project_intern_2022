using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
=======
using System.Threading.Tasks;
>>>>>>> feature_kuwahara/add_star


public class Get : MonoBehaviour
{
<<<<<<< HEAD
=======
    AnimationScript test;
>>>>>>> feature_kuwahara/add_star
    public bool isStarGot = false;
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
=======
        test = GetComponent<AnimationScript>();
>>>>>>> feature_kuwahara/add_star

    }

    // Update is called once per frame
    void Update()
    {
        if (isStarGot)
        {
<<<<<<< HEAD
            var test = GetComponent<AnimationScript>();
            test.floatSpeed = 10;

            Invoke("SceneChange", 0.5f);
        }
    }
    void SceneChange()
    {
        SceneManager.LoadScene("result");
    }
=======
            GetStar();
            
            //Invoke("SceneChange", 1.00f);
        }
    }

    private async void GetStar()
    {
        test.floatSpeed = 0.01f;
        await Task.Delay(ctime(1));Å@//ÇQïbíxâÑ
        GetComponent<BoxCollider>().isTrigger = true;
        test.isFloating = false;
        test.isScaling = true;

    }

    void SceneChange()
    {
        //transform.position = 
        SceneManager.LoadScene("result");
    }
    private int ctime(float time) //ïbÇ…ïœä∑
    {
        time *= 1000;
        return (int)time;

    }
>>>>>>> feature_kuwahara/add_star
}
