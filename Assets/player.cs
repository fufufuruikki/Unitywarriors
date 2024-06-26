using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Transform myTransform;    // transform情報を格納する変数 
    Vector3 initial_position;     // 物体の初期位置を格納する変数
    //Vector3 initial_rotate;
    // Start is called before the first frame update 
    void Start() 
    { 
        Application.targetFrameRate = 60;   // ← FPSを60に設定
        myTransform = this.transform;  // 物体のtransform情報をリンクする
        initial_position = myTransform.position;  // 初期位置を取り出す
        //initial_rotate = new Vector3(0,2,0);
    } 
 
    // Update is called once per frame 
    void Update() 
    { 
        if (Input.GetKey("up")) // ↑なら前（Z方向）に0.1だけ進む 
        { 
            transform.position += transform.forward * 0.1f; 
        } 
        if (Input.GetKey("down"))  // ↓なら-Z方向に0.1だけ進む 
        { 
            transform.position -= transform.forward * 0.1f; 
        } 
        if (Input.GetKey ("right"))   // ←ならY軸に3度回転する 
        { 
            transform.Rotate(0f,3.0f,0f); 
        } 
        if (Input.GetKey ("left"))   // →ならY軸に-3度回転する 
        { 
            transform.Rotate(0f, -3.0f, 0f); 
        } 
    }
    void OnCollisionEnter(Collision other)  // 衝突を判定する関数を呼ぶ 
    { 
        if (other.transform.parent.gameObject.name  == "wall")  // 衝突した物体が「ゴール」なら（※） 
        { 
            this.transform.position = initial_position;
            //this.transform.Rotate(initial_rotate);
        } 
    } 
}
