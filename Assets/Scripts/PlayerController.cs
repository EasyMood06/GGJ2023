using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float maxDistance = 10;
    float currentDistance = 0;
    float hookFlyingSpeed = 3.0f;
    Vector3 targetPosition;
    Vector3 targetUnitDirection;
    Vector3 drawPosition;
    PlayerLine playerLine;
    bool isShooted;     // true - hook is not in player's hand
    bool isOnTarget;
    bool isReachMaxDistance;
    SpaceRock[] rocks;
    SpaceRock targetRock;
    SpringJoint2D springJoint2D;
    // Start is called before the first frame update
    void Start()
    {
        playerLine = FindObjectOfType<PlayerLine>();
        rocks = FindObjectsOfType<SpaceRock>();
        springJoint2D = GetComponent<SpringJoint2D>();
        isShooted = false;
        isOnTarget = false;
        isReachMaxDistance = false;
        drawPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isShooted)   // shoot in a direction until reach max distance or get collision with rock
        {
            if(!isOnTarget && !isReachMaxDistance)
            {
                Vector3 oldDrawPosition = drawPosition;
                drawPosition += targetUnitDirection * hookFlyingSpeed * Time.deltaTime;
                // check if reach max distance
                float dist = Vector3.Distance(drawPosition, transform.position);
                if(dist > maxDistance)
                {
                    drawPosition = oldDrawPosition;
                    isReachMaxDistance = true;
                }
                CheckCollisionWithRocks();
                springJoint2D.connectedBody = null;
            }
            if(isOnTarget)
            {
                drawPosition = targetRock.transform.position;
                springJoint2D.connectedBody = targetRock.GetComponent<Rigidbody2D>();
            }
        }
        if(!isShooted && Input.GetMouseButton(0))
        {
            // record target position
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector3(worldPosition.x, worldPosition.y, 0);
            targetUnitDirection = Vector3.Normalize(targetPosition - transform.position);
            isShooted = true;
        }

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
            if(dist <= currentRockRadius)
            {
                isOnTarget = true;
                targetRock = currentRock;
                return;
            }
        }
    }
}
