using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAssiette : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update

    void Start()
    {
        CheckerFlags p1 = new CheckerFlags();
        // If the task was never done
        if (p1.Check(2) == "1")
        {
            Exec();
            ChangerFlags p2 = new ChangerFlags();
            p2.Change(2); // Change to done

        }
    }
    private void OnMouseDown()
    {
        Exec();
    }
    public void Exec()
    {
        Destroy(this.go);
        ChangerFlags p2 = new ChangerFlags();
        p2.Change(2); // Change to done
    }
}
