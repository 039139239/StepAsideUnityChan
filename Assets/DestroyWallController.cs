using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWallController : MonoBehaviour
{
    //DestroyWall���ړ�������R���|�[�l���g������
    private Rigidbody myRigidbody;
    //�O�����̑��x
    private float velocityZ = 16f;
    //����������������W��
    private float coefficient = 0.99f;
    //�Q�[���I���̔���
    private bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody�R���|�[�l���g���擾
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //DestroyWall�ɑ��x��^����
        this.myRigidbody.velocity = new Vector3(0, 0, this.velocityZ);

        //�Q�[���I���Ȃ�DestroyWall�̓�������������
        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        //unitychan�ɏՓ˂����ꍇ
        if (other.gameObject.tag == "unitychan" || other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
        }

        //�A�C�e���ɏՓ˂����ꍇ
        if (other.gameObject.tag == "CoinTag" || other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            //�ڐG�����A�C�e���̃I�u�W�F�N�g��j��
            Destroy(other.gameObject);
        }
    }

}
