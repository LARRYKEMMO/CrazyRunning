using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Cop : MonoBehaviour
{
    private bool Speed = false;
    private float IncrementSpeed = 5f;
    private Vector3 OriginalPosition;
    [SerializeField] private GameObject crowd1;
    [SerializeField] private GameObject crowd2;
    // Start is called before the first frame update
    void Start()
    {
        OriginalPosition = crowd2.transform.position;
        //OriginalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (Speed == true)
        {
            crowd1.transform.position -= new Vector3(0, (IncrementSpeed + 20) * Time.deltaTime, 0);
            crowd2.transform.position -= new Vector3(0, (IncrementSpeed + 20) * Time.deltaTime, 0);

        }
        else
        {
            crowd1.transform.position -= new Vector3(0, IncrementSpeed * Time.deltaTime, 0);
            crowd2.transform.position -= new Vector3(0, IncrementSpeed * Time.deltaTime, 0);

        }

        if (crowd1.transform.position.y <= -16)
        {
            crowd1.transform.position = OriginalPosition;
        }
        if (crowd2.transform.position.y <= -16)
        {
            crowd2.transform.position = OriginalPosition;
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
