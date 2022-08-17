using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StageCameraController : MonoBehaviour
{
    [SerializeField]
    float count;

    [SerializeField]
    float rotation;

    [SerializeField]
    int delay;

    // Update is called once per frame
    async void Update()
    {
        Transform transform = this.transform;
        float x = rotation / count;

        Vector3 Angle = transform.localEulerAngles;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //for•¶‚ðŽg—p‚µ‚Äcount‰ñŒJ‚è•Ô‚·
            for ( int i = 0; i < count; i++)
            {
                Angle.y += x;
                transform.localEulerAngles = Angle;
                await Task.Delay(delay);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            for (int i = 0; i < count; i++)
            {
                Angle.y -= x;
                transform.localEulerAngles = Angle;
                await Task.Delay(delay);
            }
        }

    }
}
