using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public Vector3 dirVec;
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

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");


        // 방향 변수
        if(vDown && inputVec.normalized.y  == 1)
            dirVec = Vector3.up;
        else if(vDown && inputVec.normalized.y  == -1)
            dirVec = Vector3.down;
        else if(hDown && inputVec.normalized.x == -1)
            dirVec = Vector3.left;
        else if(hDown && inputVec.normalized.x == 1)
            dirVec = Vector3.right;

        // 점프버튼 상호작용
        if(Input.GetButtonDown("Jump") && scanObject != null){
            manager.Action(scanObject);
        }
        
    }

    void FixedUpdate(){
        // Move
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

        // Ray
        Debug.DrawRay(rigid.position, dirVec * 1.0f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 1.0f, LayerMask.GetMask("Object"));

        if(rayHit.collider != null){
            scanObject = rayHit.collider.gameObject;
        }
        else{
            scanObject = null;
        }
    }

    void LateUpdate(){

        anim.SetFloat("Speed", inputVec.magnitude);

        // 입력이 없는 경우에만 실행 캐릭터 플립
        if(inputVec.x != 0){
            spriter.flipX = inputVec.x < 0;
        }

    
        
    }
}
