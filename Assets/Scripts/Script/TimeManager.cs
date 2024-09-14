using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimeText;
    [SerializeField] int minute;
    [SerializeField] int second;
    [SerializeField] GameObject GameOverPanel;

    // 現在時間
    float elapsedTime;

    // カウント開始のフラッグ
    [System.NonSerialized] public bool counter_flag = false;

    // Start is called before the first frame update
    void Start()
    {
        // 分を秒に変換
        minute = minute * 60;

        elapsedTime = minute + second;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter_flag)
        {
            elapsedTime -= Time.deltaTime;
        }

        // 0秒以下（タイムアップ）になったら
        if(elapsedTime < 0)
        {
            ChangeGameOver();
        }
        else
        {
            // 残り時間をTextで表示
            TimeText.text = ((int)elapsedTime / 60).ToString() + ":" + ((int)elapsedTime % 60).ToString();
        }
    }

    public void TimeStart()
    {
        counter_flag = true;
    }

    public void ChangeGameOver()
    {
        GameOverPanel.SetActive(true);
        counter_flag = false;
        TimeText.text = "";
    }
}
