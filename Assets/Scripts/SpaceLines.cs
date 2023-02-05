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
        for(int i=0; i<smallSpaceships.Length-1; i++)
        {
            Vector3 startPosition = smallSpaceships[i].transform.position;
            Vector3 endPosition = smallSpaceships[i+1].transform.position;
            DrawSpaceLine(startPosition, endPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawSpaceLine(Vector3 startPosition, Vector3 endPosition)
    {
        GameObject newLine = Instantiate(spaceLine, new Vector3(0,0,0), Quaternion.identity);
        newLine.transform.parent = transform;
        LineRenderer lineRenderer = newLine.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
    }
}
