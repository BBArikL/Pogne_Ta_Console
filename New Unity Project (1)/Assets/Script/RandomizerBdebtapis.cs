using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerBdebtapis : MonoBehaviour
{
    public Transform tapis;
    public float[] pos1 = new float[3];
    public float[] pos2 = new float[3];
    public float[] pos3 = new float[3];
    public float[] pos4 = new float[3];

    // Start is called before the first frame update
    void Start()
    {
        tapis = GetComponent<Transform>(); 
        int rand = Random.Range(1, 4);
        Debug.Log(rand.ToString());
        if (rand == 1)
        {
            tapis.position = new Vector3(pos1[0], pos1[1], pos1[2]);
        }
        else if (rand == 2)
        {
            tapis.position = new Vector3(pos2[0], pos2[1], pos2[2]);
        }
        else if (rand == 3)
        {
            tapis.position = new Vector3(pos3[0], pos3[1], pos3[2]);
        }
        else if (rand == 4)
        {
            tapis.position = new Vector3(pos4[0], pos4[1], pos4[2]);
        }
    }
}
