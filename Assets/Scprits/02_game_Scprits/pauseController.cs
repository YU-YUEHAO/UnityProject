using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseController : MonoBehaviour
{
    [Tooltip("��ͣ��ť")]
    public GameObject button;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    //������ͣ��ť,��������
    public void Pasue() {
        anim.SetBool("ispause", true);
        button.SetActive(false);
        if (mainScprit._instance.birds.Count > 0) {
            if (mainScprit._instance.birds[0].isreleased==false)
        {
                mainScprit._instance.birds[0].canmove = false;
            }
        }
    }
    //������Ϸ
    public void Resume() {
        Time.timeScale = 1;
        anim.SetBool("ispause", false);
        if (mainScprit._instance.birds.Count > 0)
        {
            if (mainScprit._instance.birds[0].isreleased==false)
            {
                mainScprit._instance.birds[0].canmove = true;
            }
        }

    }
    //�ؿ�ѡ��
    public void Home() {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    //����
    public void retry() { 
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void PauseEnd() {
        Time.timeScale = 0;
    }

    public void ResumeEnd() {
        Time.timeScale = 1;
        button.SetActive(true);
    }
}
