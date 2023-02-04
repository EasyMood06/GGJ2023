using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxDistance = 10;
    float currentDistance = 0;
    public float hookFlyingSpeed = 8.0f;    // hook's speed of shooting
    public float hookReturningSpeed = 8.0f; // hook's speed of returning back to the player
    public float hookShrinkingSpeed = 8.0f; // hook's speed of shrinking when hooked to a target
    public float dampingRatioIncreasingSpeed = 0.5f;    // hook's damping ratio increasing ratio
    public float maximumDampingRatio = 0.5f;    // hook's max damping ratio
    public float maximumVelocity = 10f;
    public bool launchable = true;
    public float launchVelocity = 3f;
    public bool isInSpaceship = false;
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
        if (!isInSpaceship)
        {
            if (!launchable)
            {
                ShootLogicUpdate();
            }
            else
            {
                Launch();
            }
            playerLine.DrawLine(drawPosition);
            SpeedMapping();
        }
    }
    void SpeedMapping()
    {
        Rigidbody2D thisRigidbody = gameObject.GetComponent<Rigidbody2D>();
        float nowVelocity = thisRigidbody.velocity.magnitude;
        if (nowVelocity > maximumVelocity)
        {
            Vector2 newVelocity = new Vector2(thisRigidbody.velocity.x / nowVelocity * maximumVelocity, thisRigidbody.velocity.y / nowVelocity * maximumVelocity);
            thisRigidbody.velocity = newVelocity;
        }
    }
    void DampingRatioReturn()
    {
        if (springJoint2D.dampingRatio < maximumDampingRatio)
        {
            springJoint2D.dampingRatio += Time.deltaTime * dampingRatioIncreasingSpeed;
        }
        else
        {
            springJoint2D.dampingRatio = maximumDampingRatio;
        }
    }
    void Launch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Launching once");
            // record target position
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector3(worldPosition.x, worldPosition.y, 0);
            targetUnitDirection = Vector3.Normalize(targetPosition - transform.position);
            gameObject.GetComponent<Rigidbody2D>().velocity = targetUnitDirection * launchVelocity;
            launchable = false;
        }
        return;
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
                springJoint2D.dampingRatio = 0f;
                springJoint2D.connectedBody = targetRock.GetComponent<Rigidbody2D>();
                springJoint2D.distance = Vector3.Distance(transform.position, drawPosition) + currentRock.transform.localScale.x * currentRock.GetComponent<CircleCollider2D>().radius*.5f;
                return;
            }
        }
    }

    void ShootLogicUpdate()
    {
        if(isHookBacking)   // hook is backing to player
        {
            Vector3 backUnitVector = Vector3.Normalize(transform.position - drawPosition);
            drawPosition += backUnitVector * hookReturningSpeed * Time.deltaTime;
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
            if(Input.GetMouseButtonDown(0))
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
                DampingRatioReturn();
                if(Input.GetMouseButtonUp(1))                 // loose the hook
                {
                    LooseConnection();
                }else if(Input.GetMouseButton(0))       // drag player to the target
                {
                    springJoint2D.distance -= Time.deltaTime * hookShrinkingSpeed;
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
