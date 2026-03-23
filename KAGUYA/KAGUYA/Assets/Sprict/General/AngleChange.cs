using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleChange : MonoBehaviour
{
    public bool X = false;
    public bool Y = false;
    public bool Z = false;

    public float XSpeed = 1;
    public float YSpeed = 1;
    public float ZSpeed = 1;

    public void Update()
    {
        XRotation();
        YRotation();
        ZRotation();
    }

    public void XRotation() 
    {
        if (!X) return;
        Vector3 vector = transform.eulerAngles;
        vector.x += XSpeed;
        transform.eulerAngles = vector;
    }
    public void YRotation() 
    {
        if (!Y) return;
        Vector3 vector = transform.eulerAngles;
        vector.y += YSpeed;
        transform.eulerAngles = vector;
    }
    public void ZRotation() 
    {
        if (!Z) return;
        Vector3 vector = transform.eulerAngles;
        vector.z += ZSpeed;
        transform.eulerAngles = vector;
    }

}
