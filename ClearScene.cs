using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClearScene : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Start Scene"); // R Ű�� ������ "Start Scene"�� �ε��Ͽ� ���� �����

        }
    }

}

   

