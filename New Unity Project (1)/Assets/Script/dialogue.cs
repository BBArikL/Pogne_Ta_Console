using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class dialogue : MonoBehaviour
{
    public NPCConversation conversation1;
    public NPCConversation conversation2;
    public NPCConversation conversation3;
    private int dialogueFini;

    private void Start()
    {
        dialogueFini = 0;
    }
    
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {

            FindObjectOfType<AudioManager>().Play("Talk");

            CheckerFlags p1 = new CheckerFlags();
            // If the task was never done
            if (p1.Check(2) != "1")
            {
                ConversationManager.Instance.StartConversation(conversation1);

            } else if (p1.Check(2) == "1" && p1.Check(3) != "1")
            {
                ConversationManager.Instance.StartConversation(conversation2);
            }else if(p1.Check(2) == "1" && p1.Check(3) == "1" && p1.Check(4) != "1")
            {
                ConversationManager.Instance.StartConversation(conversation3);
            }

        }
    }
}
