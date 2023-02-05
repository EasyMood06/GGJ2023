using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceLines : MonoBehaviour
{
    [SerializeField] GameObject spaceLine;
    Vector3 lastShipPosition;
    // Start is called before the first frame update
    void Start()
    {
        lastShipPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendNewFindSpaceShipPosition(Vector3 newShipPosition)
    {
        DrawSpaceLine(lastShipPosition, newShipPosition);
        lastShipPosition = newShipPosition;
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
