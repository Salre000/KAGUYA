using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debag : MonoBehaviour
{
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.N)) PlotManager.instance.StartPlotScene();


    }
}
