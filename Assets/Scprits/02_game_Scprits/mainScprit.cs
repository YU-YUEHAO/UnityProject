using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainScprit : MonoBehaviour

{
    [Tooltip("小鸟集合")]
    public List<birds> birds;
    [Tooltip("猪集合")]
    public List<pig> pigs;

    public GameObject win;
    public GameObject lose;
    public static mainScprit _instance;
    public int totallevel = 10;
    public GameObject[] starts;
 
    public Vector3 originalpostion;
    private int startsNums;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        _instance = this;
        if (birds.Count > 0) { 
        originalpostion = birds[0].transform.position;
        }
        win.SetActive(false);
        lose.SetActive(false);
    }
    // Start is called before the first frame update
    private void Start()
    {
        Initial();
    }
    //初始化场景所有小鸟的位置
    void Initial()
    {
        for (int i = 0; i < birds.Count; i++) {
            if (i == 0) {
                birds[i].transform.position = originalpostion;
                birds[i].enabled = true; 
                birds[i].sp.enabled = true;
                birds[i].canmove = true;
            }
            else {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
                birds[i].canmove = false;
            }
        }    
    }
    //切换下一只小鸟
  public void Nextbird() 
    {
        if (pigs.Count > 0)
        {
            if (birds.Count > 0)
            {
                Initial();
            }
            else {
                lose.SetActive(true);
            }
        }
        else {
            win.SetActive(true);
        }
    }
    //展示星星数量
    public void showStarts() {
       StartCoroutine("show");
    }
    //判断小鸟数量对应星星数量+1，超过三为三
    IEnumerator show() {
        for (; startsNums < birds.Count + 1; startsNums++) {
            if (startsNums >= starts.Length) {
                break;
            }
            yield return new WaitForSeconds(0.2f);
            starts[startsNums].SetActive(true);
        }
    }

    //重玩
  public void replay() {
        savaData();
        SceneManager.LoadScene(2);
    }
    //关卡选择
    public void home() {
        savaData();
        SceneManager.LoadScene(1);
    }
    //播放对应的声音特效
    public void Audioplay(AudioClip clip) {
        AudioSource.PlayClipAtPoint(clip, this.transform.position);
    }

    //保存数据
    public void savaData() {
        if (startsNums > PlayerPrefs.GetInt(PlayerPrefs.GetString("nowlevel"))) { 
         PlayerPrefs.SetInt(PlayerPrefs.GetString("nowlevel"), startsNums);
        }
        int sum = 0;
        for (int i = 1; i <= totallevel; i++) {
            sum += PlayerPrefs.GetInt(PlayerPrefs.GetString("level")+i.ToString());
        }
        PlayerPrefs.SetInt("totalNum", sum);
    }
}
