using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Score scoreScript;
    public Text Jump;
    public bool invisibleMode = false;
    private int JumpCounter = 5;
    public AudioSource CarSound;
    public AudioSource BackgroundSound;
    public AudioSource CrashAudio;
    private TrailRenderer ShieldTrail;

    void Start()
    {
        Jump.text = "Jump: " + JumpCounter;
        CarSound.Play();
        BackgroundSound.Play();
        scoreScript = FindObjectOfType<Score>();
        ShieldTrail = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(invisibleMode == false && Time.timeScale != 0)
            {
                if (JumpCounter > 0)
                {
                    gameObject.transform.localScale = new Vector3(1.7f, 1.87f, gameObject.transform.localScale.z);
                    invisibleMode = true;
                    JumpCounter--;
                    Jump.text = "Jump: " + JumpCounter;
                    Invoke("ResetTrigger", 0.8f);
                }
                
                
            }

            if(Time.timeScale == 0f)
            {
                SceneManager.LoadScene("GameScene");
                scoreScript.SetGameOverfalse();
                CarSound.Play();
                BackgroundSound.Play();
                JumpCounter = 5;
                Jump.text = "Jump: " + JumpCounter;
            }
            
        }

        if(invisibleMode == true)
        {
            if(Time.timeScale != 0)
            {
                InvisibleMode();
                ShieldTrail.enabled = true;
                if (JumpCounter < 1)
                {
                    Invoke("ResetJumpCounter", 30);
                }

            }

        }
        else
        {
            EndInvisibleMode();
            ShieldTrail.enabled = false;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-5 * Time.deltaTime, 0, 0);
        //    Debug.Log("Here1");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(5 * Time.deltaTime, 0, 0);
        //    Debug.Log("Here1");

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" || collision.collider.tag == "Sidewalk")
        {
            CrashAudio.Play();
            scoreScript.SetGameOver();
            CarSound.Stop();
        }
    }

    public void ResetTrigger()
    {
        gameObject.transform.localScale = new Vector3(1.3f, 1.43f, gameObject.transform.localScale.z);
        invisibleMode = false;
    }

    public void InvisibleMode()
    {
        gameObject.GetComponentInParent<BoxCollider2D>().isTrigger = true;

    }
    public void EndInvisibleMode()  {
        gameObject.GetComponentInParent<BoxCollider2D>().isTrigger = false;
    }

    public void SetInvisibeModeToTrue()
    {
       invisibleMode = true;
    }

    public void SetInvisibeModeToFalse()
    {
        invisibleMode = false;
    }

    private void ResetJumpCounter()
    {
        JumpCounter = 5;
        Jump.text = "Jump: " + JumpCounter;
    }


}
