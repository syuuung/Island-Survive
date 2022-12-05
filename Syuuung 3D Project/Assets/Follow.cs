using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float distance = 3;
    public float rotateSpeed;

    private GameObject parentCamera;

    private void Awake()
    {
        transform.position += offset;
        parentCamera = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        input();



        Vector3 reverseDistance = offset; // ī�޶� �ٶ󺸴� �չ����� Z ���Դϴ�. �̵����� ���� Z ������� ���͸� ���մϴ�.
        transform.position = Vector3.Lerp(transform.position, target.transform.position - transform.rotation * reverseDistance, 5 * Time.deltaTime); // �÷��̾��� ��ġ���� ī�޶� �ٶ󺸴� ���⿡ ���Ͱ��� ������ ��� ��ǥ�� �����մϴ�.
    }
    

    void input()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            
            transform.Rotate(new Vector3(0, -1, 0) * rotateSpeed * Time.deltaTime, Space.World);

        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 1, 0) *rotateSpeed * Time.deltaTime, Space.World);
        }  
    }
}
