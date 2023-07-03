using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    
    GameObject timerText; // Ÿ�̸� �ؽ�Ʈ�� �����ϱ� ���� ����
    GameObject pointsText; // ����Ʈ �ؽ�Ʈ�� �����ϱ� ���� ����
    float time = 100.0f; // ������ ���� �ð�
    int points = 0; // �÷��̾ ȹ���� ����Ʈ ����



    public void GetRat()
    {
        this.points += 1; // �÷��̾ �㸦 ȹ���ϸ� ����Ʈ 1�� ����
    }
    void Start()
    {
        this.timerText = GameObject.Find("Time"); // Scene���� "Time" �ؽ�Ʈ�� ã�� �Ҵ�
        this.pointsText = GameObject.Find("Points"); // Scene���� "Points" �ؽ�Ʈ�� ã�� �Ҵ�
    }

    void Update()
    {
        this.time -= Time.deltaTime; // �ð��� ���ҽ�Ŵ
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1"); // Ÿ�̸� �ؽ�Ʈ ������Ʈ
        this.pointsText.GetComponent<Text>().text = this.points.ToString() + "/7"; // ����Ʈ �ؽ�Ʈ ������Ʈ
        if (this.time <= 0)
        {
            SceneManager.LoadScene("ClearScene"); // �ð��� 0�� �Ǹ� "ClearScene"�� �ε��Ͽ� ���� ����

        }
        if(points>=7)
        {
            SceneManager.LoadScene("ClearScene"); // ȹ���� ����Ʈ�� 7�� �̻��̸� "ClearScene"�� �ε��Ͽ� ���� ����

        }
    }
    
}
