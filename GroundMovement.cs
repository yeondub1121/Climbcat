using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float speed = 3f; // �̵� �ӵ�
    public float minX = -19.5f; // �ּ� x ��ǥ
    public float maxX = -3f; // �ִ� x ��ǥ

    private Vector3 startPosition; // �ʱ� ��ġ
    private int direction = 1; // �̵� ���� (1: ������, -1: ����)

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // �¿�� �����̱�
        float newX = transform.position.x + direction * speed * Time.deltaTime;
        newX = Mathf.Clamp(newX, minX, maxX); // x ��ǥ ����
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // �ִ� �Ǵ� �ּ� x ��ǥ�� �����ϸ� ���� �����Ͽ� �ݺ�
        if (newX <= minX || newX >= maxX)
        {
            ChangeDirection();
        }
    }

    // �ӵ� ���� �޼���
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // �ʱ� ��ġ�� ���� �޼���
    public void ResetPosition()
    {
        transform.position = startPosition;
    }

    // �̵� ���� ���� �޼���
    public void ChangeDirection()
    {
        direction *= -1;
    }
}