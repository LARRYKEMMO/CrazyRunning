using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
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
            transform.position = new Vector3(Random.Range(OriginalPosition.x + -1.5f, OriginalPosition.x), Random.Range(OriginalPosition.y, OriginalPosition.y + 5), OriginalPosition.z);
        }
    }

    public void SetPowerUp4True()
    {
        PowerUp = true;
    }
    public void SetPowerUp4False()
    {
        PowerUp = false;
    }

    public void SetGameOverE4()
    {
        GameOver = true;
    }
}
