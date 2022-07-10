using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이렇게하면 오브젝트에 추가할때 PlayerController, 스크립트가 무조건 붙어 있다는걸 명시 한다.
[RequireComponent (typeof (PlayerController))]

public class Player : MonoBehaviour
{
    //이동방향에 속도를 내기위해 moveSpeed변수를 만들어 준다.
    //실수 5를 변수 moveSpeed에 할당하고 실수형으로 타입을 설정하고 접근 제한자를 public으로 한다. 
    public float moveSpeed = 5f;

    //Camera 레퍼런스를 갖고온다.
    //Camera에 viewCamera변수를 만들어 주고
    Camera viewCamera; 

    //PlayerController변수를 만들고 controller라고 부르자.
    PlayerController controller;


    void Start()
    {//Start메소드
     //물리적인 부분을 처리할 수 있도록. PlayerController에 대한 레퍼런스를 가져와야함.
     // GetComponent<PlayerController>();
     //PlayerContorller와 Player.cs스크립트가 같은 오브젝트에 붙어 있는걸 전제로 
     //PlayerController 컴포넌트를 갖고온다.
        controller = GetComponent<PlayerController>();

        //viewCamera변수에 Camera.main을 할당
        viewCamera = Camera.main;
    }

    void Update()
    {
        //플레이어 움직임을 입력 받는다.
        //Vector3 moveInput 이라는 변수를 만들어 new Vector3를 할당한다. Horizontal(수평)과Vertical(수직)방향에 대한 입력을 받아야되니
        //Input.을 적고 GetAxsis(Horizontal)를 호출/ y값은 필요없으니 0, Input.GetAxis("Vertical")수직을 호출
        //GetAxisRaw로 바꿔서 움직임을 더 자연스럽게 해준다.
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //입력받은 값을 방향으로 변환하고
        //움직임에 속도를 곱한다.
        //normalized 정규화 - 방향을 가리키는 단위를 벡터로 만드는 연산
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;

        //controller.Move()메소드를 호출하고 
        //(moveVelocity)를 전달해준다.
        controller.Move(moveVelocity);


        //viewCamera의 ScreenPointToRay라는 메소드를 부르는데 화면상에서 위치를 반환해주는 메소드임
        //(Input.mousePosition)화면상에서 마우스위치가 입력되는걸 화면상에 알려줌
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;
         
        if(groundPlane.Raycast(ray,out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            //    Debug.DrawLine(ray.origin, point, Color.red);

            controller.LookAt(point);
        }
        
    }

}
