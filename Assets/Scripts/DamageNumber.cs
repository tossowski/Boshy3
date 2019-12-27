using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageNumber : MonoBehaviour
{

    public int damageNumber;

    public float moveSpeed;

    public TextMeshProUGUI displayNumber;

    Rigidbody2D rb;

    // Use this for initialization
    void Awake()
    {
        displayNumber.text = "-" + damageNumber;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y - moveSpeed / 1000);
        }
    }
}