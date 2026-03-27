using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public bool X = false;
    public bool Y = false;
    public bool Z = false;

    public float XSpeed = 1;
    public float YSpeed = 1;
    public float ZSpeed = 1;
    public bool reverse = false;    
    public float reverseXSpeed = 1;
    public float reverseYSpeed = 1;
    public float reverseZSpeed = 1;
    public float reverseXCount = 1;
    public float reverseYCount = 1;
    public float reverseZCount = 1;

    public void Update()
    {
        XMove();
        YMove();
        ZMove();
    }

    public void XMove()
    {
        if (!X) return;
        Vector3 vector = transform.position;
        vector.x += XSpeed;
        transform.position = vector;

        if (!reverse) return;

        reverseXSpeed += Math.Abs(XSpeed);

        if (reverseXSpeed < reverseXCount) return;
        XSpeed *= -1;

        reverseXSpeed = 0;

    }
    public void YMove()
    {
        if (!Y) return;
        Vector3 vector = transform.position;
        vector.y += YSpeed;
        transform.position = vector;
        if (!reverse) return;

        reverseYSpeed += Math.Abs(YSpeed);

        if (reverseYSpeed < reverseYCount) return;
        YSpeed *= -1;

        reverseYSpeed = 0;

    }
    public void ZMove()
    {
        if (!Z) return;
        Vector3 vector = transform.position;
        vector.z += ZSpeed;
        transform.position = vector;
        if (!reverse) return;

        reverseZSpeed += Math.Abs(ZSpeed);

        if (reverseZSpeed < reverseZCount) return;
        ZSpeed *= -1;

        reverseZSpeed = 0;

    }
}
