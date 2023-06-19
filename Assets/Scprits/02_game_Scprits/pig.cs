using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : MonoBehaviour
{
    [Tooltip("受到最大速度")]
    public float maxspeed = 10;
    [Tooltip("受到最小速度")]
    public float minspeed = 5;
    [Tooltip("受伤切换的图片")]
    public Sprite sp;
    [Tooltip("爆炸效果的预制体")]
    public GameObject boom;
    [Tooltip("获得分数")]
    public GameObject score;
    [Tooltip("猪死亡的声音")]
    public AudioClip dead;
    [Tooltip("碰撞的声音")]
    public AudioClip collisionclip;
    [Tooltip("猪受伤的声音")]

    public AudioClip hunrtclip;

    private SpriteRenderer Render;
    private mainScprit mainScprit;

    //判断是猪或木头
    public bool ispig = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Render = this.GetComponent<SpriteRenderer>();
    }

    //判断碰撞
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float collisionSpeed = collision.relativeVelocity.magnitude;
        if (collision.gameObject.tag == "player") {
            mainScprit._instance.Audioplay(collisionclip);
        }
        //print(collision.relativeVelocity.magnitude);
        if (collisionSpeed >= maxspeed)
        {
            pigdead();
        }
        else if (collisionSpeed > minspeed && collisionSpeed < maxspeed) {
            Render.sprite = sp;
            mainScprit._instance.Audioplay(hunrtclip);
        }
    }
    //猪或木头死亡
    public void pigdead()
    {
        if (ispig) { 
        mainScprit._instance.pigs.Remove(this);
        }
        Destroy(this.gameObject);
        Instantiate(boom, this.transform.position,Quaternion.identity);
        GameObject go = Instantiate(score, this.transform.position+new Vector3(0,0.5f,0), Quaternion.identity);
        Destroy(go, 1.5f);

        mainScprit._instance.Audioplay(dead);
    }
}
