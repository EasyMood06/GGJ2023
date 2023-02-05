using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayVFX()
    {
        gameObject.SetActive(true);
    }
    public void End()
    {
        gameObject.SetActive(false);
    }
}
