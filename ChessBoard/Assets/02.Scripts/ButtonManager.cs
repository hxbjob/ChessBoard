using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //主面板*************************************************************************************************************************
    /// <summary>
    /// 标准模式按钮点击
    /// </summary>
    public void NormalMode()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);

        GameManager.Instance.parent.transform.position = new Vector3(560, GameManager.Instance.parent.transform.position.y, GameManager.Instance.parent.transform.position.z);

        GameManager.Instance.level1.gameObject.SetActive(true);
        GameManager.Instance.level2.gameObject.SetActive(true);
        GameManager.Instance.level3.gameObject.SetActive(true);
        GameManager.Instance.level4.gameObject.SetActive(true);
        GameManager.Instance.level5.gameObject.SetActive(true);
        GameManager.Instance.level6.gameObject.SetActive(true);

        GameManager.Instance.levelAnim.SetBool("underAppear", true);
        GameManager.Instance.mainAnim.SetBool("underAppear", false);

        GameManager.Instance.settingBt.gameObject.SetActive(false);
        GameManager.Instance.returnBt.gameObject.SetActive(true);
    }
    /// <summary>
    /// 限时模式按钮点击
    /// </summary>
    public void TimeMode()
    {
        //播放错误音效
        //AudioSource.PlayClipAtPoint(GameManager.Instance.error, transform.position);

        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);

        GameManager.Instance.parent.transform.position = new Vector3(560, GameManager.Instance.parent.transform.position.y, GameManager.Instance.parent.transform.position.z);

        GameManager.Instance.timeLevel1.gameObject.SetActive(true);
        GameManager.Instance.timeLevel2.gameObject.SetActive(true);
        GameManager.Instance.timeLevel3.gameObject.SetActive(true);
        GameManager.Instance.timeLevel4.gameObject.SetActive(true);
        GameManager.Instance.timeLevel5.gameObject.SetActive(true);
        GameManager.Instance.timeLevel6.gameObject.SetActive(true);

        GameManager.Instance.isTimeMode = true;
        GameManager.Instance.resetBt.gameObject.SetActive(false);
        GameManager.Instance.pauseBt.gameObject.SetActive(false);

        GameManager.Instance.levelAnim.SetBool("underAppear", true);
        GameManager.Instance.mainAnim.SetBool("underAppear", false);

        GameManager.Instance.settingBt.gameObject.SetActive(false);
        GameManager.Instance.returnBt.gameObject.SetActive(true);
    }
    /// <summary>
    /// 更多模式按钮点击
    /// </summary>
    public void MoreMode()
    {
        //播放错误音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.error, transform.position);
    }

    //标题栏*************************************************************************************************************************
    /// <summary>
    /// 标题栏设置按钮点击
    /// </summary>
    public void Setting()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);

        GameManager.Instance.settingAnim.SetBool("isAppear", true);
        GameManager.Instance.titleAnim.SetBool("isAppear", false);
    }
    /// <summary>
    /// 标题栏返回按钮点击
    /// </summary>
    public void TitleReturn()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);

        GameManager.Instance.level1.gameObject.SetActive(false);
        GameManager.Instance.level2.gameObject.SetActive(false);
        GameManager.Instance.level3.gameObject.SetActive(false);
        GameManager.Instance.level4.gameObject.SetActive(false);
        GameManager.Instance.level5.gameObject.SetActive(false);
        GameManager.Instance.level6.gameObject.SetActive(false);
        GameManager.Instance.timeLevel1.gameObject.SetActive(false);
        GameManager.Instance.timeLevel2.gameObject.SetActive(false);
        GameManager.Instance.timeLevel3.gameObject.SetActive(false);
        GameManager.Instance.timeLevel4.gameObject.SetActive(false);
        GameManager.Instance.timeLevel5.gameObject.SetActive(false);
        GameManager.Instance.timeLevel6.gameObject.SetActive(false);

        if (GameManager.Instance.isTimeMode == true)
        {
            GameManager.Instance.isTimeMode = false;
            GameManager.Instance.resetBt.gameObject.SetActive(true);
            GameManager.Instance.pauseBt.gameObject.SetActive(true);
        }

        GameManager.Instance.timeText.text = null;

        GameManager.Instance.levelAnim.SetBool("underAppear", false);
        GameManager.Instance.mainAnim.SetBool("underAppear", true);

        GameManager.Instance.settingBt.gameObject.SetActive(true);
        GameManager.Instance.returnBt.gameObject.SetActive(false);
    }

    //设置面板***********************************************************************************************************************
    /// <summary>
    /// 设置面板返回按钮点击
    /// </summary>
    public void SettingReturn()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);

        GameManager.Instance.titleAnim.SetBool("isAppear", true);
        GameManager.Instance.settingAnim.SetBool("isAppear", false);
    }
    /// <summary>
    /// 音乐打开按钮点击
    /// </summary>
    public void PlayMusic()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);
        GameManager.Instance.audioPause.gameObject.SetActive(false);
        GameManager.Instance.audioPlay.gameObject.SetActive(true);
        GameManager.Instance.bgAudio.enabled = true;
    }
    /// <summary>
    /// 音乐关闭按钮点击
    /// </summary>
    public void PauseMusic()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);
        GameManager.Instance.audioPause.gameObject.SetActive(true);
        GameManager.Instance.audioPlay.gameObject.SetActive(false);
        GameManager.Instance.bgAudio.enabled = false;
    }
    /// <summary>
    /// 退出游戏按钮点击
    /// </summary>
    public void Exiting()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);

        GameManager.Instance.endAnim.SetBool("isClick", true);

        GameManager.Instance.settingReturnBt.enabled = false;
        GameManager.Instance.musicBt.enabled = false;
        GameManager.Instance.exitBt.enabled = false;
        GameManager.Instance.normalBt.enabled = false;
        GameManager.Instance.timeBt.enabled = false;
        GameManager.Instance.moreBt.enabled = false;
    }

    //游戏面板***********************************************************************************************************************
    /// <summary>
    /// 返回按钮点击
    /// </summary>
    public void Return()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);

        //倒计时初始化
        if (GameManager.Instance.isTimeMode == true)
        {
            GameManager.Instance.pauseBt.gameObject.SetActive(false);
            //GameManager.Instance.limitedTime = 1;
            TimePanel.Instance.StopLimited();
        }
        else
        {  
            GameManager.Instance.pauseBt.gameObject.SetActive(true);
        }

        GameManager.Instance.gameUnderAnim.SetBool("underAppear", false);
        GameManager.Instance.levelAnim.SetBool("underAppear", true);
        GameManager.Instance.titleAnim.SetBool("isAppear", true);
        GameManager.Instance.gameOnAnim.SetBool("isAppear", false);

        GameManager.Instance.playBt.gameObject.SetActive(false);
        GameManager.Instance.isPause = false;

        ChessButtonTrue();

        //时间，棋盘初始化
        GameManager.Instance.isTime = false;
        
        GameManager.Instance.spendTime = 0;
        GameManager.Instance.chessBlack.Clear();
        for (int i = 0; i < GameManager.Instance.chessBoardList.Length; i++)
        {
            if (GameManager.Instance.chessBoardList[i].tag != "Black0")
            {
                GameManager.Instance.chessBoardList[i].tag = "White";
                GameManager.Instance.chessBoardList[i].sprite = GameManager.Instance.chessImageWhite;
            }
        }
        GameManager.Instance.chessBoardList = null;
        GameManager.Instance.chessBoard1.SetActive(false);
        GameManager.Instance.chessBoard2.SetActive(false);
        GameManager.Instance.chessBoard3.SetActive(false);
        GameManager.Instance.chessBoard4.SetActive(false);
        GameManager.Instance.chessBoard5.SetActive(false);
        GameManager.Instance.chessBoard6.SetActive(false);
    }
    /// <summary>
    /// 重新开始按钮点击
    /// </summary>
    public void ResetLevel()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);
        GameManager.Instance.timePanel.SetBool("isReset", true);
        GameManager.Instance.pauseBt.gameObject.SetActive(true);
        GameManager.Instance.playBt.gameObject.SetActive(false);
        GameManager.Instance.isPause = false;
        GameManager.Instance.isTime = false;
        
        StartCoroutine(TimeReset());
        StartCoroutine(TimeStart());
    }
    /// <summary>
    /// 时间棋盘重置
    /// </summary>
    /// <returns></returns>
    IEnumerator TimeReset()
    {
        yield return new WaitForSeconds(0.5f);

        GameManager.Instance.timeText.text = null;
        GameManager.Instance.spendTime = 0;

        GameManager.Instance.chessBlack.Clear();
        for (int i = 0; i < GameManager.Instance.chessBoardList.Length; i++)
        {
            GameManager.Instance.chessBoardList[i].GetComponent<Collider2D>().isTrigger = false;

            if (GameManager.Instance.chessBoardList[i].tag != "Black0")
            {
                GameManager.Instance.chessBoardList[i].tag = "White";
                GameManager.Instance.chessBoardList[i].sprite = GameManager.Instance.chessImageWhite;
            }
            else
            {
                GameManager.Instance.chessBlack.Add(GameManager.Instance.chessBoardList[i]);
            }
        }

        ChessButtonTrue();
    }
    /// <summary>
    /// 开始计时
    /// </summary>
    /// <returns></returns>
    IEnumerator TimeStart()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.isTime = true;
        GameManager.Instance.timePanel.SetBool("isReset", false);
    }
    /// <summary>
    /// 暂停按钮点击
    /// </summary>
    public void GamePause()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);

        if (GameManager.Instance.isPause == false)
        {
            GameManager.Instance.pauseBt.gameObject.SetActive(false);
            GameManager.Instance.playBt.gameObject.SetActive(true);
            GameManager.Instance.isTime = false;
            GameManager.Instance.isPause = true;
            GameManager.Instance.chessBt1.GetComponent<Button>().enabled = false;
            GameManager.Instance.chessBt2.GetComponent<Button>().enabled = false;
            GameManager.Instance.chessBt3.GetComponent<Button>().enabled = false;
            GameManager.Instance.chessBt4.GetComponent<Button>().enabled = false;
        }
    }
    /// <summary>
    /// 开始按钮点击
    /// </summary>
    public void GamePlay()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);

        if (GameManager.Instance.isPause == true)
        {
            GameManager.Instance.pauseBt.gameObject.SetActive(true);
            GameManager.Instance.playBt.gameObject.SetActive(false);
            GameManager.Instance.isTime = true;
            GameManager.Instance.isPause = false;

            ChessButtonTrue();
        }
    }

    /// <summary>
    /// 激活棋子按钮
    /// </summary>
    private void ChessButtonTrue()
    {
        GameManager.Instance.chessBt1.GetComponent<Button>().enabled = true;
        GameManager.Instance.chessBt2.GetComponent<Button>().enabled = true;
        GameManager.Instance.chessBt3.GetComponent<Button>().enabled = true;
        GameManager.Instance.chessBt4.GetComponent<Button>().enabled = true;
    }

    //胜利面板***********************************************************************************************************************
    /// <summary>
    /// 返回关卡界面按钮
    /// </summary>
    public void WinReturn()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);

        GameManager.Instance.levelAnim.SetBool("underAppear", true);
        GameManager.Instance.titleAnim.SetBool("isAppear", true);
        GameManager.Instance.winAnim.SetBool("winAppear", false);

        GameManager.Instance.chessBoard1.SetActive(false);
        GameManager.Instance.chessBoard2.SetActive(false);
        GameManager.Instance.chessBoard3.SetActive(false);
        GameManager.Instance.chessBoard4.SetActive(false);
        GameManager.Instance.chessBoard5.SetActive(false);
        GameManager.Instance.chessBoard6.SetActive(false);
    }
    /// <summary>
    /// 下一关按钮
    /// </summary>
    public void Next()
    {
        //出现棋盘
        if (GameManager.Instance.chessBoard1.activeSelf == true)
        {
            GameManager.Instance.chessBoard1.SetActive(false);
            GameManager.Instance.chessBoard2.SetActive(true);
            //获取棋盘格数组
            GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard2.GetComponentsInChildren<Image>();

            if (GameManager.Instance.isTimeMode == true)
            {
                GameManager.Instance.limitedTime = 20f;
                GameManager.Instance.timeText.text = "剩余时间:00:00:20";
            }

            AddBlackChess();
            NextLevelAnim(); 
        }
        else if (GameManager.Instance.chessBoard2.activeSelf == true)
        {
            GameManager.Instance.chessBoard2.SetActive(false);
            GameManager.Instance.chessBoard3.SetActive(true);
            //获取棋盘格数组
            GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard3.GetComponentsInChildren<Image>();

            if (GameManager.Instance.isTimeMode == true)
            {
                GameManager.Instance.limitedTime = 30f;
                GameManager.Instance.timeText.text = "剩余时间:00:00:30";
            }

            AddBlackChess();
            NextLevelAnim();
        }
        else if (GameManager.Instance.chessBoard3.activeSelf == true)
        {
            GameManager.Instance.chessBoard3.SetActive(false);
            GameManager.Instance.chessBoard4.SetActive(true);
            //获取棋盘格数组
            GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard4.GetComponentsInChildren<Image>();

            if (GameManager.Instance.isTimeMode == true)
            {
                GameManager.Instance.limitedTime = 20f;
                GameManager.Instance.timeText.text = "剩余时间:00:00:20";
            }

            AddBlackChess();
            NextLevelAnim();
        }
        else if (GameManager.Instance.chessBoard4.activeSelf == true)
        {
            GameManager.Instance.chessBoard4.SetActive(false);
            GameManager.Instance.chessBoard5.SetActive(true);
            //获取棋盘格数组
            GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard5.GetComponentsInChildren<Image>();

            if (GameManager.Instance.isTimeMode == true)
            {
                GameManager.Instance.limitedTime = 30f;
                GameManager.Instance.timeText.text = "剩余时间:00:00:30";
            }

            AddBlackChess();
            NextLevelAnim();
        }
        else if (GameManager.Instance.chessBoard5.activeSelf == true)
        {
            GameManager.Instance.chessBoard5.SetActive(false);
            GameManager.Instance.chessBoard6.SetActive(true);
            //获取棋盘格数组
            GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard6.GetComponentsInChildren<Image>();

            if (GameManager.Instance.isTimeMode == true)
            {
                GameManager.Instance.limitedTime = 40f;
                GameManager.Instance.timeText.text = "剩余时间:00:00:40";
            }

            AddBlackChess();
            NextLevelAnim();
        }
        else if (GameManager.Instance.chessBoard6.activeSelf == true)
        {
            //播放不得行音效
            AudioSource.PlayClipAtPoint(GameManager.Instance.error, GameManager.Instance.transform.position);
        }

        
    }
    /// <summary>
    /// 重新开始按钮
    /// </summary>
    public void WinReset()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);

        GameManager.Instance.gameUnderAnim.SetBool("underAppear", true);
        GameManager.Instance.gameOnAnim.SetBool("isAppear", true);
        GameManager.Instance.winAnim.SetBool("winAppear", false);

        //出现棋盘
        if (GameManager.Instance.chessBoard1.activeSelf == true)
        {
            //获取棋盘格数组
            GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard1.GetComponentsInChildren<Image>();

            if (GameManager.Instance.isTimeMode == true)
            {
                GameManager.Instance.limitedTime = 15f;
                GameManager.Instance.timeText.text = "剩余时间:00:00:15";
            }
        }
        else if (GameManager.Instance.chessBoard2.activeSelf == true)
        {
            //获取棋盘格数组
            GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard2.GetComponentsInChildren<Image>();

            if (GameManager.Instance.isTimeMode == true)
            {
                GameManager.Instance.limitedTime = 20f;
                GameManager.Instance.timeText.text = "剩余时间:00:00:20";
            }
        }
        else if (GameManager.Instance.chessBoard3.activeSelf == true)
        {
            //获取棋盘格数组
            GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard3.GetComponentsInChildren<Image>();

            if (GameManager.Instance.isTimeMode == true)
            {
                GameManager.Instance.limitedTime = 30f;
                GameManager.Instance.timeText.text = "剩余时间:00:00:30";
            }
        }
        else if (GameManager.Instance.chessBoard4.activeSelf == true)
        {
            //获取棋盘格数组
            GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard4.GetComponentsInChildren<Image>();

            if (GameManager.Instance.isTimeMode == true)
            {
                GameManager.Instance.limitedTime = 20f;
                GameManager.Instance.timeText.text = "剩余时间:00:00:20";
            }
        }
        else if (GameManager.Instance.chessBoard5.activeSelf == true)
        {
            //获取棋盘格数组
            GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard5.GetComponentsInChildren<Image>();

            if (GameManager.Instance.isTimeMode == true)
            {
                GameManager.Instance.limitedTime = 30f;
                GameManager.Instance.timeText.text = "剩余时间:00:00:30";
            }
        }
        else if (GameManager.Instance.chessBoard6.activeSelf == true)
        {
            //获取棋盘格数组
            GameManager.Instance.chessBoardList = GameManager.Instance.chessBoard6.GetComponentsInChildren<Image>();

            if (GameManager.Instance.isTimeMode == true)
            {
                GameManager.Instance.limitedTime = 40f;
                GameManager.Instance.timeText.text = "剩余时间:00:00:40";
            }
        }

        AddBlackChess();
        StartCoroutine(TimeText());
    }

    /// <summary>
    /// 下一关动画
    /// </summary>
    private void NextLevelAnim()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(GameManager.Instance.buttonAudio, transform.position);

        GameManager.Instance.gameUnderAnim.SetBool("underAppear", true);
        GameManager.Instance.gameOnAnim.SetBool("isAppear", true);
        GameManager.Instance.winAnim.SetBool("winAppear", false);

        StartCoroutine(TimeText());
    }

    /// <summary>
    /// 添加黑色棋盘格到数组
    /// </summary>
    private void AddBlackChess()
    {
        for (int i = 0; i < GameManager.Instance.chessBoardList.Length; i++)
        {
            GameManager.Instance.chessBoardList[i].GetComponent<Collider2D>().isTrigger = false;
            //添加黑色棋盘格到数组
            if (GameManager.Instance.chessBoardList[i].tag == "Black0")
            {
                GameManager.Instance.chessBlack.Add(GameManager.Instance.chessBoardList[i]);
                Debug.Log(GameManager.Instance.chessBlack.Count);
            }
        }
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
}
