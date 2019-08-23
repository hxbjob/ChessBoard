using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //是否为限时模式
    public bool isTimeMode;

    //关卡选择父物体
    public GameObject parent;

    //棋子
    public GameObject chess1;
    public GameObject chess2;
    public GameObject chess3;
    public GameObject chess4;
    //棋子按钮
    public Button chessBt1;
    public Button chessBt2;
    public Button chessBt3;
    public Button chessBt4;
    //棋子父物体
    public Transform chessParent;
    //棋子棋盘格图片
    public Sprite chessImage1;
    public Sprite chessImage2;
    public Sprite chessImage3;
    public Sprite chessImage4;
    public Sprite chessImageWhite;
    public Sprite chessImageBlack;
    //棋盘面板
    public GameObject chessUnderPanel;

    //棋盘格
    public GameObject chessBoard1;
    public GameObject chessBoard2;
    public GameObject chessBoard3;
    public GameObject chessBoard4;
    public GameObject chessBoard5;
    public GameObject chessBoard6;
    public Image[] chessBoardList;
    public List<Image> chessBlack;
    public GameObject cover;
    public GameObject cover1;
    public GameObject cover2;

    //面板动画状态机
    public Animator titleAnim;
    public Animator settingAnim;
    public Animator mainAnim;
    public Animator levelAnim;
    public Animator timeLevelAnim;
    public Animator gameOnAnim;
    public Animator gameUnderAnim; 
    public Animator winAnim;
    public Animator endAnim;

    //设置变返回按钮
    public Button settingBt;
    public Button returnBt;

    //退出按钮点击时暂停的按钮
    public Button settingReturnBt;
    public Button musicBt;
    public Button exitBt;
    public Button normalBt;
    public Button timeBt;
    public Button moreBt;

    //计时文本
    public Text timeText;
    public bool isTime;
    public float spendTime;
    public Animator timePanel;
    //倒计时限制时间
    public float limitedTime;

    //重新开始按钮
    public Button resetBt;

    //暂停播放
    public Button pauseBt;
    public Button playBt;
    public bool isPause;

    //成绩
    private bool isFirstGame;
    private Save save;
    //正常模式
    public Text level1;
    public Text level2;
    public Text level3;
    public Text level4;
    public Text level5;
    public Text level6;
    //限时模式
    public Text timeLevel1;
    public Text timeLevel2;
    public Text timeLevel3;
    public Text timeLevel4;
    public Text timeLevel5;
    public Text timeLevel6;

    //胜利面板按钮
    public Button next;
    public Button winReturn;
    public Button winReset;
    public Text win;
    public Text lose;
    public Text useTime;

    //音效
    //音效按钮
    public Button audioPlay;
    public Button audioPause;
    public AudioSource bgAudio;

    //棋子选中音效
    public AudioClip chessBtAudio1;
    public AudioClip chessBtAudio2;
    public AudioClip chessBtAudio3;
    public AudioClip chessBtAudio4;
    //棋子放置音效
    public AudioClip chessAudio1;
    public AudioClip chessAudio2;
    public AudioClip chessAudio3;
    public AudioClip chessAudio4;
    //错误音效
    public AudioClip error;
    //旋转音效
    public AudioClip chessRotate;
    //按钮音效
    public AudioClip buttonAudio;
    //胜利音效
    public AudioClip winAudio;
    //失败音效
    public AudioClip loseAudio;

    private void Awake()
    {
        Instance = this;

        isTimeMode = false;

        chessBt1.GetComponent<Button>().enabled = true;
        chessBt2.GetComponent<Button>().enabled = true;
        chessBt3.GetComponent<Button>().enabled = true;
        chessBt4.GetComponent<Button>().enabled = true;

        settingBt.gameObject.SetActive(true);
        returnBt.gameObject.SetActive(false);

        pauseBt.gameObject.SetActive(true);
        playBt.gameObject.SetActive(false);
        isPause = false;

        audioPause.gameObject.SetActive(false);
        audioPlay.gameObject.SetActive(true);
        bgAudio.enabled = true;

        chessBoard1.SetActive(false);
        chessBoard2.SetActive(false);
        chessBoard3.SetActive(false);
        chessBoard4.SetActive(false);
        chessBoard5.SetActive(false);
        chessBoard6.SetActive(false);
        cover.SetActive(false);
        cover1.SetActive(false);
        cover2.SetActive(false);

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

        isTime = false;
        spendTime = 0;
        timePanel.SetBool("isReset", false);
        limitedTime = 0;

        InitGameData();
    }

    private void Start()
    {
        //棋子按钮点击事件监听
        chessBt1.onClick.AddListener(ChessBt1);
        chessBt2.onClick.AddListener(ChessBt2);
        chessBt3.onClick.AddListener(ChessBt3);
        chessBt4.onClick.AddListener(ChessBt4);
    }

    //游戏胜利***********************************************************************************************************************
    /// <summary>
    /// 胜利判定
    /// </summary>
    private void Update()
    {
        //第一关胜利
        if (chessBlack.Count == 16 && chessBoard1.activeSelf == true)
        {
            //播放胜利音效
            AudioSource.PlayClipAtPoint(winAudio, transform.position);

            //cover.SetActive(true);
            isTime = false;
            if (isTimeMode == true)
            {
                TimePanel.Instance.StopLimited();
                timeLevel1.text= "上次" + timeText.text;
            }
            else
            {
                level1.text = "上次" + timeText.text;
            }
              
            StartCoroutine(WinLater());
        }//第二关胜利
        else if (chessBlack.Count == 25 && chessBoard2.activeSelf == true)
        {
            //播放胜利音效
            AudioSource.PlayClipAtPoint(winAudio, transform.position);

            //cover1.SetActive(true);
            isTime = false;
            if (isTimeMode == true)
            {
                TimePanel.Instance.StopLimited();
                timeLevel2.text = "上次" + timeText.text;
            }
            else
            {
                level2.text = "上次" + timeText.text;
            }
            StartCoroutine(WinLater());
        }//第三关胜利
        else if (chessBlack.Count == 36 && chessBoard3.activeSelf == true)
        {
            //播放胜利音效
            AudioSource.PlayClipAtPoint(winAudio, transform.position);

            //cover2.SetActive(true);
            isTime = false;
            if (isTimeMode == true)
            {
                TimePanel.Instance.StopLimited();
                timeLevel3.text = "上次" + timeText.text;
            }
            else
            {
                level3.text = "上次" + timeText.text;
            }
            StartCoroutine(WinLater());
        }//第四关胜利
        else if (chessBlack.Count == 16 && chessBoard4.activeSelf == true)
        {
            //播放胜利音效
            AudioSource.PlayClipAtPoint(winAudio, transform.position);

            //cover.SetActive(true);
            isTime = false;
            if (isTimeMode == true)
            {
                TimePanel.Instance.StopLimited();
                timeLevel4.text = "上次" + timeText.text;
            }
            else
            {
                level4.text = "上次" + timeText.text;
            }
            StartCoroutine(WinLater());
        }//第五关胜利
        else if (chessBlack.Count == 25 && chessBoard5.activeSelf == true)
        {
            //播放胜利音效
            AudioSource.PlayClipAtPoint(winAudio, transform.position);

            //cover1.SetActive(true);
            isTime = false;
            if (isTimeMode == true)
            {
                TimePanel.Instance.StopLimited();
                timeLevel5.text = "上次" + timeText.text;
            }
            else
            {
                level5.text = "上次" + timeText.text;
            }
            StartCoroutine(WinLater());
        }//第六关胜利
        else if (chessBlack.Count == 36 && chessBoard6.activeSelf == true)
        {
            //播放胜利音效
            AudioSource.PlayClipAtPoint(winAudio, transform.position);

            //cover2.SetActive(true);
            isTime = false;
            if (isTimeMode == true)
            {
                TimePanel.Instance.StopLimited();
                timeLevel6.text = "上次" + timeText.text;
            }
            else
            {
                level6.text = "上次" + timeText.text;
            }
            StartCoroutine(WinLater());
        }
    }
    /// <summary>
    /// 胜利面板出现
    /// </summary>
    /// <returns></returns>
    IEnumerator WinLater()
    {
        yield return new WaitForSeconds(0.5f);
        next.gameObject.SetActive(true);
        lose.gameObject.SetActive(false);
        win.gameObject.SetActive(true);
        useTime.gameObject.SetActive(true);
        useTime.text = timeText.text;
        winReset.enabled = false;
        winReturn.enabled = false;
        next.enabled = false;
        chessBlack.Clear();
        gameUnderAnim.SetBool("underAppear", false);
        gameOnAnim.SetBool("isAppear", false);
        winAnim.SetBool("winAppear", true);
        StartCoroutine(GameClear()); 
    }

    /// <summary>
    /// 限时模式时间结束失败
    /// </summary>
    public void LoseLater()
    {
        //播放失败音效
        AudioSource.PlayClipAtPoint(loseAudio, transform.position);
        Cursor.visible = true;
        next.gameObject.SetActive(false);
        lose.gameObject.SetActive(true);
        win.gameObject.SetActive(false);
        useTime.gameObject.SetActive(false);
        winReset.enabled = false;
        winReturn.enabled = false;
        next.enabled = false;
        chessBlack.Clear();
        gameUnderAnim.SetBool("underAppear", false);
        gameOnAnim.SetBool("isAppear", false);
        winAnim.SetBool("winAppear", true);
        StartCoroutine(GameClear());
    }

    /// <summary>
    /// 棋盘、时间初始化
    /// </summary>
    /// <returns></returns>
    IEnumerator GameClear()
    {
        yield return new WaitForSeconds(0.5f);

        winReset.enabled = true;
        winReturn.enabled = true;
        next.enabled = true;

        cover.SetActive(false);
        cover1.SetActive(false);
        cover2.SetActive(false);
        timeText.text = null;
        spendTime = 0;

        for (int i = 0; i < chessBoardList.Length; i++)
        {
            if (chessBoardList[i].tag != "Black0")
            {
                chessBoardList[i].tag = "White";
                chessBoardList[i].sprite = chessImageWhite;
            }
        }
    }

    //棋子实例化*********************************************************************************************************************
    //Chess按钮点击,实例化棋子
    private void ChessBt1()
    {
        Instantiate(chess1, chessParent);
        ChessButtonClick();
        //播放选中音效
        AudioSource.PlayClipAtPoint(chessBtAudio1, transform.position);
    }
    private void ChessBt2()
    {
        Instantiate(chess2, chessParent);
        ChessButtonClick();
        //播放选中音效
        AudioSource.PlayClipAtPoint(chessBtAudio2, transform.position);
    }
    private void ChessBt3()
    {
        Instantiate(chess3, chessParent);
        ChessButtonClick();
        //播放选中音效
        AudioSource.PlayClipAtPoint(chessBtAudio3, transform.position);
    }
    private void ChessBt4()
    {
        Instantiate(chess4, chessParent);
        ChessButtonClick();
        //播放选中音效
        AudioSource.PlayClipAtPoint(chessBtAudio4, transform.position);
    }
    /// <summary>
    /// 隐藏光标
    /// </summary>
    private void ChessButtonClick()
    {
        Cursor.visible = false;
    }

    //数据存储***********************************************************************************************************************
    /// <summary>
    /// 初始化数据
    /// </summary>
    private void InitGameData()
    {
        Read();
        if (save != null)
        {
            isFirstGame = save.GetIsFirstGame();
        }
        else
        {
            isFirstGame = true;
        }
        //如果第一次游戏
        if (isFirstGame)
        {
            isFirstGame = false;

            level1.text = "上次时间:00:00:00";
            level2.text = "上次时间:00:00:00";
            level3.text = "上次时间:00:00:00";
            level4.text = "上次时间:00:00:00";
            level5.text = "上次时间:00:00:00";
            level6.text = "上次时间:00:00:00";
            timeLevel1.text = "上次剩余时间:00:00:00";
            timeLevel2.text = "上次剩余时间:00:00:00";
            timeLevel3.text = "上次剩余时间:00:00:00";
            timeLevel4.text = "上次剩余时间:00:00:00";
            timeLevel5.text = "上次剩余时间:00:00:00";
            timeLevel6.text = "上次剩余时间:00:00:00";

            save = new Save();
            Save();
        }
        else
        {
            level1.text = save.GetLevel1Time();
            level2.text = save.GetLevel2Time();
            level3.text = save.GetLevel3Time();
            level4.text = save.GetLevel4Time();
            level5.text = save.GetLevel5Time();
            level6.text = save.GetLevel6Time();
            timeLevel1.text = save.GetTimeLevel1Time();
            timeLevel2.text = save.GetTimeLevel2Time();
            timeLevel3.text = save.GetTimeLevel3Time();
            timeLevel4.text = save.GetTimeLevel4Time();
            timeLevel5.text = save.GetTimeLevel5Time();
            timeLevel6.text = save.GetTimeLevel6Time();
        }
    }

    /// <summary>
    /// 存储数据
    /// </summary>
    public void Save()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = File.Create(Application.persistentDataPath + "/byBin.data"))
            {
                save.SetIsFirstGame(isFirstGame);
                save.SetLevel1Time(level1.text);
                save.SetLevel2Time(level2.text);
                save.SetLevel3Time(level3.text);
                save.SetLevel4Time(level4.text);
                save.SetLevel5Time(level5.text);
                save.SetLevel6Time(level6.text);
                save.SetTimeLevel1Time(timeLevel1.text);
                save.SetTimeLevel2Time(timeLevel2.text);
                save.SetTimeLevel3Time(timeLevel3.text);
                save.SetTimeLevel4Time(timeLevel4.text);
                save.SetTimeLevel5Time(timeLevel5.text);
                save.SetTimeLevel6Time(timeLevel6.text);

                bf.Serialize(fs, save);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    /// <summary>
    /// 读取数据
    /// </summary>
    private void Read()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = File.Open(Application.persistentDataPath + "/byBin.data", FileMode.Open))
            {
                save = (Save)bf.Deserialize(fs);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    /// <summary>
    /// 重置数据
    /// </summary>
    public void ResetData()
    {
        //播放选中音效
        AudioSource.PlayClipAtPoint(buttonAudio, transform.position);

        isFirstGame = false;
        level1.text = "上次时间:00:00:00";
        level2.text = "上次时间:00:00:00";
        level3.text = "上次时间:00:00:00";
        level4.text = "上次时间:00:00:00";
        level5.text = "上次时间:00:00:00";
        level6.text = "上次时间:00:00:00";
        timeLevel1.text = "上次剩余时间:00:00:00";
        timeLevel2.text = "上次剩余时间:00:00:00";
        timeLevel3.text = "上次剩余时间:00:00:00";
        timeLevel4.text = "上次剩余时间:00:00:00";
        timeLevel5.text = "上次剩余时间:00:00:00";
        timeLevel6.text = "上次剩余时间:00:00:00";

        Save();
    }

    //退出游戏面板*******************************************************************************************************************
    /// <summary>
    /// 退出游戏
    /// </summary>
    public void YesBt()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(buttonAudio, transform.position);

        Save();
        Application.Quit();
    }
    /// <summary>
    /// 不退出游戏
    /// </summary>
    public void NoBt()
    {
        //播放按钮音效
        AudioSource.PlayClipAtPoint(buttonAudio, transform.position);

        endAnim.SetBool("isClick", false);

        settingReturnBt.enabled = true;
        musicBt.enabled = true;
        exitBt.enabled = true;
        normalBt.enabled = true;
        timeBt.enabled = true;
        moreBt.enabled = true;
    }
}
