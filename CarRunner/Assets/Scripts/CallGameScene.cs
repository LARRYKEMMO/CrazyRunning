using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallGameScene : MonoBehaviour
{
    public Slider slider;
    public Text progressText;
    public float loadTime = 2f;
    public float fadeTime = 1f;
    private float loadtimer = 0f;
    private float fadetimer = 0f;
    public bool startUpdate = false;
    public Image fadeImage;
    private Color fadeColor;

    // Start is called before the first frame update
    void Start()
    {
        fadeColor = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startUpdate) return;
        loadtimer += Time.deltaTime;
        if (loadtimer < loadTime)
        {
            float progress = Mathf.Min(loadtimer / loadTime, 1f);
            Debug.Log(progress);
            slider.value = progress;
            progressText.text = (int)(progress * 100f) + "%";
        }
        else
        {
            if(fadetimer < fadeTime)
            {
                fadetimer += Time.deltaTime;
                float progress = Mathf.Min(fadetimer / fadeTime, 1f);
                fadeColor.a = progress;    
                fadeImage.color = fadeColor;

            }
            else
            {
                SceneManager.LoadScene(1);

            }
        }
    }

    public void CallGameSceneNow()
    {
        slider.gameObject.SetActive(true);
        startUpdate = true;
        fadeImage.gameObject.SetActive(true);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
