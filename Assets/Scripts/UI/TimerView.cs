using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;

        public void SetTimerText(int limitTime, int nowTime)
        {
            timerText.text = "Last : " + (limitTime - nowTime);
        }
    }
}