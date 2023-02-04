using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    PlayerController player;
    Rigidbody2D playerRb2D;
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerRb2D = player.GetComponent<Rigidbody2D>();
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position - new Vector3(0, 0, 10);

        // camera zoom in zoom out
        Vector2 playerVelocity = playerRb2D.velocity;
        float playerMovingSpeed = Mathf.Sqrt(playerVelocity.x*playerVelocity.x + playerVelocity.y*playerVelocity.y);
        float targetOrthographicSize = 10 + playerMovingSpeed/2;
        if(targetOrthographicSize >= 15)
        {
            targetOrthographicSize = 15;
        }
        if(mainCamera.orthographicSize > targetOrthographicSize)
        {
            mainCamera.orthographicSize -= Time.deltaTime;
            if(mainCamera.orthographicSize <= targetOrthographicSize)
            {
                mainCamera.orthographicSize = targetOrthographicSize;
            }
        }else if(mainCamera.orthographicSize < targetOrthographicSize)
        {
            mainCamera.orthographicSize += Time.deltaTime;
            if(mainCamera.orthographicSize >= targetOrthographicSize)
            {
                mainCamera.orthographicSize = targetOrthographicSize;
            }
        }
    }
}
