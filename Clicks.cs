using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicks : MonoBehaviour
{
    public int cli;
    public Text clicked;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        clicked.text = cli.ToString();
    }

    public void add()
    {
        if(cli < 36)
            {
            cli++;
            }
    }
}
