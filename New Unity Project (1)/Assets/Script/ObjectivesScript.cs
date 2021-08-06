using UnityEngine;
using UnityEngine.UI;

public class ObjectivesScript : MonoBehaviour
{
    public Text text;

    public void ChangeObjectif(string objectif)
    {
        if (objectif == "gazon")
        {
            text.text = "Objectif: Va couper le gazon du voisin.";
        }
        else if (objectif == "Rentre")
        {
            text.text = "Objectif: Rentre à la maison.";
        }
        else if (objectif == "vaisselle")
        {
            text.text = "Objectif: Faire la vaisselle.";
        }else if(objectif == "chambre")
        {
            text.text = "Objectif: Va dans ta chambre et range-la.";
        }else if(objectif == "poubelles")
        {
            text.text = "Objectif: Sélectionner les deux poubelles et les sortir.";
        }
        else if (objectif=="mere")
        {
            text.text = "Va voir ta mere";
        }
    }
}