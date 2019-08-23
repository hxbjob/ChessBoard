using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChesMove : MonoBehaviour
{
    //鼠标光标坐标
    private Vector2 mousePos;
    //触发的棋盘格数量
    private int triggerCount = 0;

    private void Update()
    {
        //棋子跟随鼠标移动
        mousePos = Input.mousePosition;
        transform.position = mousePos;

        if (mousePos.y > GameManager.Instance.chessUnderPanel.GetComponent<RectTransform>().rect.height)
        {
            StartCoroutine(LeftMouseDown());
        }

        //右键点击顺时针旋转
        if (Input.GetMouseButtonDown(1))
        {
            //播放旋转音效
            AudioSource.PlayClipAtPoint(GameManager.Instance.chessRotate, GameManager.Instance.transform.position);

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 90);
        }

        //销毁棋子
        if (Cursor.visible == true)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 进入棋盘格并激活
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        //棋子1
        if (this.name == "Chess1(Clone)" && collision.tag == "White" )
        {
            collision.isTrigger = true;
            //棋盘格触发发光
            Image chessWhite = collision.GetComponent<Image>();
            chessWhite.color = Color.red;
            if (Input.GetMouseButtonDown(0))
            {
                //被触发棋盘格数量
                for (int i = 0; i < GameManager.Instance.chessBoardList.Length; i++)
                {
                    if (GameManager.Instance.chessBoardList[i].GetComponent<Collider2D>().isTrigger == true)
                    {
                        triggerCount++;
                    }
                }

                //放置棋子
                if (triggerCount == 3)
                {
                    //播放放置音效
                    AudioSource.PlayClipAtPoint(GameManager.Instance.chessAudio1, GameManager.Instance.transform.position);

                    triggerCount = 0;
                    chessWhite.sprite = GameManager.Instance.chessImage1;
                    chessWhite.color = Color.white;
                    chessWhite.tag = "Black";
                    GameManager.Instance.chessBlack.Add(chessWhite);
                    Debug.Log(GameManager.Instance.chessBlack.Count);
                    StartCoroutine(LeftMouseDown());
                }
                else
                {
                    //播放错误音效
                    AudioSource.PlayClipAtPoint(GameManager.Instance.error, GameManager.Instance.transform.position);

                    triggerCount = 0;
                }   
            }
        }
        //棋子2
        if (this.name == "Chess2(Clone)" && collision.tag == "White")
        {
            collision.isTrigger = true;
            Image chessWhite = collision.GetComponent<Image>();
            chessWhite.color = Color.yellow;
            if (Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < GameManager.Instance.chessBoardList.Length; i++)
                {
                    if (GameManager.Instance.chessBoardList[i].GetComponent<Collider2D>().isTrigger == true)
                    {
                        triggerCount++;
                    }
                }

                if (triggerCount == 2)
                {
                    //播放放置音效
                    AudioSource.PlayClipAtPoint(GameManager.Instance.chessAudio2, GameManager.Instance.transform.position);

                    triggerCount = 0;
                    chessWhite.sprite = GameManager.Instance.chessImage2;
                    chessWhite.color = Color.white;
                    chessWhite.tag = "Black";
                    Debug.Log(GameManager.Instance.chessBlack.Count);
                    GameManager.Instance.chessBlack.Add(chessWhite);
                    StartCoroutine(LeftMouseDown());
                    Debug.Log(GameManager.Instance.chessBlack.Count);
                }
                else
                {
                    //播放错误音效
                    AudioSource.PlayClipAtPoint(GameManager.Instance.error, GameManager.Instance.transform.position);

                    triggerCount = 0;
                }
            }
        }
        //棋子3
        if (this.name == "Chess3(Clone)" && collision.tag == "White")
        {
            collision.isTrigger = true;
            Image chessWhite = collision.GetComponent<Image>();
            chessWhite.color = Color.blue;
            if (Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < GameManager.Instance.chessBoardList.Length; i++)
                {
                    if (GameManager.Instance.chessBoardList[i].GetComponent<Collider2D>().isTrigger == true)
                    {
                        triggerCount++;
                    }
                }

                if (triggerCount == 4)
                {
                    //播放放置音效
                    AudioSource.PlayClipAtPoint(GameManager.Instance.chessAudio3, GameManager.Instance.transform.position);

                    triggerCount = 0;
                    chessWhite.sprite = GameManager.Instance.chessImage3;
                    chessWhite.color = Color.white;
                    chessWhite.tag = "Black";
                    GameManager.Instance.chessBlack.Add(chessWhite);
                    Debug.Log(GameManager.Instance.chessBlack.Count);
                    StartCoroutine(LeftMouseDown());
                }
                else
                {
                    //播放错误音效
                    AudioSource.PlayClipAtPoint(GameManager.Instance.error, GameManager.Instance.transform.position);

                    triggerCount = 0;
                }
            }
        }
        //棋子4
        if (this.name == "Chess4(Clone)" && collision.tag == "White")
        {
            collision.isTrigger = true;
            Image chessWhite = collision.GetComponent<Image>();
            chessWhite.color = Color.green;
            if (Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < GameManager.Instance.chessBoardList.Length; i++)
                {
                    if (GameManager.Instance.chessBoardList[i].GetComponent<Collider2D>().isTrigger == true)
                    {
                        triggerCount++;
                    }
                }

                if (triggerCount == 4)
                {
                    //播放放置音效
                    AudioSource.PlayClipAtPoint(GameManager.Instance.chessAudio4, GameManager.Instance.transform.position);

                    triggerCount = 0;
                    chessWhite.sprite = GameManager.Instance.chessImage4;
                    chessWhite.color = Color.white;
                    chessWhite.tag = "Black";
                    GameManager.Instance.chessBlack.Add(chessWhite);
                    Debug.Log(GameManager.Instance.chessBlack.Count);
                    StartCoroutine(LeftMouseDown());
                }
                else
                {
                    //播放错误音效
                    AudioSource.PlayClipAtPoint(GameManager.Instance.error, GameManager.Instance.transform.position);

                    triggerCount = 0;
                }
            }
        }
    }
    /// <summary>
    /// 放置棋子后延迟出现光标
    /// </summary>
    /// <returns></returns>
    IEnumerator LeftMouseDown()
    {
        yield return new WaitForSeconds(0.1f);
        Cursor.visible = true;
    }

    /// <summary>
    /// 将未激活棋盘格恢复
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.isTrigger = false;
        
        if (collision.tag == "White")
        {
            Image chessWhite = collision.GetComponent<Image>();
            chessWhite.color = Color.white;  
        }
    }
}
