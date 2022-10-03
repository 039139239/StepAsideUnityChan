using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWallController : MonoBehaviour
{
    //DestroyWallを移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;
    //前方向の速度
    private float velocityZ = 16f;
    //動きを減速させる係数
    private float coefficient = 0.99f;
    //ゲーム終了の判定
    private bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //DestroyWallに速度を与える
        this.myRigidbody.velocity = new Vector3(0, 0, this.velocityZ);

        //ゲーム終了ならDestroyWallの動きを減衰する
        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        //unitychanに衝突した場合
        if (other.gameObject.tag == "unitychan" || other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
        }

        //アイテムに衝突した場合
        if (other.gameObject.tag == "CoinTag" || other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            //接触したアイテムのオブジェクトを破棄
            Destroy(other.gameObject);
        }
    }

}
