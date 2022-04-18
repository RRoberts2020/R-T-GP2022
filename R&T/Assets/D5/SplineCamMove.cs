using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class SplineCamMove : MonoBehaviour
{

    public GameObject splineCam;
    public GameObject targetViewPlayer;

    public PathCreator pathCreator;
    public EndOfPathInstruction end; // What will happen if the end of path is reached
    public float speed; // Speed of game object
    float dstTravelled;

    void Update()
    {
        dstTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(dstTravelled, end);
        splineCam.transform.LookAt(targetViewPlayer.transform);
    }
}
