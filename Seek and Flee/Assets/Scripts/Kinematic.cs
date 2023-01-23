//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
    Vector3 velocity;
    float rotation;

    private KinematicSeek mySteering;
    public Transform myTarget;
    public float myMaxSpeed = 5f;
    public float targetDist = 50;

    public void Start()
    {
        mySteering = new KinematicSeek();
        mySteering.target = myTarget;
        mySteering.character = this.transform;
        mySteering.maxSpeed = myMaxSpeed;
    }

    private void KinematicUpdate(KinematicSeekOutput steering, float time)
    {
        velocity += steering.velocity * time;
        transform.position += velocity * time;
    }

    private void Update()
    {
        float dist = Vector3.Distance(mySteering.character.position, mySteering.target.position);

        //if(dist <= targetDist)
        //{
            KinematicSeekOutput steering = mySteering.getSteering();
            KinematicUpdate(steering, Time.deltaTime);
        //}
    }
}