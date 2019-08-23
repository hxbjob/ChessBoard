using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePanel : MonoBehaviour
{
    public static TimePanel Instance;

    private int hour;
    private int minute;
    private int second;
    private float time;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 倒计时
    /// </summary>
    public void Limited()
    {
        StartCoroutine(LimitedTime());
    }
    /// <summary>
    /// 暂停倒计时
    /// </summary>
    public void StopLimited()
    {
        StopAllCoroutines();
    }
    IEnumerator LimitedTime()
    {
        if (GameManager.Instance.isTime == true)
        {
            while (GameManager.Instance.limitedTime > 0)
            {
                yield return new WaitForSeconds(1f);
                GameManager.Instance.limitedTime--;
                time = GameManager.Instance.limitedTime;

                hour = (int)time / 3600;
                minute = (int)(time - hour * 3600) / 60;
                second = (int)(time - hour * 3600 - minute * 60);

                GameManager.Instance.timeText.text = string.Format("剩余时间:" + "{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
            }
            yield return new WaitForSeconds(1f);
            GameManager.Instance.LoseLater();
        }
    }

    /// <summary>
    /// 计时
    /// </summary>
    private void Update()
    {
        if (GameManager.Instance.isTime == true && GameManager.Instance.isTimeMode == false)
        {
            time = GameManager.Instance.spendTime;
            time += Time.deltaTime;
            GameManager.Instance.spendTime = time;

            hour = (int)time / 3600;
            minute = (int)(time - hour * 3600) / 60;
            second = (int)(time - hour * 3600 - minute * 60);

            GameManager.Instance.timeText.text = string.Format("时间:" + "{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
        }
    }
}
