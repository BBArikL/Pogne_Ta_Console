using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        ChangerFlags p1 = new ChangerFlags();
        for(int i=1; i<11; i++)
        {
            p1.resetFlags(i);
        }
    }
    // Start is called before the first frame update
    private float horizon;
    private float vertical;
    public float speed = 10;
    public Transform trans;
    public Rigidbody rb;
    public GameObject button;
    public GameObject GameOverUI;
    public GameObject GameEndUI;
    public Animator transition;
    

    void Start()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        // 1st scene progress
        CheckerFlags p1 = new CheckerFlags();
        if (SceneManager.GetActiveScene().buildIndex==3 && (p1.Check(3)!="1"))
        {
            button.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        horizon = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // Barres

        //WASD mouvement

        if (Input.GetKey(KeyCode.W))
        {
            trans.eulerAngles = new Vector3(90, 0, 0);
            //transform.Translate(0, -0.06f, 0);
            transform.Translate(0, (-vertical * speed * Time.deltaTime), 0);

            PlayWalk();

        }
        if (Input.GetKey(KeyCode.D))
        {
            trans.eulerAngles = new Vector3(90, 0, 270);
            transform.Translate(0, (-horizon * speed * Time.deltaTime), 0);

            PlayWalk();

        }
        if (Input.GetKey(KeyCode.S))
        {
            trans.eulerAngles = new Vector3(90, 0, 180);
            transform.Translate(0, (vertical * speed * Time.deltaTime), 0);

            PlayWalk();
        }
        if (Input.GetKey(KeyCode.A))
        {
            trans.eulerAngles = new Vector3(90, 0, 90);
            transform.Translate(0, (horizon * speed * Time.deltaTime), 0);

            PlayWalk();

        }
        // w + d
        if(Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.D)))
        {
            //speed = 11;
            trans.eulerAngles = new Vector3(90, 0, -40);
            
            transform.Translate(0, ((horizon/2)  * Time.deltaTime), 0);

            PlayWalk();

        }
        // w + a
        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.A)))
        {
            //speed = 8;
            trans.eulerAngles = new Vector3(90, 0, 40);
            transform.Translate(0, (horizon  * Time.deltaTime), 0);

            PlayWalk();

        }
        // s + a
        if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.A)))
        {
            //speed = 8;
            trans.eulerAngles = new Vector3(90, 0, 140);
            transform.Translate(0, (horizon * Time.deltaTime), 0);

            PlayWalk();

        }
        // s + d
        if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.D)))
        {
            //speed = 13;
            trans.eulerAngles = new Vector3(90, 0, -140);
            transform.Translate(0, (horizon * Time.deltaTime), 0);

            PlayWalk();

        }
        // If the player is floating for any reasons
        if (rb.velocity.y > 0)
        {
            rb.velocity = new Vector3(0, (-1 * speed*Time.deltaTime), 0);
        }

        // If player starts to lag
        // Respawn
        if (trans.position.y < 0)
        {
            trans.position = new Vector3(7, 1, -17);
            rb.velocity = Vector3.zero;
        }
        
        CheckerFlags p1 = new CheckerFlags();
        if (p1.Check(8) == "1")
        {
            Debug.Log("Game over");
            //Game Over
            FindObjectOfType<AudioManager>().StopMusic("Wind");
            FindObjectOfType<AudioManager>().Play("GameOver");
            PauseMenuScript.isPaused = true;
            GameOverUI.SetActive(PauseMenuScript.isPaused);
            PauseMenuScript.isPaused = false; //Unpause the game
            System.Threading.Thread.Sleep(4000);
            Time.timeScale = 1f; //Unfreeze Game
            SceneManager.LoadScene("Menu");//Gets back to menu
        }
        

        void CheckGameEnd()
        {
            CheckerFlags p0 = new CheckerFlags();
            CheckerFlags p2 = new CheckerFlags();
            CheckerFlags p3 = new CheckerFlags();
            CheckerFlags p4 = new CheckerFlags();
            CheckerFlags p5 = new CheckerFlags();
            CheckerFlags p6 = new CheckerFlags();
            CheckerFlags p7 = new CheckerFlags();
            if (p0.Check(1) == "1" && p2.Check(2) == "1" && p3.Check(3) == "1" && p4.Check(4) == "1" && p5.Check(5) == "1" &&
                p6.Check(9) == "1" && p7.Check(10) == "1")
            {
                //Game End
                FindObjectOfType<AudioManager>().StopMusic("Wind");
                FindObjectOfType<AudioManager>().Play("GameEnd");
                PauseMenuScript.isPaused = true;
                GameEndUI.SetActive(PauseMenuScript.isPaused);
                PauseMenuScript.isPaused = false; //Unpause the game
                System.Threading.Thread.Sleep(4000);
                Time.timeScale = 1f; //Unfreeze Game
                SceneManager.LoadScene("Menu");//Gets back to menu
            }
        }
        
        CheckGameEnd();
    }
    void PlayWalk() //Plays sound of walking
    {
        if(!FindObjectOfType<AudioManager>().CheckIfPlaying("PlayerWalk")) FindObjectOfType<AudioManager>().Play("PlayerWalk");
    }

} 

