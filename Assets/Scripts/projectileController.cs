using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    private GameObject player;
    public float range;
    protected Rigidbody2D myRigidBody;
    public float moveSpeed;

    private bool facingLeft;

    void Awake()
    {
        player = GameObject.Find("Player");
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, -137f);
        Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
        transform.Rotate(new Vector3(0f, 0f, 180 * Mathf.Atan2(direction.y, direction.x) / Mathf.PI));
        
        Destroy(gameObject, range);
        
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.velocity = (direction * moveSpeed);
        
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<HealthManager>().takeDamage(2);
            GameObject damagenumber = Resources.Load("GUI/DamageNumber") as GameObject;
            var clone = Instantiate(damagenumber, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            clone.GetComponent<DamageNumber>().displayNumber.text = "-1";
            Destroy(gameObject);
        }
    }

}
