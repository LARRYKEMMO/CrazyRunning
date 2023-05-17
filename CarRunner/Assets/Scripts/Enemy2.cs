using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool PowerUp = false;
    private Vector3 OriginalPosition;
    private float increment = 4f;
    private bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        OriginalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver == false)
        {
            if (PowerUp == true)
            {
                transform.position -= new Vector3(0, (increment + 10) * Time.deltaTime, 0);
            }
            else
            {
                transform.position -= new Vector3(0, increment * Time.deltaTime, 0);

            }
        }

        if (transform.position.y <= -6)
        {
            transform.position = new Vector3(Random.Range(OriginalPosition.x - 2, OriginalPosition.x + 0.5f), Random.Range(OriginalPosition.y, OriginalPosition.y + 3), OriginalPosition.z);
        }
    }

    public void SetPowerUp2True()
    {
        PowerUp = true;
    }
    public void SetPowerUp2False()
    {
        PowerUp = false;
    }

    public void SetGameOverE2()
    {
        GameOver = true;
    }
}
