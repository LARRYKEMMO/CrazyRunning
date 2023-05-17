using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public GameObject player;
    private ShieldPowerUp shieldPowerScript;
    public SpriteRenderer spriteRenderer;
    public Score scoreScript;
    public Sprite speedSprite;
    public Sprite normalSprite;
    private Vector3 OriginalPosition;
    private int Increment = 3;
    public Enemy enemy1;
    public Enemy2 enemy2;
    public Enemy3 enemy3;
    public Enemy4 enemy4;
    public BackgroundMove background;
    public Cop[] copList;
    public Player PlayerScript;
    public ShakerScript shakerScript;
    private WordScript wordScript;
    public bool SpeedOn = false;
    
    //   private bool ImOnSpeed = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript = FindObjectOfType<Player>();
        shieldPowerScript = FindObjectOfType<ShieldPowerUp>();
        OriginalPosition = transform.position;
        enemy1 = FindObjectOfType<Enemy>();
        enemy2 = FindObjectOfType<Enemy2>();
        enemy3 = FindObjectOfType<Enemy3>();
        enemy4 = FindObjectOfType<Enemy4>();
        background = FindObjectOfType<BackgroundMove>();
        copList = FindObjectsOfType<Cop>();
        scoreScript = FindObjectOfType<Score>();
        shakerScript = FindObjectOfType<ShakerScript>();
        wordScript = FindObjectOfType<WordScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, Increment * Time.deltaTime, 0);

        if (transform.position.y <= -20)
        {
            transform.position = new Vector3(Random.Range(OriginalPosition.x - 9, OriginalPosition.x), Random.Range(OriginalPosition.y - 3 , OriginalPosition.y + 5), gameObject.transform.position.z);
        }

        if(SpeedOn == true)
        {
            player.GetComponent<SpriteRenderer>().sprite = speedSprite;
            shakerScript.StartShake();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            wordScript.DisplaySpeedWord();
            shieldPowerScript.ShieldOn = false;
            SpeedOn = true;
            shieldPowerScript.SetShieldFalse();
            player.GetComponent<SpriteRenderer>().sprite = speedSprite;
            IncreaseAllSpeed();
            scoreScript.ActivateScoreSpeed();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Invoke("DisableSpeedSprite", 15);
            Invoke("EnablePowerUp", 2);

        }
    }

    public void DisableSpeedSprite()
    {
        SpeedOn = false;
        shakerScript.StopShake();
        player.GetComponent<SpriteRenderer>().sprite = normalSprite;
        BackToNormal();
        scoreScript.DeactivateScoreSpeed();
    }

    public void EnablePowerUp()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void IncreaseAllSpeed()
    {
        enemy1.SetPowerUp1True();
        enemy2.SetPowerUp2True();
        enemy3.SetPowerUp3True();
        enemy4.SetPowerUp4True();
        background.SetSpeedTrue();
        foreach(var cop in copList)
        {
            cop.SetSpeedTrue();
        }
    }

    public void BackToNormal()
    {
        enemy1.SetPowerUp1False();
        enemy2.SetPowerUp2False();
        enemy3.SetPowerUp3False();
        enemy4.SetPowerUp4False();
        background.SetSpeedFalse();
        foreach (var cop in copList)
        {
            cop.SetSpeedFalse();
        }
    }

    public void SetSpeedtrue()
    {

    }

    public void SetSpeedFalse()
    {
        PlayerScript.SetInvisibeModeToTrue();
        player.GetComponent<SpriteRenderer>().sprite = normalSprite;
        BackToNormal();
    }

    
}
