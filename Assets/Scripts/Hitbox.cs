using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private GameObject effect;
    private GameObject damagenumber;
    public int damage;
    void Start()
    {
        player = GameObject.Find("Player");
        effect = Resources.Load("HitEffect") as GameObject;
        damagenumber = Resources.Load("GUI/DamageNumber") as GameObject;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            if (!anim.GetBool("SHINEI"))
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.hitStun();
                Instantiate(effect, collision.gameObject.transform.position, Quaternion.identity);
                var clone = Instantiate(damagenumber, enemy.damageLoc.transform.position, Quaternion.identity) as GameObject;
                clone.GetComponent<DamageNumber>().displayNumber.text = "-" + damage;
                Vector3 dirVector = Vector3.Normalize(new Vector3(1.0f, 1.0f, 0.0f));
                if (collision.gameObject.transform.position.x < player.transform.position.x)
                {
                    dirVector = Vector3.Normalize(new Vector3(-1.0f, 1.0f, 0.0f));
                }
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

                rb.AddForce(dirVector * 1000.0f, ForceMode2D.Impulse);
                enemy.damage(5);
            }

        } else if (collision.gameObject.tag == "Dummy")
        {
            collision.gameObject.GetComponent<Dummy>().damage(damage);
        }
    }

}
