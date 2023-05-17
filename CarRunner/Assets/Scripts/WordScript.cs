using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordScript : MonoBehaviour
{
    private GameObject WordObject;
    public GameObject WordShieldPrefab;
    public GameObject WordSpeedPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DisplaySpeedWord()
    {
        WordObject = Instantiate(WordSpeedPrefab, gameObject.transform.position, Quaternion.identity);

    }

    public void DisplayShieldWord()
    {
        WordObject = Instantiate(WordShieldPrefab, gameObject.transform.position, Quaternion.identity);

    }
}
