using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // �����̴� �ӵ�
    private float Speed;

    // �������� �����ϴ� ����
    private Vector3 Movement;

    // �÷��̾��� Animator ������Ҹ� �޾ƿ��� ����
    private Animator animator;

    // �÷��̾��� SpriteRenderer ������Ҹ� �޾ƿ��� ����
    private SpriteRenderer playerRenderer;

    // ����üũ
    private bool onRun; // �޸���
    private bool onJump;// ����

    // �÷��̾ �ٶ󺸴� ����
    private float Direction;

    [Header("����")] // �÷��̾ �ٶ󺸴� ����

    [Tooltip ("����")]
    public bool DirLeft;
    [Tooltip ("������")]
    public bool DirRight;
    [Tooltip ("����")]
    public bool DirUp;
    [Tooltip ("�Ʒ���")]
    public bool DirDown;

    void Awake()
    {
        //�÷��̾��� Animator�� �޾ƿ´�.
        animator = GetComponent<Animator>();

        //�÷��̾��� SpriteRenderer�� �޾ƿ´�.
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // �ӵ� �ʱ�ȭ
        Speed = 5.0f;

        // �ʱⰪ ����
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

        //�÷��̾� ������
        Movement = new Vector3(
        Hor * Time.deltaTime * Speed,
        Ver * Time.deltaTime * (Speed  * 0.5f),
        0.0f);

        transform.position += new Vector3(0.0f, Movement,y, 0.0f);

        // Hor�� 0�̶�� �����ִ� �����̹Ƿ� ����
        if(Hor != 0)
        Direction = Hor;

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            
        }


    }
}
