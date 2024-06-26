using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_wall : MonoBehaviour
{
    Transform myTransform;  // 物体の transform 情報を格納する変数
    private int f_rotate_wall;
    private int f_wait;
    Vector3 origin = new Vector3(5.7f, 1f, -5.4f);  // 回転中心 
    Vector3 axis = new Vector3(0f, 1f, 0f);   // 回転軸（Y 軸）
    private double angle;         // 物体の角度を格納する変数
    private int timer;
  
    // Start is called before the first frame update 
    void Start() 
    { 
        myTransform = this.transform;    // transform情報を取得
        f_rotate_wall = 0;
        f_wait = 0;
        timer = 0;
        angle = 0;
    } 
 
    // Update is called once per frame 
    void Update() 
    { 
        if (f_wait == 1)
        {
            timer += 1;
            if (timer == 2 * 60)
            {
                f_wait = 0;
                timer = 0;
                if (f_rotate_wall == 0)
                {
                    f_rotate_wall = 1;
                }
                else
                {
                    f_rotate_wall = 0;
                }
            }
        }
        else
        {
            if (f_rotate_wall == 0)
            {
                angle += 2;
                myTransform.RotateAround(origin, axis, 2f);
                if (angle == 90)
                {
                    f_wait = 1;
                }
            }
            else
            {
                angle -= 1.5;
                myTransform.RotateAround(origin, axis, -1.5f);
                if (angle == 0)
                {
                    f_wait = 1;
                }
            }
        }
    }
}
