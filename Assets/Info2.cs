using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info2 : MonoBehaviour
{
    public static int info2 = 0;
    // Start is called before the first frame update
    private void Start()
    {
        info2 = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = "y: " + info2.ToString();
    }
}