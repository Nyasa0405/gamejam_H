using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitting : MonoBehaviour
{
    public static bool Is_Hit;
    void OnCollisionEnter(Collision other)
    {
        if (!Is_Hit)
        {
            if (other.gameObject.CompareTag("Ob_Head"))
            {
                Is_Hit = true;
                //Debug.Log("Head");
                Invoke("Reset_Flag", 1.5f);
            }
            else if (other.gameObject.CompareTag("Ob_Under"))
            {
                Is_Hit = true;
                //Debug.Log("Under");
                Invoke("Reset_Flag", 1.5f);
            }
        }
    }

    void Reset_Flag()
    {
        Is_Hit = false;
    }

}
