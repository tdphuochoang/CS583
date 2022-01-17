using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //singleton
    public GameManger gm;
    // GameObject references
    public GameObject cannon;
    public GameObject ball;
    // shooting position reference
    public Transform shootPos;
    // variables for moving and firing cannon
    public float firePwr;
    public float rotateSpeed;
    //variables for setting rotation boundaries
    float x_Degrees;
    float y_Degrees;

    float previousTime;
    void Start()
    {
        gm = GameManger.Instance;
        previousTime = -1.8F;
    }

    void Update()
    {
        rotateCannon();
        //fireCannon();
        StartCoroutine(fireAndWait());
    }

    public void rotateCannon()
    {
        //Store x and y degrees
        x_Degrees = cannon.transform.rotation.eulerAngles.x;
        y_Degrees = cannon.transform.rotation.eulerAngles.y;

        //Player movement with arrow keys and add or subtract rotate speed to x or y degrees

        // vertical rotation constraints
        if (x_Degrees <= 15f || x_Degrees >= 300f)
        {
            if (Input.GetKey("up"))
                x_Degrees -= (rotateSpeed * Time.deltaTime);
            if (Input.GetKey("down"))
                x_Degrees += (rotateSpeed * Time.deltaTime);
        }
        else if (x_Degrees < 180f && x_Degrees > 15f)
            x_Degrees = 14.9f;
        else if (x_Degrees > 180f && x_Degrees < 300f)
            x_Degrees = 300.1f;

        // horizontal rotation constraints
        if (y_Degrees >= 320f || y_Degrees <= 40f)
        {
            if (Input.GetKey("left"))
                y_Degrees -= (rotateSpeed * Time.deltaTime);
            if (Input.GetKey("right"))
                y_Degrees += (rotateSpeed * Time.deltaTime);
        }
        else if (y_Degrees < 180f && y_Degrees > 40f)
            y_Degrees = 39.9f;
        else if (y_Degrees > 180f && y_Degrees < 320f)
            y_Degrees = 320.1f;

        //rotate cannon every frame
        cannon.transform.rotation = Quaternion.Euler(x_Degrees, y_Degrees, 0f);
    }
    public void fireCannon()
    {
        if(Input.GetKeyDown("space"))
        {
            // create cannon ball gameObject at shooting position with no rotation
            GameObject cannonBall = Instantiate(ball, shootPos.transform.position, Quaternion.identity);
            // reference rigidbody of cannonball
            Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
            // add force to rb based on fire power
            rb.AddForce(shootPos.forward * firePwr, ForceMode.Impulse);
            //remove cannonballs from scene after some time
            Destroy(cannonBall, 5f);
        }
    }

    //test waiting for 1 second after shooting
    IEnumerator fireAndWait()
    {
        if (Input.GetKeyDown("space") && ((Time.time - previousTime) > 1.8F))
        {
            //decrement num of cannonballs;
            gm.UseCannonBalls();
            previousTime = Time.time;
            // create cannon ball gameObject at shooting position with no rotation
            GameObject cannonBall = Instantiate(ball, shootPos.transform.position, Quaternion.identity);
            // reference rigidbody of cannonball
            Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
            // add force to rb based on fire power
            rb.AddForce(shootPos.forward * firePwr, ForceMode.Impulse);
            //remove cannonballs from scene after some time
            Destroy(cannonBall, 5f);

            yield return new WaitForSeconds(1);

        }
    }
}
