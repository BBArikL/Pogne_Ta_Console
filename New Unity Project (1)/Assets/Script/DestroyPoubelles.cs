using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DestroyPoubelles : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject go;
    
    // Start is called before the first frame update

    void Start()
    {
        CheckerFlags p1 = new CheckerFlags();
        // If the task was never done
        if (p1.Check(9) == "1")
        {
            Exec(9);
            ChangerFlags p2 = new ChangerFlags();
            p2.Change(9); // Change to done
            Debug.Log("Salon");

        }
        if (p1.Check(10) == "1")
        {
            Exec(10);
            ChangerFlags p2 = new ChangerFlags();
            p2.Change(10); // Change to done

            Debug.Log("Chambre");
        }
    }
    private void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Exec(9);
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Exec(10);
        }


    }
    public void Exec(int spec)
    {
        CheckerFlags p1 = new CheckerFlags();
        ChangerFlags p2 = new ChangerFlags();
        ChangerFlags p3 = new ChangerFlags();
        if(spec==9 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            // Maison
            Destroy(this.go);
            p2.Change(9); // Change to done
            
        }
        if( spec==10 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            // Chambre
            Destroy(this.go);
            
            
            p3.Change(10); // Change to done
        }
        
    }
}
