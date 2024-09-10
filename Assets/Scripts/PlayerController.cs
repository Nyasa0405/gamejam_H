using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Height;
    [SerializeField] float Speed;

    Vector3 Player;
    Vector3 Velocity_player;
    private Rigidbody R_player;
    public bool Flag_Controller;
    private bool Is_Ground;
    // Start is called before the first frame update
    void Start()
    {
        R_player = GetComponent<Rigidbody>();
        Flag_Controller = true;
        Is_Ground = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(Flag_Controller) 
       {
           Player_Move();
       }
       R_player.velocity = new Vector3(Velocity_player.x , R_player.velocity.y , Velocity_player.z);
    }

    void Player_Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Player = new Vector3(x, 0, z);
        Player.Normalize();
        Velocity_player = Player * Speed;

        if (Input.GetButtonDown("Jump"))
        {
            Player_Jump();
        }
    }

    void Player_Jump()
    {
        if (Is_Ground)
        {
            R_player.AddForce(transform.up * Height, ForceMode.Impulse);
            Is_Ground = false;
        }
        else return;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Is_Ground = true;
        }
    }
}
