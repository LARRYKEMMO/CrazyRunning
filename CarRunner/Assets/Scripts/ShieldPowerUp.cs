using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public GameObject player;
    private SpeedPowerUp speedScript;
    public SpriteRenderer spriteRenderer;
    public Sprite shieldSprite;
    public Sprite normalSprite;
    private Vector3 OriginalPosition;
    private int Increment = 3;
    public Player PlayerScript;
    private ShakerScript shakerScript;
    private WordScript wordScript;
    public bool ShieldOn = false;
 //   private bool ImOnShield = false;
    // Start is called before the first frame update
    void Start()
    {
        OriginalPosition = transform.position;
        PlayerScript = FindObjectOfType<Player>();
        speedScript = FindObjectOfType<SpeedPowerUp>();
        shakerScript = FindObjectOfType<ShakerScript>();
        wordScript = FindObjectOfType<WordScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, Increment * Time.deltaTime, 0);

        if (transform.position.y <= -20)
        {
            transform.position = new Vector3(Random.Range(OriginalPosition.x - 5, OriginalPosition.x), Random.Range(OriginalPosition.y - 2, OriginalPosition.y + 3), gameObject.transform.position.z);
        }

        if(ShieldOn == true)
        {
            player.GetComponent<SpriteRenderer>().sprite = shieldSprite;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            wordScript.DisplayShieldWord();
            shakerScript.StopShake();
            speedScript.SpeedOn = false;
            ShieldOn = true;
            speedScript.SetSpeedFalse();
            player.GetComponent<SpriteRenderer>().sprite = shieldSprite;
            PlayerScript.SetInvisibeModeToTrue();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Invoke("DisableSpeedSprite", 15);
            Invoke("EnablePowerUp", 1);

        }
    }

    public void DisableSpeedSprite()
    {
        ShieldOn = false;
        PlayerScript.SetInvisibeModeToFalse();
        player.GetComponent<SpriteRenderer>().sprite = normalSprite;
    }

    public void EnablePowerUp()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    

    public void SetShieldtrue()
    {

    }

    public void SetShieldFalse()
    {
        PlayerScript.SetInvisibeModeToFalse();
        player.GetComponent<SpriteRenderer>().sprite = normalSprite;
    }
}
