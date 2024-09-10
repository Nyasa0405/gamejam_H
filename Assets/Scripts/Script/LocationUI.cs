using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationUI : MonoBehaviour
{
    [SerializeField] GameObject PlayerObj;
    [SerializeField] GameObject GoalObj;
    [SerializeField] Slider LocationSlider;
    [SerializeField] GameObject GameClearPanel;

    Vector3 Player_pos;
    Vector3 Goal_pos;

    // Start is called before the first frame update
    void Start()
    {
        LocationSlider = GetComponent<Slider>();
        Goal_pos = GoalObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Player_pos = PlayerObj.transform.position;

        LocationSlider.maxValue = Goal_pos.z;

        LocationSlider.value = Player_pos.z;

        if(Player_pos.z > Goal_pos.z)
        {
            ChangeGameClear();
        }
    }

    public void ChangeGameClear()
    {
        GameClearPanel.SetActive(true);
    }
}
