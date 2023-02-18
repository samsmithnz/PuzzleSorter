using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadingbar : MonoBehaviour
{

    private RectTransform rectComponent;
    private Image imageComp;
    public float speed = 0.1f;


    // Use this for initialization
    void Start()
    {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 0.1f;

        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        while (operation != null)
        {
            if (imageComp.fillAmount < 1f)
            {
                //imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
                imageComp.fillAmount = Mathf.Clamp01(operation.progress / speed);
            }
            else
            {
                imageComp.fillAmount = 0.0f;
            }
            yield return null;
        }
    }
}
