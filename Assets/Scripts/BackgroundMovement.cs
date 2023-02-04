using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(MainCamera.transform.position.x * (1 - movementSpeed), MainCamera.transform.position.y * (1 - movementSpeed), transform.position.z);
    }
}
