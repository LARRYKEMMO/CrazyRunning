using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject car;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(car, transform.position, Quaternion.identity);
        Instantiate(car2, transform.position + new Vector3(6, 2, 0), Quaternion.identity);
        Instantiate(car3, transform.position + new Vector3(9, 1, 0), Quaternion.identity);
        Instantiate(car4, transform.position + new Vector3(3, -2, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
