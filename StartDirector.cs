using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour
{
   
    void OnMouseDown()
    {
        if (gameObject.name == "Play") // Ŭ���� ���� ������Ʈ�� �̸��� "Play"�� ���
        {
            
            SceneManager.LoadScene("Game"); // "Game" ���� �ε��Ͽ� ������ ����

        }
       
          
    }

}