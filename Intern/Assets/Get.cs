using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;


public class Get : MonoBehaviour
{
    AnimationScript test;
    public bool isStarGot = false;
    // Start is called before the first frame update
    void Start()
    {
        test = GetComponent<AnimationScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isStarGot)
        {
            GetStar();
            
            //Invoke("SceneChange", 1.00f);
        }
    }

    private async void GetStar()
    {
        test.floatSpeed = 0.01f;
        await Task.Delay(ctime(1));�@//�Q�b�x��
        GetComponent<BoxCollider>().isTrigger = true;
        test.isFloating = false;
        test.isScaling = true;

    }

    void SceneChange()
    {
        //transform.position = 
        SceneManager.LoadScene("result");
    }
    private int ctime(float time) //�b�ɕϊ�
    {
        time *= 1000;
        return (int)time;

    }
}
