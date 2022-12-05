using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// �÷��̾��� �ൿ�� �����ϴ� ��ũ��Ʈ

public class PlayerController : MonoBehaviour
{
    public float        speed = 5f;
    private Rigidbody   rigidBody;

    public Vector3      moveVec;
    public Camera       playerCamera;
    NavMeshAgent        agent;

    private void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            // ���� ĳ��Ʈ�� ���� Ȯ��
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                moveVec = raycastHit.point;
                agent.SetDestination(moveVec);

                Debug.Log("movePoint: "+ moveVec.ToString());
                Debug.Log("�ǰ� ��ü: " + raycastHit.transform.name);
            }
        }
    }
}

