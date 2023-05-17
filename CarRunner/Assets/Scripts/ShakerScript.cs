using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerScript : MonoBehaviour
{
    private float magnitude = 1.5f;
    private float duration = 0.7f;
    public GameObject Camera;
    private bool Shaker = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Shaker == true)
        {
            Debug.Log("Shake");
            StartCoroutine(Shake());
        }
        else
        {
            StopCoroutine(Shake());
        }
    }

    private IEnumerator Shake()
    {
        Vector3 OriginalPos = Camera.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-0.05f, 0.05f) * magnitude;
            float y = Random.Range(-0.05f, 0.05f) * magnitude;

            Camera.transform.localPosition = new Vector3(x, y, OriginalPos.z);

            elapsed += Time.deltaTime;


            yield return null;
        }
        Camera.transform.localPosition = OriginalPos;
    }

    public void StartShake()
    {
        Shaker = true;
    }

    public void StopShake()
    {
        Shaker = false;
    }
}
