using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    float MaxRange = 60;

    [SerializeField]
    float MinRange = 40;

    [SerializeField]
    float Range;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if ( MinRange < cam.fieldOfView && Input.GetKey(KeyCode.UpArrow))
        {
            cam.fieldOfView -= Range;
        }
        if ( MaxRange > cam.fieldOfView && Input.GetKey(KeyCode.DownArrow))
        {
            cam.fieldOfView += Range;
        }

    }
}
