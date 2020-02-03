using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info3 : MonoBehaviour
{
    public static int info3 = 0;
    // Start is called before the first frame update
    private void Start()
    {
        info3 = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = info3.ToString();
    }
}
