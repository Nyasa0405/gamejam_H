using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContlloer : MonoBehaviour
{
    [SerializeField] GameObject PlayerObj;
    [SerializeField] GameObject CameraObj;

    Vector3 Player_pos;
    Vector3 Camera_pos;

    [SerializeField] float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player_pos = PlayerObj.transform.position;
        Camera_pos = CameraObj.transform.position;

        transform.position = new Vector3(0, Camera_pos.y, Player_pos.z - distance);
    }
}
