using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class CouperGazonMere: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject go;
    public GameObject gazon;
    public GameObject mere;
    public GameObject button;
    private void Start()
    {
        CheckerFlags p1 = new CheckerFlags();
        // If the task was never done
        if (p1.Check(1) == "1")
        {
            Exec();
            ChangerFlags p2 = new ChangerFlags();
            p2.Change(1); // Change to done
            
        }
    }
    public void Exec()
    {
        Destroy(this.gazon);
        Destroy(this.go);
        Destroy(mere);
        button.SetActive(false);

        ChangerFlags p2 = new ChangerFlags();
        p2.Change(1); // Change to done
    }
    
}


