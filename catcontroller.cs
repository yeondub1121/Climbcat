using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class catcontroller : MonoBehaviour
{
    Rigidbody2D rigid2D;// Rigidbody2D ������Ʈ�� ����ϱ� ���� ����
    Animator animator; // Animator ������Ʈ�� ����ϱ� ���� ����
    float jumpForce = 670.0f; // ����  ũ��
    float walkForce = 100.0f; // �̵��� ���� 
    float maxWalkSpeed = 3.0f; // �ִ� �̵� �ӵ� ���� 
    Vector3 defaultScale; // �⺻ ũ�⸦ �����ϱ� ���� ����
    GameObject director; // GameDirector ���� ������Ʈ�� �����ϱ� ���� ����
    public AudioClip jumpSE; // ���� ���� ����Ʈ
    public AudioClip getSE; // ������ ȹ�� ���� ����Ʈ
    AudioSource aud; // AudioSource ������Ʈ�� ����ϱ� ���� ����



    void Start()
    {
        this.aud = GetComponent<AudioSource>(); // �ڽ��� AudioSource ������Ʈ�� ������
        this.rigid2D = GetComponent<Rigidbody2D>(); // �ڽ��� Rigidbody2D ������Ʈ�� ������
        this.animator = GetComponent<Animator>(); // �ڽ��� Animator ������Ʈ�� ������
        this.defaultScale = transform.localScale; // �ʱ� ũ�⸦ ����
        this.director = GameObject.Find("GameDirector"); // Scene���� GameDirector ���� ������Ʈ�� ã�� �Ҵ�

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);  // Space Ű�� ������ ���� �ӵ��� 0�� ��� ���� ���� ����
            this.aud.PlayOneShot(this.jumpSE); // ���� ���� ����Ʈ ���
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1; // ������ ȭ��ǥ Ű�� ���� ��� key ���� 1�� ����
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1; // ���� ȭ��ǥ Ű�� ���� ��� key ���� -1�� ����

        float speedx = Mathf.Abs(this.rigid2D.velocity.x); // ���� x�� �ӵ��� ���밪�� ������

        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce); // �ִ� �̵� �ӵ��� �������� �ʾҴٸ� �̵����� ����
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // ĳ������ ���⿡ ���� �������� ����
        }
        else
        {
            transform.localScale = defaultScale; //ĳ������ ����� �������� �ʰ� �⺻ ������� �ǵ�����
        }

        this.animator.speed = speedx / 2.0f; // �ִϸ������� �ӵ��� ���� x�� �ӵ��� �������� ����

        if (transform.position.y < -10) // ĳ������ y�� ��ġ�� -10���� �۾����� ���
        {
            SceneManager.LoadScene("Game"); // "Game" ���� �ٽ� �ε�
        }



    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("item")) // �浹�� ������Ʈ�� �±װ� "item"�� ���
        {
            director.GetComponent<GameDirector>().GetRat(); // GameDirector�� GetRat() �޼��� ȣ��
            Destroy(collision.gameObject); // �浹�� ������Ʈ ������� ��
            this.aud.PlayOneShot(this.getSE); // ������ ȹ�� ���� ����Ʈ ���
        }
    }


}