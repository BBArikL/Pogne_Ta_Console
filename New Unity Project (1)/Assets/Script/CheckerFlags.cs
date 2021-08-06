using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class CheckerFlags
{
    // We specify two arguments the type and wich one we want to modify or look uo
    public string Check(int spec)
    {
        string flag;
        int i = 0;
        // If we want to change
        string[] line= new string[11];
        try
        {
            StreamReader sr = new StreamReader("data.txt.txt");
            line[i] = sr.ReadLine(); // 1 line
            //Continue to read until you reach end of file
            while (i<spec)
            {
                i++;
                // Read all the lines and stored them if something fails
                line[i] = sr.ReadLine();
                    
            }
            sr.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        //Debug.Log(line[spec -1]);
        flag = (line[spec -1].Split('-')[1]);
        return flag;
    }
}
/*
 * 1 -> dehors flag
 * 2-> flag mere 1 tache
 * 3-> flag mere 2 tache
 * 4-> flag mere 3 tache
 * 5-> flag vetements chambre
 * 6-> flag barre bleu
 * 7-> flag barre rouge
 * 8-> flag game over
 */