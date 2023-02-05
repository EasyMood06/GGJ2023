using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraFollowing : MonoBehaviour
{
    public float zoomCoefficient = 2.0f;
    PlayerController player;
    Rigidbody2D playerRb2D;
    Camera mainCamera;
    bool isGameEnded;
    float finalCameraOrthoSize = 100.0f;
    public GameObject startObject;
    public GameObject endObject;
    public GameObject titleText;
    public GameObject healthUI;
    public GameObject holdItemUI;
    public GameObject musicBox;
    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        player = FindObjectOfType<PlayerController>();
        playerRb2D = player.GetComponent<Rigidbody2D>();
        mainCamera = GetComponent<Camera>();
        isGameEnded = false;
        // EndGame();
    }

    // Update is called once per frame
    void Update()
    {
        // when game end
        if(isGameEnded)
        {
            musicBox.SetActive(true);
            float estimatedTime = (finalCameraOrthoSize - 10) / zoomCoefficient;
            Vector3 startPosition = new Vector3(startObject.transform.position.x, startObject.transform.position.y, transform.position.z);
            UpdateFinalCameraPosition(startPosition, estimatedTime);
            return;
        }
        // follow player
        transform.position = player.transform.position - new Vector3(0, 0, 10);
        // camera zoom in zoom out
        Vector2 playerVelocity = playerRb2D.velocity;
        float playerMovingSpeed = Mathf.Sqrt(playerVelocity.x * playerVelocity.x + playerVelocity.y * playerVelocity.y);
        float targetOrthographicSize = 10 + playerMovingSpeed/2;
        if(targetOrthographicSize >= 15)
        {
            targetOrthographicSize = 15;
        }
        if(mainCamera.orthographicSize > targetOrthographicSize)
        {
            mainCamera.orthographicSize -= Time.deltaTime * zoomCoefficient;
            if(mainCamera.orthographicSize <= targetOrthographicSize)
            {
                mainCamera.orthographicSize = targetOrthographicSize;
            }
        }else if(mainCamera.orthographicSize < targetOrthographicSize)
        {
            mainCamera.orthographicSize += Time.deltaTime * zoomCoefficient;
            if(mainCamera.orthographicSize >= targetOrthographicSize)
            {
                mainCamera.orthographicSize = targetOrthographicSize;
            }
        }
    }

    void UpdateFinalCameraPosition(Vector3 startPosition, float estimatedTime)
    {
        timer += Time.deltaTime;
        // zoom out
        if(mainCamera.orthographicSize <= finalCameraOrthoSize)
        {
            mainCamera.orthographicSize += Time.deltaTime * zoomCoefficient;
        }
        // move camera position into center
        Vector3 endPosition = new Vector3((startObject.transform.position.x+endObject.transform.position.x)/2, 
                                                    (startObject.transform.position.y+endObject.transform.position.y)/2,
                                                    transform.position.z
        );
        float t = timer / estimatedTime;
        if(t >= 1) { t=1;}
        transform.position = Vector3.Lerp(startPosition, endPosition, t);
        // show the title
        titleText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(151/255,1,1,t);
    }

    public void EndGame()
    {
        healthUI.SetActive(false);
        holdItemUI.SetActive(false);
        player.isControlable = false;
        isGameEnded = true;
    }
}
