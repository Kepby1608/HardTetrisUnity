using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectShapes : MonoBehaviour
{
    //public int number;
    public static int number;
    public GameObject next, thisObject;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        Start();
    }
    // Update is called once per frame
    void Update()
    {
        number = System.Convert.ToInt32(transform.name);
        next.SetActive(true);
        thisObject.SetActive(false);

        gameObject.SetActive(false);
    }
}
