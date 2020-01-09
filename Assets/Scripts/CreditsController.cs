using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour
{

    Image trio;

    void Start()
    {
        trio = GameObject.Find("Canvas").transform.Find("Panel").transform.Find("Credits").transform.Find("Spoiler").gameObject.GetComponent<Image>();
    }

    void revealSprite()
    {
        StartCoroutine(brighten(trio));
    }

    IEnumerator brighten(Image image)
    {
        while (image.color.a < 1)
        {
            Color prev = image.color;
            prev.a += Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
            image.color = prev;
        }
        
    }
}
