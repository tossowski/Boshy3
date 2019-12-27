using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBox : MonoBehaviour
{
    private GameObject player;
    public int damage;

    void Start()
    {
        player = GameObject.Find("Player");
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthManager>().takeDamage(damage);
           // Vector3 dirVector = Vector3.Normalize(new Vector3(1.0f, 1.0f, 0.0f));
           // if (collision.gameObject.transform.position.x > player.transform.position.x)
           // {
            //    dirVector = Vector3.Normalize(new Vector3(-1.0f, 1.0f, 0.0f));
            //}
            //Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            //rb.AddForce(dirVector * 1000.0f, ForceMode2D.Impulse);
        }
    }
}
