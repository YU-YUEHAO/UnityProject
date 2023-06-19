using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : MonoBehaviour
{
    [Tooltip("�ܵ�����ٶ�")]
    public float maxspeed = 10;
    [Tooltip("�ܵ���С�ٶ�")]
    public float minspeed = 5;
    [Tooltip("�����л���ͼƬ")]
    public Sprite sp;
    [Tooltip("��ըЧ����Ԥ����")]
    public GameObject boom;
    [Tooltip("��÷���")]
    public GameObject score;
    [Tooltip("������������")]
    public AudioClip dead;
    [Tooltip("��ײ������")]
    public AudioClip collisionclip;
    [Tooltip("�����˵�����")]

    public AudioClip hunrtclip;

    private SpriteRenderer Render;
    private mainScprit mainScprit;

    //�ж������ľͷ
    public bool ispig = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Render = this.GetComponent<SpriteRenderer>();
    }

    //�ж���ײ
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
    //���ľͷ����
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
