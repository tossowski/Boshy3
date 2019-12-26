using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{

    public GameObject background;

    public GameObject farground;
    // Start is called before the first frame update
    void Start()
    {
        float width = background.transform.Find("clouds").GetComponent<SpriteRenderer>().sprite.rect.width * background.transform.localScale.x / 8f;
        float width2 = background.transform.Find("clouds").GetComponent<SpriteRenderer>().sprite.rect.width * background.transform.localScale.x / 8f;
        for (int i = 0; i < 10; i++)
        {
            Instantiate(background, background.transform.position + new Vector3((i + 1) * width, 0.0f, 0.0f), Quaternion.identity);
            Instantiate(farground, farground.transform.position + new Vector3((i + 1) * width2, 0.0f, 0.0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
