using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVetements : MonoBehaviour
{
    public GameObject button;
    public GameObject go;
    // Start is called before the first frame update

    void Start()
    {
        CheckerFlags p1 = new CheckerFlags();
        // If the task was never done
        if (p1.Check(3) == "1")
        {
            Exec();
            ChangerFlags p2 = new ChangerFlags();
            p2.Change(3); // Change to done

        }
    }
    public void Exec()
    {
        Destroy(this.go);
        ChangerFlags p2 = new ChangerFlags();
        ChangerFlags p3 = new ChangerFlags();
        p2.Change(3); // Change to done
        button.SetActive(false);
        p3.Change(5);
    }
}
