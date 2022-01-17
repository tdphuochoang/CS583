using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3[] points; 
    public int point_number = 0; //the point we looking at
    private Vector3 current_target;

    public float speed;
    public float delay;
    public float tolerance;
    

    private float delay_start;

    public bool automatic;

    // Start is called before the first frame update
    void Start()
    {
        if(points.Length > 0)
        {
            current_target = points[0]; //initialize first point

        }
        tolerance = speed * Time.deltaTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != current_target)
        {
            Move();
        }
        else
        {
            UpdateTarget();
        }
        
    }

    void Move()
    {
        Vector3 heading = current_target - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if (heading.magnitude < tolerance)
        {
            transform.position = current_target;
            delay_start = Time.time;
        }
    }
    void UpdateTarget()
    {
        if (automatic)
        {
            if(Time.time - delay_start > delay)
            {
                NextPlatform();
            }
        }
    }
    public void NextPlatform()
    {
        point_number++;
        if(point_number >= points.Length)
        {
            point_number = 0;
        }
        current_target = points[point_number];
    }
    void onTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
    
    /*int speed = 10;
    
    void Start()
    {

    }
    void Update()
    {
        if(transform.position.x <= -7)
        {
            speed = 10;
        }
        if(transform.position.x >= 7)
        {
            speed = -10;
        }
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }*/

}

 