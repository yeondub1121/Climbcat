using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    
    GameObject player; // �÷��̾� ���� ������Ʈ�� �����ϱ� ���� ����
    void Start()
    {
        this.player = GameObject.Find("cat");// Scene���� "cat" ���� ������Ʈ�� ã�� �Ҵ�
    }

    
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;// �÷��̾��� ���� ��ġ�� ������
        transform.position = new Vector3(
             transform.position.x, playerPos.y, transform.position.z);// ī�޶��� y�� ��ġ�� �÷��̾��� y�� ��ġ�� �����Ͽ� ���󰡵��� ��
    }
}

