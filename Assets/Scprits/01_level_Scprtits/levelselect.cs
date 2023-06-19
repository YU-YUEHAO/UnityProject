using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelselect : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite bgsp;

    private bool isSelect = false;
    private Image image;

    [Tooltip("关卡星星数量")]
    public GameObject[] stars;
    private void Awake()
    {
        image = this.GetComponent<Image>();
    }
    void Start()
    {
        if (transform.parent.GetChild(0).name.Equals(gameObject.name))
        {
            isSelect = true;
        }
        else {
            int beforelevel = int.Parse(this.gameObject.name) - 1;
            if (PlayerPrefs.GetInt("level" + beforelevel.ToString()) > 0) {
                isSelect = true;
            }
        }


        if (isSelect) {
            image.sprite = bgsp;
            this.transform.Find("num").gameObject.SetActive(true);
        }

        int count= PlayerPrefs.GetInt("level" + this.gameObject.name);

        if (count > 0) {
            for (int i = 0; i < count; i++) {
                stars[i].SetActive(true);
            }
        }

    }
    //点击关卡跳转到game场景
    public void LevelSelected() {
        if (isSelect)
        {
            PlayerPrefs.SetString("nowlevel","level" + this.gameObject.name);
            SceneManager.LoadScene(2);
        }
    }
}
