using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ChangerFlags
{
    // Start is called before the first frame update
    public void Change(int spec)
    {

        // We will change to 1 if required
        // 1 == done 0 == not "done"

        // Write the specified flag
        int i = 0;
        try
        {
            
            StreamReader sr = new StreamReader("data.txt.txt");
            String[] line = new string[11];
            line[i] = sr.ReadLine(); // 1 line
            //Continue to read until you reach end of file
            while (i<line.Length-1)
            {
                i++;
                // Read all the lines and stored them if something fails
                line[i] = sr.ReadLine();
            }
            sr.Close();
            
            StreamWriter sw = new StreamWriter("data.txt.txt");
            switch (spec)
            {
                case 1:
                    // fd
                    line[spec -1] = "fd-1";
                    break;
                case 2:
                    line[spec -1] = "fm1t-1";
                    break;
                case 3:
                    line[spec - 1] = "fm2t-1";
                    break;
                case 4:
                    line[spec - 1] = "fm3t-1";
                    break;
                case 5:
                    line[spec - 1] = "fvc-1";
                    break;
                case 6:
                    if (line[spec - 1].Split('-')[1] == "0")
                    {
                        line[spec - 1] = "fbb-1";
                        break;
                    }
                    else if (line[spec - 1].Split('-')[1] == "1")
                    {
                        line[spec - 1] = "fbb-2";
                        break;
                    }
                    else if (line[spec - 1].Split('-')[1] == "2")
                    {
                        line[spec - 1] = "fbb-3";
                        line[7] = "fgo-1";
                        break;
                    }
                    else if (line[spec - 1].Split('-')[1] == "3")
                    {
                        // Game over
                        line[7] = "fgo-1";
                        break;
                    }
                    break;
                case 7:
                    if (line[spec - 1].Split('-')[1] == "0")
                    {
                        line[spec - 1] = "fbr-1";
                        break;
                    }
                    else if (line[spec-1].Split('-')[1]=="1")
                    {
                        line[spec - 1] = "fbr-2";
                        break;
                    }
                    else if(line[spec - 1].Split('-')[1] == "2")
                    {
                        line[spec - 1] = "fbr-3";
                        line[7] = "fgo-1";
                        break;
                    }
                    else if(line[spec - 1].Split('-')[1] == "3")
                    {
                        // Game over
                        line[7] = "fgo-1";
                        break;
                    }
                    break;
                case 9:
                    line[spec - 1] = "fp1-1";
                    break;
                case 10:
                    line[spec - 1] = "fp2-1";
                    break;
            }
            for(i=0;i<line.Length-1;i++)
            {
                sw.WriteLine(line[i]);
            }
            sw.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public void resetFlags(int spec)
    {
        // We will change to 1 if required
        // 1 == done 0 == not "done"

        // Write the specified flag
        int i = 0;
        try
        {

            StreamReader sr = new StreamReader("data.txt.txt");
            String[] line = new string[11];
            line[i] = sr.ReadLine(); // 1 line
            //Continue to read until you reach end of file
            while (i < line.Length - 1)
            {
                i++;
                // Read all the lines and stored them if something fails
                line[i] = sr.ReadLine();
            }
            sr.Close();

            StreamWriter sw = new StreamWriter("data.txt.txt");
            switch (spec)
            {
                case 1:
                    // fd
                    line[spec - 1] = "fd-0";
                    break;
                case 2:
                    line[spec - 1] = "fm1t-0";
                    break;
                case 3:
                    line[spec - 1] = "fm2t-0";
                    break;
                case 4:
                    line[spec - 1] = "fm3t-0";
                    break;
                case 5:
                    line[spec - 1] = "fvc-0";
                    break;
                case 6:
                    line[spec - 1] = "fbb-0";
                    break;
                case 7:
                    line[spec - 1] = "fbr-0";
                    break;
                case 9:
                    line[spec - 1] = "fp1-0";
                    break;
                case 10:
                    line[spec - 1] = "fp2-0";
                    break;
            }
            for (i = 0; i < line.Length - 1; i++)
            {
                sw.WriteLine(line[i]);
            }
            sw.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
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
 * 9->flag poubelle 1
 * 10->flag poubelle 1
 */
