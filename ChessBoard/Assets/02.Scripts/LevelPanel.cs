using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelPanel : MonoBehaviour
{
    public float maxPos;
    public float minPos;
    public Button next;
    public Button previous;

    /// <summary>
    /// 下一关按钮点击
    /// </summary>
    public void Next()
    {
        if (GameManager.Instance.parent.transform.localPosition.x > minPos)
        {
            //播放按钮音效
            AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, GameManager.Instance.transform.position);

            StartCoroutine(ButtonaIsactive());

            GameManager.Instance.parent.transform.DOMoveX(GameManager.Instance.parent.transform.position.x - 810, 1f);  
        }
        else
        {
            //播放错误音效
            AudioSource.PlayClipAtPoint(GameManager.Instance.error, GameManager.Instance.transform.position);
        }
        StartCoroutine(ButtonaActive());
    }
    /// <summary>
    /// 上一关按钮点击
    /// </summary>
    public void Previous()
    {
        if (GameManager.Instance.parent.transform.localPosition.x < maxPos)
        {
            //播放按钮音效
            AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, GameManager.Instance.transform.position);

            StartCoroutine(ButtonaIsactive());

            GameManager.Instance.parent.transform.DOMoveX(GameManager.Instance.parent.transform.position.x + 810, 1f);            
        }
        else
        {
            //播放错误音效
            AudioSource.PlayClipAtPoint(GameManager.Instance.error, GameManager.Instance.transform.position);
        }
        StartCoroutine(ButtonaActive());
    }
    IEnumerator ButtonaIsactive()
    {
        yield return new WaitForSeconds(0.05f);
        next.enabled = false;
        previous.enabled = false;
    }
    IEnumerator ButtonaActive()
    {
        yield return new WaitForSeconds(0.95f);
        next.enabled = true;
        previous.enabled = true;
    }

    /// <summary>
    /// 第一关按钮点击
    /// </summary>
    public void Level1()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, GameManager.Instance.transform.position);

        LevelAnimotion();

        //倒计时时间
        if (GameManager.Instance.isTimeMode == true)
        {
            GameManager.Instance.limitedTime = 15f;
            GameManager.Instance.timeText.text = "剩余时间:00:00:15";
        }

        //出现棋盘1
        GameManager.Instance.chessBoard1.SetActive(true);

        //获取棋盘格数组
        GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard1.GetComponentsInChildren<Image>();
        ChessAddList();

        StartCoroutine(TimeText());
    }
    /// <summary>
    /// 第二关按钮点击
    /// </summary>
    public void Level2()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, GameManager.Instance.transform.position);

        LevelAnimotion();

        //倒计时时间
        if (GameManager.Instance.isTimeMode == true)
        {
            GameManager.Instance.limitedTime = 20f;
            GameManager.Instance.timeText.text = "剩余时间:00:00:20";
        }

        //出现棋盘2
        GameManager.Instance.chessBoard2.SetActive(true);

        //获取棋盘格数组
        GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard2.GetComponentsInChildren<Image>();
        ChessAddList();

        StartCoroutine(TimeText());
    }
    /// <summary>
    /// 第三关按钮点击
    /// </summary>
    public void Level3()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, GameManager.Instance.transform.position);

        LevelAnimotion();

        //倒计时时间
        if (GameManager.Instance.isTimeMode == true)
        {
            GameManager.Instance.limitedTime = 30f;
            GameManager.Instance.timeText.text = "剩余时间:00:00:30";
        }

        //出现棋盘3
        GameManager.Instance.chessBoard3.SetActive(true);

        //获取棋盘格数组
        GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard3.GetComponentsInChildren<Image>();
        ChessAddList();

        StartCoroutine(TimeText());
    }
    /// <summary>
    /// 第四关按钮点击
    /// </summary>
    public void Level4()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, GameManager.Instance.transform.position);

        LevelAnimotion();

        //倒计时时间
        if (GameManager.Instance.isTimeMode == true)
        {
            GameManager.Instance.limitedTime = 20f;
            GameManager.Instance.timeText.text = "剩余时间:00:00:20";
        }

        //出现棋盘4
        GameManager.Instance.chessBoard4.SetActive(true);

        //获取棋盘格数组
        GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard4.GetComponentsInChildren<Image>();
        ChessAddList();

        StartCoroutine(TimeText());
    }
    /// <summary>
    /// 第五关按钮点击
    /// </summary>
    public void Level5()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, GameManager.Instance.transform.position);

        LevelAnimotion();

        //倒计时时间
        if (GameManager.Instance.isTimeMode == true)
        {
            GameManager.Instance.limitedTime = 30f;
            GameManager.Instance.timeText.text = "剩余时间:00:00:30";
        }

        //出现棋盘5
        GameManager.Instance.chessBoard5.SetActive(true);

        //获取棋盘格数组
        GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard5.GetComponentsInChildren<Image>();
        ChessAddList();

        StartCoroutine(TimeText());
    }
    /// <summary>
    /// 第六关按钮点击
    /// </summary>
    public void Level6()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, GameManager.Instance.transform.position);

        LevelAnimotion();

        //倒计时时间
        if (GameManager.Instance.isTimeMode == true)
        {
            GameManager.Instance.limitedTime = 40f;
            GameManager.Instance.timeText.text = "剩余时间:00:00:40";
        }

        //出现棋盘6
        GameManager.Instance.chessBoard6.SetActive(true);

        //获取棋盘格数组
        GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard6.GetComponentsInChildren<Image>();
        ChessAddList();

        StartCoroutine(TimeText());
    }
    /// <summary>
    /// 时间延迟计时（动画播放完）
    /// </summary>
    /// <returns></returns>
    IEnumerator TimeText()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.isTime = true;
        if (GameManager.Instance.isTimeMode == true)
        { 
            TimePanel.Instance.Limited();
        }
    }

    /// <summary>
    /// 面板切换动画
    /// </summary>
    private void LevelAnimotion()
    {
        GameManager.Instance.gameUnderAnim.SetBool("underAppear", true);
        GameManager.Instance.levelAnim.SetBool("underAppear", false);

        GameManager.Instance.gameOnAnim.SetBool("isAppear", true);
        GameManager.Instance.settingAnim.SetBool("isAppear", false);
        GameManager.Instance.titleAnim.SetBool("isAppear", false);
    }

    /// <summary>
    /// 添加棋盘格到Black数组
    /// </summary>
    private void ChessAddList()
    {
        for (int i = 0; i < GameManager.Instance.chessBoardList.Length; i++)
        {
            GameManager.Instance.chessBoardList[i].GetComponent<Collider2D>().isTrigger = false;
            //添加黑色棋盘格到数组
            if (GameManager.Instance.chessBoardList[i].tag == "Black0")
            {
                GameManager.Instance.chessBlack.Add(GameManager.Instance.chessBoardList[i]);
            }
        }
    }
}
