using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour
{

    Image trio;
    Animator anim;

    void Start()
    {
        trio = GameObject.Find("Canvas").transform.Find("Panel").transform.Find("Credits").transform.Find("Spoiler").gameObject.GetComponent<Image>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey("e"))
        {
            anim.SetFloat("speed", 5.0f);
        } else
        {
            anim.SetFloat("speed", 1.0f);
        }
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
