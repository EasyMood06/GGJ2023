using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRock : MonoBehaviour
{
    int massCoefficient = 10;
    int forceCoefficient = 15;
    public float distanceForInitialization = 50;
    Vector2 unitDirection;
    float force;
    int randRorce;
    float randSize;
    int randDirection;
    Rigidbody2D rb2D;
    bool isInitialized;
    PlayerController player;
    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        RandomGeneration();
        isInitialized = false;
        player = FindObjectOfType<PlayerController>();
        initialPosition = transform.position;
    }

    void Update()
    {
        // first initialize
        if(!isInitialized)
        {
            // when distance between player and rock is less than 100, initialize
            float distToPlayer = Vector3.Distance(player.transform.position, transform.position);
            if(distToPlayer <= distanceForInitialization)
            {
                RockInitialization();
                isInitialized = true;
            }
            return;
        }
        // regeneration, when this rock is far beyond the initial position, and player is not around
        float distToInitialPosition = Vector3.Distance(transform.position, initialPosition);
        if(distToInitialPosition >= distanceForInitialization)  // need to reset position
        {
            float distToPlayer = Vector3.Distance(player.transform.position, initialPosition);
            if(distToPlayer >= distanceForInitialization)
            {
                transform.position = initialPosition;
            }
        }
    }

    void RandomGeneration()
    {
        randRorce = Random.Range(1, 5);
        randSize = Random.Range(0.8f, 2.0f);
        randDirection = Random.Range(0, 360);
    }

    public void RockInitialization()
    {
        // size Transform.scale = random_size
        transform.localScale = new Vector3(randSize, randSize, randSize);
        // weight Rigidbody2D.Mass = rand_size * mass_coefficient
        rb2D.mass = randSize * randSize * massCoefficient;
        // force = mass * random_force * force_coefficient;
        force = rb2D.mass * randRorce * forceCoefficient;
        // direction = new Vector2(cos(rand_direction), sin(rand_direction))
        unitDirection = new Vector2(Mathf.Cos(randDirection), Mathf.Sin(randDirection));
        // add force to rigidbody
        rb2D.AddForce(force * unitDirection);
    }
}
