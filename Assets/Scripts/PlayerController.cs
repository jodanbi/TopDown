using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]


public class PlayerController : MonoBehaviour
{
    Vector3 velocity; // velocity라는 변수를 Vector3 타입에 할당하고

    Rigidbody myRigidbody; //myRigidbody 변수를 Rigidbody 타입에 할당하고

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


    //정기적이고 짧고 반복적으로 실행되야 하기때문에 FixedUpdate을 사용하고 다른 오브젝트 밑에 낑기지 않음
    //그리고 프레임 저하가 발생해도 프레임에 시간의 가중치를 곱해 실행되어 이동속도를 유지하게 됨.
    public void FixedUpdate() {
        //(myRigidbody에 .position현재위치를 넣고 여기에  이동속력 velocity을 +해주고 veclocity에 Time.fixedDeltaTime를 곱해준다.
        //fixedDeltaTime은 FixedUpdate와 fixedDeltaTime 두개의 메소드가 호출된 시간 간격을 말한다.
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
