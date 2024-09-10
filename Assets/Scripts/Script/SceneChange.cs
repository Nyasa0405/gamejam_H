using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("ChangeSceneMain", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Invoke("ChangeSceneMain", 1.5f);
        }
    }

    public void ChangeSceneMain()
    {
        SceneManager.LoadScene("Main");
    }
}
