using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;



public class Get : MonoBehaviour
{

    AnimationScript test;
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
            var test = GetComponent<AnimationScript>();

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
        await Task.Delay(ctime(1));
        SceneChange();
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

    }}
