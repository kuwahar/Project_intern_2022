using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StageCameraController : MonoBehaviour
{
    [SerializeField]
    float partition;

    [SerializeField]
    float rotation;

    [SerializeField]
    int delay;

    int flag = 1 ;

    // Update is called once per frame
    async void Update()
    {
        Transform transform = this.transform;
        float x = rotation / partition;

        Vector3 Angle = transform.localEulerAngles;
        if (flag == 1)      //���s���ɑҋ@���s��
        {
            flag = 0;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //for�����g�p����count��J��Ԃ�
                for (int i = 0; i < partition; i++)
                {
                    Angle.y += x;
                    transform.localEulerAngles = Angle;
                    await Task.Delay(delay);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                for (int i = 0; i < partition; i++)
                {
                    Angle.y -= x;
                    transform.localEulerAngles = Angle;
                    await Task.Delay(delay);
                }
            }
            flag = 1;
        }

    }
}
