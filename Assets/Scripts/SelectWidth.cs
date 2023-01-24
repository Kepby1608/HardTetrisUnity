using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWidth : MonoBehaviour
{
    public GameObject[] widths = new GameObject[11];
    // Start is called before the first frame update
    void Start()
    {
        widths[Start_Scene.size-10].SetActive(true);
    }

    private void OnEnable()
    {
        Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
