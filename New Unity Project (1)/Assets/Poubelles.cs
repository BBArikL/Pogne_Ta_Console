using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poubelles : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        CheckerFlags p1 = new CheckerFlags();
        // If the task was never done
        if (p1.Check(4) == "1" )
        {
            Exec();
            ChangerFlags p2 = new ChangerFlags();
            p2.Change(4); // Change to done

        }
    }
    public void OnMouseDown()
    {
        Exec();
    }
    public void Exec()
    {
        CheckerFlags p1 = new CheckerFlags();
        if (p1.Check(9)=="1" && p1.Check(10)=="1")
        {
            Destroy(this.go);
            ChangerFlags p2 = new ChangerFlags();
            p2.Change(4); // Change to done
        }
        
    }
}
