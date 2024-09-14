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
    bool audioFlag = true;

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
            if(audioFlag)
            {
                Player_Stan();
            }
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

        //スティック倒したらrunモーション再生
        // 絶対値設定
        float threshold = 0.1f;

        if (Mathf.Abs(x) > threshold || Mathf.Abs(z) > threshold)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }
    }

    void Player_Jump()
    {
        if (Is_Ground)
        {
            player.AddForce(transform.up * Height, ForceMode.Impulse);
            //Debug.Log("jump");
            Is_Ground = false;

            // アニメーション再生（jump）
            anim.SetBool("run", false);
            anim.SetTrigger("jump");
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
        anim.SetTrigger("damage");
        anim.SetBool("run", false);

        // サウンド再生(一度だけ再生)
        audioSource.PlayOneShot(sound1);
        audioFlag = false;
    }

    void Player_Repair()
    {
        Flag_Controller = true;
        Hukidashi.SetActive(false);
        //Debug.Log("Move");

        //audioflag
        audioFlag = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Is_Ground = true;
        }
    }
}
