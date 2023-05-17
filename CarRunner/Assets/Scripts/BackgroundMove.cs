using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private bool Speed = false;
    private float IncrementSpeed = 5f;
    private Vector3 OriginalPosition;
    // Start is called before the first frame update
    void Start()
    {
        OriginalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (Speed == true)
        {
            transform.position -= new Vector3(0, (IncrementSpeed + 10) * Time.deltaTime, 0);
        }
        else
        {
            transform.position -= new Vector3(0, IncrementSpeed * Time.deltaTime, 0);
        }

        if (gameObject.transform.position.y <= -100)
        {
            gameObject.transform.position = OriginalPosition;
        }
    }

    public void SetSpeedTrue()
    {
        Speed = true;
    }
    public void SetSpeedFalse()
    {
        Speed = false;
    }
}
