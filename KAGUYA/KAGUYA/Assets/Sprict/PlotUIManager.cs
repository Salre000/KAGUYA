using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotUIManager : MonoBehaviour
{
    public static PlotUIManager instance;


    [SerializeField] List<GameObject> plotSceneObjects = new List<GameObject>();

    [SerializeField] GameObject parentObject;

    private void Awake()
    {
        instance = this;

        for (int i = 0; i < plotSceneObjects.Count; i++)
        {

            GameObject gameObject = Instantiate(plotSceneObjects[i]);

            gameObject.transform.parent = parentObject.transform;

            gameObject.SetActive(false);

            Button button = gameObject.GetComponent<Button>();

            int cash = i;
            button.onClick.AddListener(() => 
            {
                PlotManager.instance.SetPlotScene(cash);


                Close();

            });

            plotSceneObjects[i]=gameObject;
        }
    }

    public void Open(List<int> plotData)
    {

        for (int i = 0; i < plotData.Count; i++)
        {
            plotSceneObjects[plotData[i]].SetActive(true);
        }


    }

    public void Close()
    {
        for (int i = 0; i < plotSceneObjects.Count; i++)
        {
            plotSceneObjects[i].SetActive(false);
        }

    }


}
