using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceLines : MonoBehaviour
{
    SmallSpaceship[] smallSpaceships;
    [SerializeField] GameObject spaceLine;
    // Start is called before the first frame update
    void Start()
    {
        smallSpaceships = FindObjectsOfType<SmallSpaceship>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawSpaceLine(Vector3 startPosition, Vector3 endPosition)
    {
        GameObject newLine = Instantiate(spaceLine, new Vector3(0,0,0), Quaternion.identity);
    }
}
