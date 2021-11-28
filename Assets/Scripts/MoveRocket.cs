using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocket : MonoBehaviour
{
    public float RotationForce = 2f;
    public float thrustMultiplier = 1f;
    public float MaxVelocity = 20f;
    public float MaxRotationSpeed = 5f;
    public ParticleSystem leftThruster;
    public ParticleSystem middleThruster;
    public ParticleSystem rightThruster;

    private Rigidbody rocket;
    private bool GoingDown = false;
    private float LastYValue;
    bool SpaceDown = false;
    bool LeftArrowDown = false;
    bool RightArrowDown = false;

    void Start()
    {
        //Setup
        rocket = GetComponent<Rigidbody>();
        rocket.maxAngularVelocity = MaxRotationSpeed;
        LastYValue = transform.position.y;

        leftThruster.Stop();
        middleThruster.Stop();
        rightThruster.Stop();
    }

    void Update()
    {
        //Input logic
        SpaceDown = Input.GetKey(KeyCode.Space);
        LeftArrowDown = Input.GetKey(KeyCode.LeftArrow);
        RightArrowDown = Input.GetKey(KeyCode.RightArrow);


        //check if going down
        if (transform.position.y < LastYValue)
        {
            GoingDown = true;
            LastYValue = transform.position.y;
        }
        else if (transform.position.y > LastYValue)
        {
            GoingDown = false;
            LastYValue = transform.position.y;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {       
            leftThruster.Play();
            middleThruster.Play();
            rightThruster.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            leftThruster.Stop();
            middleThruster.Stop();
            rightThruster.Stop();
        }
    }

    void FixedUpdate()
    {
        //Physics
        if (GameManager.state == GameManager.GameState.Playing)
        {
            if (LeftArrowDown)
            {
                rocket.AddTorque(transform.right * RotationForce);
                LeftArrowDown = false;
            }
            if (RightArrowDown)
            {
                rocket.AddTorque(transform.right * -RotationForce);
                RightArrowDown = false;
            }
            if (SpaceDown && rocket.velocity.magnitude < MaxVelocity || SpaceDown && GoingDown == true)
            {
                rocket.AddForce(transform.up * thrustMultiplier);
                SpaceDown = false;
            }
        }
        else
        {
            rocket.velocity = new Vector3(0, 0, 0);
        }
    }
}
