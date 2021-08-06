using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Barrerébellion : MonoBehaviour
{
    public int maximum=3;
    private CheckerFlags p1 = new CheckerFlags();
    private int current;

    private void Start()
    {
        
    }
    private void Update()
    {
        GetCurrent();

        GetCurrentFill();
    }
    
    private void GetCurrent()
    {
        switch(p1.Check(7))
        {
            case "1":
                current = 1;
                break;
            case "2":
                current = 2;
                break;
            case "3":
                current = 3;
                break;
        }
    }
    public Image mask;

    public void AddRebell()
    {
        GetCurrent();
        current++;
        ChangerFlags p2 = new ChangerFlags();
        p2.Change(7);
        GetCurrentFill();
    }

    public void GetCurrentFill()
    {
        float fillamount = (float)current / (float)maximum;
        mask.fillAmount = fillamount;
    }
}
