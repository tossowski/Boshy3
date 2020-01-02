using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIO : Enemy
{

    public float timeBetweenAttacks;
    private Vector2 vel;
    private float counter;
    private int knivesThrown;

    public override void Start()
    {
        knivesThrown = 0;
        counter = 0.0f;
        vel = new Vector2(10.0f, 0.0f);
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Time.timeScale == 0f && !player.GetComponent<PlayerController>().UIOpen)
        {
            move();
            if (counter <= 0)
            {
                knivesThrown++;
                counter = timeBetweenAttacks;
                GameObject knife = Resources.Load("Knife") as GameObject;
                Instantiate(knife, transform.position, Quaternion.identity);
            } else
            {
                counter -= 0.01f;
            }
            if (knivesThrown == 10)
            {
                knivesThrown = 0;
                transform.Find("DIOWarudo").GetComponent<DIOWarudo>().resumeTime();
            }
        }
        
    }

    public override void move()
    {

        transform.position = new Vector2(player.transform.position.x, player.transform.position.y) + Random.insideUnitCircle * 5;
        return;

        float distance = Vector3.Distance(player.transform.position, transform.position);
        float dx = player.transform.position.x - transform.position.x;
        if (dx < 0 && distance > 5)
        {
            vel = new Vector2(-10.0f, 0.0f);
        } else if (dx > 0 && distance > 5)
        {
            vel = new Vector2(10.0f, 0.0f);
        }

        transform.position = new Vector3(transform.position.x + vel.x * 0.01f, transform.position.y + vel.y * 0.01f, transform.position.z);
    }

    
}
