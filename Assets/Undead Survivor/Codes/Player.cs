using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 inputVec;
    public float speed;
    public Scanner scanner;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }   
   
    private void FixedUpdate()
    {
        //// 1. ���� �ش�.
        //rigid.AddForce(inputVec);

        //// 2. �ӵ� ����.
        //rigid.velocity = inputVec;

        // 3. ��ġ �̵�.
        // �Ű������� inputVec�� ���� �ȵ� ���� ��ġ�̱� ������ ���� ��ġ�� ������� ��
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }
    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
      
        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
}
