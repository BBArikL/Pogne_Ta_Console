using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class BarreGentillesse : MonoBehaviour
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
        switch (p1.Check(6))
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
    public void AddGentil()
    {
        GetCurrent();
        current++;
        ChangerFlags p2 = new ChangerFlags();
        p2.Change(6);
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillamount = (float)current / (float)maximum;
        mask.fillAmount = fillamount;
    }
}
