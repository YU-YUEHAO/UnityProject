using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainScprit : MonoBehaviour

{
    [Tooltip("С�񼯺�")]
    public List<birds> birds;
    [Tooltip("����")]
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
    //��ʼ����������С���λ��
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
    //�л���һֻС��
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
    //չʾ��������
    public void showStarts() {
       StartCoroutine("show");
    }
    //�ж�С��������Ӧ��������+1��������Ϊ��
    IEnumerator show() {
        for (; startsNums < birds.Count + 1; startsNums++) {
            if (startsNums >= starts.Length) {
                break;
            }
            yield return new WaitForSeconds(0.2f);
            starts[startsNums].SetActive(true);
        }
    }

    //����
  public void replay() {
        savaData();
        SceneManager.LoadScene(2);
    }
    //�ؿ�ѡ��
    public void home() {
        savaData();
        SceneManager.LoadScene(1);
    }
    //���Ŷ�Ӧ��������Ч
    public void Audioplay(AudioClip clip) {
        AudioSource.PlayClipAtPoint(clip, this.transform.position);
    }

    //��������
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
