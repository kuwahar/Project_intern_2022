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
<<<<<<< HEAD
=======
>>>>>>> develop
    AnimationScript test;
>>>>>>> feature_kuwahara/add_star
    public bool isStarGot = false;
    void Start()
    {
<<<<<<< HEAD

=======
<<<<<<< HEAD
=======
>>>>>>> develop
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

=======
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
>>>>>>> develop
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
        await Task.Delay(ctime(1));
        SceneChange();
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

<<<<<<< HEAD
    }}
=======
    }
>>>>>>> feature_kuwahara/add_star
}
>>>>>>> develop
