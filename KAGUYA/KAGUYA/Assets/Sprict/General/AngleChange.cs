using System;
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

    public bool reverse = false;

    public float reverseXSpeed = 0;
    public float reverseYSpeed = 0;
    public float reverseZSpeed = 0;
    public float reverseXCount = 0;
    public float reverseYCount = 0;
    public float reverseZCount = 0;

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

        if (!reverse) return;

        reverseXSpeed += Math.Abs(XSpeed);

        if (reverseXSpeed < reverseXCount) return;
        XSpeed *= -1;

        reverseXSpeed = 0;

    }
    public void YRotation() 
    {
        if (!Y) return;
        Vector3 vector = transform.eulerAngles;
        vector.y += YSpeed;
        transform.eulerAngles = vector;
        if (!reverse) return;

        reverseYSpeed += Math.Abs(YSpeed);

        if (reverseYSpeed < reverseYCount) return;
        YSpeed *= -1;

        reverseYSpeed = 0;

    }
    public void ZRotation() 
    {
        if (!Z) return;
        Vector3 vector = transform.eulerAngles;
        vector.z += ZSpeed;
        transform.eulerAngles = vector;
        if (!reverse) return;

        reverseZSpeed += Math.Abs(ZSpeed);

        if (reverseZSpeed < reverseZCount) return;
        ZSpeed *= -1;

        reverseZSpeed = 0;

    }

}
