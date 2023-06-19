using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class birds : MonoBehaviour
{
    [Tooltip("�ж�����Ƿ���")]
    private bool isClick = false;
    [Tooltip("�����ק����")]
    public float MaxDistance;
    [Tooltip("�����ק�������")]
    public Transform point;
    [Tooltip("�����ק�������")]
    public Transform lpoint;
    [Tooltip("С����ʧ��Ч")]
    public GameObject boom;
    [Tooltip("���ƽ���ٶ�")]
    public float soomth = 3;
    [Tooltip("С��ѡ����Ч")]
    public AudioClip select;
    [Tooltip("С�������Ч")]
    public AudioClip flying;


    public Sprite[] sprites;

    public LineRenderer right;
    public LineRenderer left;
    protected SpriteRenderer render;
    [HideInInspector]
    public SpringJoint2D sp;
    [HideInInspector]
    protected Rigidbody2D rd;
    [HideInInspector]
    public bool canmove = false;
    private bool isfly=false;
    private bool fl = false;
    [HideInInspector]
    public bool isreleased = false;



    protected TestMyTrail testMyTrail;


    // Start is called before the first frame update
    private void Awake()
    {
        sp = this.GetComponent<SpringJoint2D>();
        rd = this.GetComponent<Rigidbody2D>();
        testMyTrail = this.GetComponent<TestMyTrail>();
        render = this.GetComponent<SpriteRenderer>();

    }
    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (isClick) {
            this.transform.position =Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);
            if (Vector3.Distance(point.position, this.transform.position) > MaxDistance) {
                Vector3 pos = (this.transform.position - point.position).normalized;
                pos *= MaxDistance;
                this.transform.position = pos + point.position;
            }
            line();
        }
        if (isfly) {
            if (Input.GetMouseButtonDown(0)) {
                birdskill();
            }
        }
        //�������
       Vector3 CameraP = Camera.main.transform.position;
        //a+b*t
        CameraP = Vector3.Lerp(CameraP,new Vector3(Mathf.Clamp(this.transform.position.x, (float)2.38, 15), CameraP.y,CameraP.z), soomth);
        Camera.main.transform.position = CameraP;
    }
    //��갴�µ��ú���
    private void OnMouseDown()
    {
        if (canmove) {
            mainScprit._instance.Audioplay(select);
            isClick = true;
            rd.isKinematic = true;
        }
    }
    //���̧����ú���
    private void OnMouseUp()
    {
        if (canmove) { 
        right.enabled = false;
        left.enabled = false;
        isClick = false;
        rd.isKinematic = false;
        Invoke("fly", 0.1f);
            canmove = false;
        }
    }

    //����
    private void line() {
        right.enabled = true;
        left.enabled = true;
        Vector3 selfposion = this.transform.position;
        right.SetPosition(0, point.position);
        right.SetPosition(1, selfposion);
        left.SetPosition(0, lpoint.position);
        left.SetPosition(1, selfposion);

    }
    //С�����
    private void fly() {
        isfly = true;
        fl = true;
        isreleased = true;
        mainScprit._instance.Audioplay(flying);
        sp.enabled = false;
        Invoke("Next", 5f);
        testMyTrail.heroAttack();
    }

    //С����ֻ�
   protected virtual void Next() {
        mainScprit._instance.birds.Remove(this);
        Destroy(this.gameObject);
        Instantiate(boom, this.transform.position, Quaternion.identity);
        mainScprit._instance.Nextbird();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (fl) {
            if (sprites.Length == 1)
            {
                render.sprite = sprites[0];
            }
            else if (sprites.Length == 2)
            {
                render.sprite = sprites[1];
            }
        }
        isfly = false;
        fl = false;
        testMyTrail.heroIdle();

    }
    //С����
    public virtual void birdskill() {
        isfly = false;
    }

}
