using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const bool V = false;
    [SerializeField] private float speed; //velocidade do personagem
    [SerializeField] private float runSpeed; //velocidade da corrida

    private Rigidbody2D rig; //manipular a física

    private float inicialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private Vector2 direction_player; //direção do personagem

    public Vector2 Direction_anim //acessa os valores da variavel privada
    {
        get { return direction_player;}
        set { direction_player = value; }
    } 
    public bool isRunning //acessa os valores da variavel privada
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }
    public bool IsRolling //acessa os valores da variavel privada
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        inicialSpeed = speed; //guarda a valocidade inicial para fazer ele voltar para ela quando parar de correr
    }

    private void Update()
    {
        OnRolling();
        OnInput();
        OnRun();

    }

    private void FixedUpdate() //utilizar para quando for mexer com a fisica
    {
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        //pegas as direções x e y da movimentação
        direction_player = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        //move o personagem 
        rig.MovePosition(rig.position + direction_player * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) //pressionando o shift
        {
            speed = runSpeed;
            _isRunning = true;

        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) //soltando o shift
        {
            speed = inicialSpeed;
            _isRunning = false;
        }
    }
    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = V;
        }
    }
    #endregion
}
