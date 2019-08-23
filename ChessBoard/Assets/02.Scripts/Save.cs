using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Save
{
    private bool isFirstGame;
    public string level1time;
    public string level2time;
    public string level3time;
    public string level4time;
    public string level5time;
    public string level6time;
    public string timeLevel1time;
    public string timeLevel2time;
    public string timeLevel3time;
    public string timeLevel4time;
    public string timeLevel5time;
    public string timeLevel6time;

    public void SetIsFirstGame(bool isFirstGame)
    {
        this.isFirstGame = isFirstGame;
    }
    public bool GetIsFirstGame()
    {
        return isFirstGame;
    }

    //正常模式时间
    public void SetLevel1Time(string level1time)
    {
        this.level1time = level1time;
    }
    public string GetLevel1Time()
    {
        return level1time;
    }
    public void SetLevel2Time(string level2time)
    {
        this.level2time = level2time;
    }
    public string GetLevel2Time()
    {
        return level2time;
    }
    public void SetLevel3Time(string level3time)
    {
        this.level3time = level3time;
    }
    public string GetLevel3Time()
    {
        return level3time;
    }
    public void SetLevel4Time(string level4time)
    {
        this.level4time = level4time;
    }
    public string GetLevel4Time()
    {
        return level4time;
    }
    public void SetLevel5Time(string level5time)
    {
        this.level5time = level5time;
    }
    public string GetLevel5Time()
    {
        return level5time;
    }
    public void SetLevel6Time(string level6time)
    {
        this.level6time = level6time;
    }
    public string GetLevel6Time()
    {
        return level6time;
    }

    //限时模式时间
    public void SetTimeLevel1Time(string timeLevel1time)
    {
        this.timeLevel1time = timeLevel1time;
    }
    public string GetTimeLevel1Time()
    {
        return timeLevel1time;
    }
    public void SetTimeLevel2Time(string timeLevel2time)
    {
        this.timeLevel2time = timeLevel2time;
    }
    public string GetTimeLevel2Time()
    {
        return timeLevel2time;
    }
    public void SetTimeLevel3Time(string timeLevel3time)
    {
        this.timeLevel3time = timeLevel3time;
    }
    public string GetTimeLevel3Time()
    {
        return timeLevel3time;
    }
    public void SetTimeLevel4Time(string timeLevel4time)
    {
        this.timeLevel4time = timeLevel4time;
    }
    public string GetTimeLevel4Time()
    {
        return timeLevel4time;
    }
    public void SetTimeLevel5Time(string timeLevel5time)
    {
        this.timeLevel5time = timeLevel5time;
    }
    public string GetTimeLevel5Time()
    {
        return timeLevel1time;
    }
    public void SetTimeLevel6Time(string timeLevel6time)
    {
        this.timeLevel6time = timeLevel6time;
    }
    public string GetTimeLevel6Time()
    {
        return timeLevel6time;
    }
}
