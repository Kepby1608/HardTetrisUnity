using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Start_Scene : MonoBehaviour
{
    public static int size;
    public UnityEngine.UI.Text text;
    public GameObject next, thisObject;

    

    // Start is called before the first frame update
    void Start()
    {
        size = System.Int32.Parse(text.text);
        if (size >= 10 && size <= 20) 
        {
            next.SetActive(true);
            thisObject.SetActive(false);
        }
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
