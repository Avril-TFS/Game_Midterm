using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float boundx = 10.6f;
    private float lBoundx = -0.8f;
    private float boundy = -0.05f;
    private float uBoundy = 13.0f;

    void Start()
    {
        //cam.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        if (pos.x > boundx)
        {
            pos.x = boundx;
        }
        else if ( pos.x < lBoundx)
        {
            pos.x = lBoundx;
        }
        transform.position = pos;

        var posy = transform.position;
        if (posy.y > uBoundy)
        {
            posy.y = uBoundy;
        }
        else if (posy.y < boundy)
        {
            posy.y = boundy;
        }
        transform.position = posy;
    }
}
