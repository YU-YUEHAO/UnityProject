using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapselect : MonoBehaviour
{
    [Tooltip("当前关卡开启所需要的星星")]
    public int mapstart = 0;

    private bool isSelect = false;
    public GameObject locks;
    public GameObject starts;
    public GameObject map;
    public GameObject panel;
    public Text starstext;
    public int startLevel;
    public int EndLevel;
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("totalNum", 0) >= mapstart) {
            isSelect = true;
        }
        if (isSelect) {
            locks.SetActive(false);
            starts.SetActive(true);
        }
        int mapstartcount = 0;
        for (int i = startLevel; i <= EndLevel; i++) {
            mapstartcount += PlayerPrefs.GetInt("level" + i.ToString(), 0);
        }

        starstext.text = mapstartcount.ToString() + "/" + (((EndLevel - startLevel) + 1) * 3).ToString();


    }

    //地图选择进入关卡选项
    public void Selected()
    {
        if (isSelect) {
            panel.SetActive(true);
            map.SetActive(false);
        }
    }
    //关卡选项进入地图选择
    public void gotomap() {
        panel.SetActive(false);
        map.SetActive(true);
    }
}
