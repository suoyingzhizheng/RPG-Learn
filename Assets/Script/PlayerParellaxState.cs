using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParellaxState : MonoBehaviour
{
    [SerializeField] private float parallaxEffect;
    private GameObject cam;
    private float xPosition;
    private float length;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        xPosition = transform.position.x;
        

    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = cam.transform.position.x * (1- parallaxEffect);
        float distanceToMove = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);
        if(distanceMoved > length+xPosition)
        {
            xPosition = xPosition + length;

        }
        else if(distanceMoved < xPosition - length) 
        {
            xPosition = xPosition-length;
        }
    }

}
