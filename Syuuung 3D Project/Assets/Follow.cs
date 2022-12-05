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



        Vector3 reverseDistance = offset; // 카메라가 바라보는 앞방향은 Z 축입니다. 이동량에 따른 Z 축방향의 벡터를 구합니다.
        transform.position = Vector3.Lerp(transform.position, target.transform.position - transform.rotation * reverseDistance, 5 * Time.deltaTime); // 플레이어의 위치에서 카메라가 바라보는 방향에 벡터값을 적용한 상대 좌표를 차감합니다.
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
