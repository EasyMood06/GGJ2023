using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRock : MonoBehaviour
{
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    int massCoefficient = 10;
    int forceCoefficient = 20;
    public float distanceForInitialization = 50;
    public int maxForce = 5;
    public int minForce = 1;
    public float maxSize = 2f;
    public float minSize = 0.8f;
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
        InitializeSprite();
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
            float distInitialToPlayer = Vector3.Distance(player.transform.position, initialPosition);
            float distCurrentToPlayer = Vector3.Distance(player.transform.position, transform.position);
            if(distInitialToPlayer >= distanceForInitialization && distCurrentToPlayer >= distanceForInitialization)
            {
                transform.position = initialPosition;
            }
        }
    }

    void RandomGeneration()
    {
        randRorce = Random.Range(minForce, maxForce);
        randSize = Random.Range(minSize, maxSize);
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

    public virtual void InitializeSprite()
    {
        spriteArray = Resources.LoadAll<Sprite>("Stones");
        spriteRenderer = GetComponent<SpriteRenderer>();
        int rand_index = (int)Random.Range(0,5);
        spriteRenderer.sprite = spriteArray[rand_index];
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
