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
    }
    public void YMove()
    {
        if (!Y) return;
        Vector3 vector = transform.position;
        vector.y += YSpeed;
        transform.position = vector;
    }
    public void ZMove()
    {
        if (!Z) return;
        Vector3 vector = transform.position;
        vector.z += ZSpeed;
        transform.position = vector;
    }
}
