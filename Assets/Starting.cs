using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting : MonoBehaviour
{
    [SerializeField] GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera.transform.position = new Vector3(2.5F, 2.584F, 48.423F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
