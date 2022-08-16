using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCameraController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Transform transform = this.transform;

        Vector3 Angle = transform.localEulerAngles;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Angle.y += 45.0f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Angle.y -= 45.0f;
        }

        transform.localEulerAngles = Angle;
    }
}
