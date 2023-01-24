using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject[] spawn = new GameObject[4];
    public GameObject[] width = new GameObject[11];
    public GameObject overUI;
    public bool over = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (over)
            Over_Start();
    }

    void Over_Start()
    {
        spawn[SelectShapes.number].SetActive(false);
        width[Start_Scene.size-10].SetActive(false);
        overUI.SetActive(true);

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        over = false;
    }
}
