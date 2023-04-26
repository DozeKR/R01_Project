using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    public GameManager manager;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    GameObject scanObject;

    void Awake(){

        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    void Update(){

        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Jump") && scanObject != null){
            manager.Action(scanObject);
        }

    }

    void FixedUpdate(){

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

    }

    void LateUpdate(){

        anim.SetFloat("Speed", inputVec.magnitude);

        // 입력이 없는 경우에만 실행 캐릭터 플립
        if(inputVec.x != 0){
            spriter.flipX = inputVec.x < 0;
        }

    
        
    }
}
