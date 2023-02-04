using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float maxDistance = 10;
    float currentDistance = 0;
    float hookFlyingSpeed = 8.0f;
    Vector3 targetPosition;
    Vector3 targetUnitDirection;
    Vector3 drawPosition;
    PlayerLine playerLine;
    bool isShooted;     // true - hook is not in player's hand
    bool isOnTarget;
    bool isHookBacking;
    SpaceRock[] rocks;
    SpaceRock targetRock;
    SpringJoint2D springJoint2D;
    // Start is called before the first frame update
    void Start()
    {
        playerLine = FindObjectOfType<PlayerLine>();
        rocks = FindObjectsOfType<SpaceRock>();
        springJoint2D = GetComponent<SpringJoint2D>();
        springJoint2D.connectedBody = GetComponent<Rigidbody2D>();
        isShooted = false;
        isOnTarget = false;
        isHookBacking = false;
        drawPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ShootLogicUpdate();
        playerLine.DrawLine(drawPosition);
    }

    //check if drawPosition is in range a rock
    void CheckCollisionWithRocks()
    {
        for(int i=0; i<rocks.Length; i++)
        {
            SpaceRock currentRock = rocks[i];
            // check collision
            float dist = Vector3.Distance(drawPosition, currentRock.transform.position);
            // rock radius = rock scale * Radius
            float currentRockRadius = currentRock.transform.localScale.x * currentRock.GetComponent<CircleCollider2D>().radius;
            if(dist <= currentRockRadius)       // connect with the rock
            {
                isOnTarget = true;
                targetRock = currentRock;
                springJoint2D.connectedBody = targetRock.GetComponent<Rigidbody2D>();
                springJoint2D.distance = Vector3.Distance(transform.position, drawPosition);
                return;
            }
        }
    }

    void ShootLogicUpdate()
    {
        if(isHookBacking)   // hook is backing to player
        {
            Vector3 backUnitVector = Vector3.Normalize(transform.position - drawPosition);
            drawPosition += backUnitVector * hookFlyingSpeed * Time.deltaTime;
            float dist = Vector3.Distance(drawPosition, transform.position);
            if(dist <= 1)       // the distance when player can get hook back
            {
                drawPosition = transform.position;
                isShooted = false;
                isOnTarget = false;
                isHookBacking = false;
            }
            return;
        }
        if(!isShooted)
        {
            drawPosition = transform.position;
            if(Input.GetMouseButtonUp(0))
            {
                print("Shooting once");
                // record target position
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition = new Vector3(worldPosition.x, worldPosition.y, 0);
                targetUnitDirection = Vector3.Normalize(targetPosition - transform.position);
                isShooted = true;
            }
            return;
        }
        if(isShooted)   // shoot in a direction until reach max distance or get collision with rock
        {
            if(!isOnTarget)  // shoot hook to direction until max distance or on target
            {
                Vector3 oldDrawPosition = drawPosition;
                drawPosition += targetUnitDirection * hookFlyingSpeed * Time.deltaTime;
                // check if reach max distance
                float dist = Vector3.Distance(drawPosition, transform.position);
                if(dist > maxDistance)      // when hook reaching max distance
                {
                    drawPosition = oldDrawPosition;
                    isHookBacking = true;
                    return;
                }
                // check if on target
                CheckCollisionWithRocks();
            }
            if(isOnTarget)      // hook is on target, player can call back hook
            {
                drawPosition = targetRock.transform.position;
                if(Input.GetMouseButtonUp(1))                 // loose the hook
                {
                    LooseConnection();
                }else if(Input.GetMouseButton(0))       // drag player to the target
                {
                    springJoint2D.distance -= Time.deltaTime * hookFlyingSpeed / 2;
                    if(springJoint2D.distance <= 1)         // loose the hook
                    {
                        LooseConnection();
                    }
                }
            }
        }
    }

    void LooseConnection()
    {
        isHookBacking = true;
        springJoint2D.connectedBody = GetComponent<Rigidbody2D>();
        isOnTarget = false;
    }
}
