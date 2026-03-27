using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCanvasManager : MonoBehaviour
{
    public static SceneCanvasManager instance;
    // シーンごとのキャンバスのオブジェクトリスト
    [SerializeField] List<SceneCanvas> canvass = new List<SceneCanvas>();

    [SerializeField] GameObject SceneCanvasParent;

    // どのシーンのものかを判断する列挙体
    public enum plotSceneEnum
    {
        None,
        Fried,
        PlaySkill,
        Fan,
        Order,
        Strategy,
        Study,
        FunLetter,
        Kassen,
        MAX
    }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < canvass.Count; i++)
        {
            SceneCanvas canvas = GameObject.Instantiate(canvass[i]);

            canvas.gameObject.SetActive(false);

            canvas.transform.transform.parent = SceneCanvasParent.transform;


            canvass[i] = canvas;
        }



    }

    // Update is called once per frame
    void Update()
    {

    }

    public SceneCanvas GetSceneCanvas(int id) { return canvass[id]; }
    public void StartSceneCanvas(int id)
    {
        canvass[id].SceneStart();

    }

    public void SceneEnd()
    {
        for (int i = 0; i < canvass.Count; i++)
        {
            if (!canvass[i].gameObject.activeSelf) continue;

            canvass[i].gameObject.SetActive(false);

            canvass[i].SceneEnd();
        }

    }



}
