using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Height;
    [SerializeField] float Speed;
    [SerializeField] float Stop_Time;

    Vector3 Player;
    Vector3 Velocity_player;
    public Rigidbody player;
    public GameObject Hukidashi; 
    public static bool Flag_Controller;
    private bool Is_Ground;

    // Animator
    private Animator anim = null;

    //Audio
    public AudioClip sound1;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        Flag_Controller = true;
        Is_Ground = false;
        Hukidashi.SetActive(false);

        //Animatorコンポーネント追加
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if (PlayerHitting.Is_Hit)
       {
            Player_Stan();
       } 

       if(Flag_Controller) 
       {
           Player_Move();
       }
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
        player.velocity = new Vector3(Velocity_player.x, player.velocity.y, Velocity_player.z);

        // アニメーション再生（run）
        anim.SetBool("run", true);
    }

    void Player_Jump()
    {
        if (Is_Ground)
        {
            player.AddForce(transform.up * Height, ForceMode.Impulse);
            //Debug.Log("jump");
            Is_Ground = false;

            // アニメーション再生（jump）
            anim.SetBool("jump", true);
        }
        else return;
    }

    void Player_Stan()
    {
        player.velocity = Vector3.zero;
        player.angularVelocity = Vector3.zero;
        Flag_Controller = false;
        Hukidashi.SetActive(true);
        //Debug.Log("Stop");
        Invoke("Player_Repair", Stop_Time);

        // アニメーション再生（damege）
        anim.SetBool("damage", true);

        // サウンド再生
        audioSource.PlayOneShot(sound1);
    }

    void Player_Repair()
    {
        Flag_Controller = true;
        Hukidashi.SetActive(false);
        //Debug.Log("Move");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Is_Ground = true;
        }

    }
}
