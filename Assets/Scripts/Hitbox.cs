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


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().damage(5);
            Instantiate(effect, collision.gameObject.transform.position, Quaternion.identity);
            var clone = Instantiate(damagenumber, collision.gameObject.transform.position, Quaternion.identity) as GameObject;
            clone.GetComponent<DamageNumber>().displayNumber.text = "-" + damage;
            Animator anim = collision.gameObject.GetComponent<Animator>();
            anim.SetBool("hitstun", true);
            Vector3 dirVector = Vector3.Normalize(new Vector3(1.0f, 1.0f, 0.0f));
            if (collision.gameObject.transform.position.x < player.transform.position.x)
            {
                dirVector = Vector3.Normalize(new Vector3(-1.0f, 1.0f, 0.0f));
            }
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            
            rb.AddForce(dirVector * 1000.0f, ForceMode2D.Impulse);
        }
    }

}
