using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // 움직이는 속도
    private float Speed;

    // 움직임을 저장하는 벡터
    private Vector3 Movement;

    // 플레이어의 Animator 구성요소를 받아오기 위해
    private Animator animator;

    // 플레이어의 SpriteRenderer 구성요소를 받아오기 위해
    private SpriteRenderer playerRenderer;

    // 상태체크
    private bool onRun; // 달리기
    private bool onJump;// 점프

    // 플레이어가 바라보는 방향
    private float Direction;

    [Header("방향")] // 플레이어가 바라보는 방향

    [Tooltip ("왼쪽")]
    public bool DirLeft;
    [Tooltip ("오른쪽")]
    public bool DirRight;
    [Tooltip ("위쪽")]
    public bool DirUp;
    [Tooltip ("아래쪽")]
    public bool DirDown;

    void Awake()
    {
        //플레이어의 Animator를 받아온다.
        animator = GetComponent<Animator>();

        //플레이어의 SpriteRenderer를 받아온다.
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // 속도 초기화
        Speed = 5.0f;

        // 초기값 세팅
        onRun = false;
        onJump = false;
        Direction = 1.0f;

        DirLeft = false;
        DirRight = false;
        DirUp = false;
        DirDown = false;

        CoolDown = 1.0f;

    }

    private void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(0.5f);
    }

    private void Gomain()
    {
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        //플레이어 움직임
        Movement = new Vector3(
        Hor * Time.deltaTime * Speed,
        Ver * Time.deltaTime * (Speed  * 0.5f),
        0.0f);

        transform.position += new Vector3(0.0f, Movement,y, 0.0f);

        // Hor이 0이라면 멈춰있는 상태이므로 예외
        if(Hor != 0)
        Direction = Hor;

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            
        }


    }
}
