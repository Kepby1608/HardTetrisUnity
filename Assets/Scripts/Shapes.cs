using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour
{
    public GameObject[] shape = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        shape[SelectShapes.number].transform.parent.transform.position = new Vector2((int)Start_Scene.size / 2, 25);
        shape[SelectShapes.number].SetActive(true);
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
