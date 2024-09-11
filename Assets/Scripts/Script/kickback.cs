using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kickback : MonoBehaviour
{
    [SerializeField] Vector3 power;
    Rigidbody rb;
    [SerializeField] GameObject GameOverPanel;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            rb.AddForce(new Vector3(power.x, power.y, 0), ForceMode.Impulse);
            GameOverPanel.SetActive(true);
        }
    }
}
