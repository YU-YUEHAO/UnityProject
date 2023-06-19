using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBirds : birds
{
    private List<pig> blocks = new List<pig>();
    //外圈触发器检测到周围物体
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") { 
    
        blocks.Add(collision.gameObject.GetComponent<pig>());
        }
    }
    //外圈触发器检测不到周围物体
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            blocks.Remove(collision.gameObject.GetComponent<pig>());
        }
    }

    public override void birdskill()
    {
        base.birdskill();
        if (blocks.Count > 0 && blocks != null) {
            for (var i = 0; i < blocks.Count; i++) {
                blocks[i].pigdead();
            }
        }
        onclear();
    }

    void onclear() {
        rd.velocity = Vector2.zero;
        Instantiate(boom, this.transform.position, Quaternion.identity);
        render.enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        testMyTrail.heroIdle();
    }

    protected override void Next() {
        mainScprit._instance.birds.Remove(this);
        Destroy(this.gameObject);
        mainScprit._instance.Nextbird();
    }
}
