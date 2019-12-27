using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthManager : MonoBehaviour
{

    private Transform hearts;
    public int maxHearts; // in half hearts
    private int currHealth;

    private GameObject fullHeart;
    private Sprite halfHeart;
    private Sprite emptyHeart;
    

    // Start is called before the first frame update
    void Start()
    {
        fullHeart = Resources.Load("GUI/FullHeart") as GameObject;
        halfHeart = Resources.Load<Sprite>("GUI/HalfHeart");
        emptyHeart = Resources.Load<Sprite>("GUI/EmptyHeart");
        hearts = GameObject.Find("Canvas").transform.Find("Hearts");
        currHealth = maxHearts;
        for (int i = 0; i < maxHearts / 2; i++)
        {
            GameObject heart = Instantiate(fullHeart, Vector3.zero, Quaternion.identity);
            heart.transform.SetParent(hearts, false);
        }
    }

    // Damage the player by n half hearts
    public void takeDamage(int n)
    {
        int prevHealth = currHealth;
        currHealth = Math.Max(currHealth - n, 0);
        for (int i = prevHealth; i > currHealth; i -= 2)
        {
            hearts.GetChild((int)(Math.Ceiling(i / 2.0) - 1)).gameObject.GetComponent<Image>().sprite = emptyHeart;
        }
        if (currHealth % 2 == 1)
        {
            
            hearts.GetChild((int)(Math.Ceiling(currHealth / 2.0) - 1)).gameObject.GetComponent<Image>().sprite = halfHeart;
        }
    }
}
