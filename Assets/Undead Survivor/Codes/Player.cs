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
        //// 1. 힘을 준다.
        //rigid.AddForce(inputVec);

        //// 2. 속도 제어.
        //rigid.velocity = inputVec;

        // 3. 위치 이동.
        // 매개변수에 inputVec만 들어가면 안됨 월드 위치이기 때문에 현재 위치도 더해줘야 함
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
