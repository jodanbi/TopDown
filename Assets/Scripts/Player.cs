using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�̷����ϸ� ������Ʈ�� �߰��Ҷ� PlayerController, ��ũ��Ʈ�� ������ �پ� �ִٴ°� ��� �Ѵ�.
[RequireComponent (typeof (PlayerController))]

public class Player : MonoBehaviour
{
    //�̵����⿡ �ӵ��� �������� moveSpeed������ ����� �ش�.
    //�Ǽ� 5�� ���� moveSpeed�� �Ҵ��ϰ� �Ǽ������� Ÿ���� �����ϰ� ���� �����ڸ� public���� �Ѵ�. 
    public float moveSpeed = 5f;

    //Camera ���۷����� ����´�.
    //Camera�� viewCamera������ ����� �ְ�
    Camera viewCamera; 

    //PlayerController������ ����� controller��� �θ���.
    PlayerController controller;


    void Start()
    {//Start�޼ҵ�
     //�������� �κ��� ó���� �� �ֵ���. PlayerController�� ���� ���۷����� �����;���.
     // GetComponent<PlayerController>();
     //PlayerContorller�� Player.cs��ũ��Ʈ�� ���� ������Ʈ�� �پ� �ִ°� ������ 
     //PlayerController ������Ʈ�� ����´�.
        controller = GetComponent<PlayerController>();

        //viewCamera������ Camera.main�� �Ҵ�
        viewCamera = Camera.main;
    }

    void Update()
    {
        //�÷��̾� �������� �Է� �޴´�.
        //Vector3 moveInput �̶�� ������ ����� new Vector3�� �Ҵ��Ѵ�. Horizontal(����)��Vertical(����)���⿡ ���� �Է��� �޾ƾߵǴ�
        //Input.�� ���� GetAxsis(Horizontal)�� ȣ��/ y���� �ʿ������ 0, Input.GetAxis("Vertical")������ ȣ��
        //GetAxisRaw�� �ٲ㼭 �������� �� �ڿ������� ���ش�.
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //�Է¹��� ���� �������� ��ȯ�ϰ�
        //�����ӿ� �ӵ��� ���Ѵ�.
        //normalized ����ȭ - ������ ����Ű�� ������ ���ͷ� ����� ����
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;

        //controller.Move()�޼ҵ带 ȣ���ϰ� 
        //(moveVelocity)�� �������ش�.
        controller.Move(moveVelocity);


        //viewCamera�� ScreenPointToRay��� �޼ҵ带 �θ��µ� ȭ��󿡼� ��ġ�� ��ȯ���ִ� �޼ҵ���
        //(Input.mousePosition)ȭ��󿡼� ���콺��ġ�� �ԷµǴ°� ȭ��� �˷���
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
