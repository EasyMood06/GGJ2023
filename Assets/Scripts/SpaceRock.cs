using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRock : MonoBehaviour
{
    int massCoefficient = 50;
    int forceCoefficient = 50;
    Vector2 unitDirection;
    float force;
    int randRorce;
    float randSize;
    int randDirection;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        RandomGeneration();
        RockInitialization();
    }

    void RandomGeneration()
    {
        randRorce = Random.Range(1, 5);
        randSize = Random.Range(0.3f, 3.0f);
        randDirection = Random.Range(0, 360);
        print(randDirection + " " + randRorce + " " + randSize);
    }

    void RockInitialization()
    {
        // size Transform.scale = random_size
        transform.localScale = new Vector3(randSize, randSize, randSize);
        // weight Rigidbody2D.Mass = rand_size * mass_coefficient
        rb2D.mass = randSize * massCoefficient;
        // force = mass * random_force * force_coefficient;
        force = rb2D.mass * randRorce * forceCoefficient;
        // direction = new Vector2(cos(rand_direction), sin(rand_direction))
        unitDirection = new Vector2(Mathf.Cos(randDirection), Mathf.Sin(randDirection));
        // add force to rigidbody
        rb2D.AddForce(force * unitDirection);
    }
}
