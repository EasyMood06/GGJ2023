using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    PlayerController player;
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        lineRenderer = GetComponent<LineRenderer>();
        DrawLine(player.transform.position);
    }

    public void DrawLine(Vector3 targetPosition)
    {
        lineRenderer.SetPosition(0, player.transform.position);
        lineRenderer.SetPosition(1, targetPosition);
    }
}
