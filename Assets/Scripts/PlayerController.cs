using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]


public class PlayerController : MonoBehaviour
{
    Vector3 velocity; // velocity��� ������ Vector3 Ÿ�Կ� �Ҵ��ϰ�

    Rigidbody myRigidbody; //myRigidbody ������ Rigidbody Ÿ�Կ� �Ҵ��ϰ�

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }


    //�������̰� ª�� �ݺ������� ����Ǿ� �ϱ⶧���� FixedUpdate�� ����ϰ� �ٸ� ������Ʈ �ؿ� ������ ����
    //�׸��� ������ ���ϰ� �߻��ص� �����ӿ� �ð��� ����ġ�� ���� ����Ǿ� �̵��ӵ��� �����ϰ� ��.
    public void FixedUpdate() {
        //(myRigidbody�� .position������ġ�� �ְ� ���⿡  �̵��ӷ� velocity�� +���ְ� veclocity�� Time.fixedDeltaTime�� �����ش�.
        //fixedDeltaTime�� FixedUpdate�� fixedDeltaTime �ΰ��� �޼ҵ尡 ȣ��� �ð� ������ ���Ѵ�.
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
