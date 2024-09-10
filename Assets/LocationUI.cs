using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationUI : MonoBehaviour
{
    [SerializeField] GameObject PlayerObj;
    [SerializeField] GameObject GoalObj;
    [SerializeField] Slider LocationSlider;

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

        //スライダーの最大値の設定
        LocationSlider.maxValue = Goal_pos.z;

        //スライダーの現在値の設定
        LocationSlider.value = Player_pos.z;
    }
}
