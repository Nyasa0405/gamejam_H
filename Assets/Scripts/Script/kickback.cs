using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kickback : MonoBehaviour
{
    [SerializeField] Vector3 power;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(new Vector3(power.x, power.y, 0));
    }
}
