using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; //velocidade do personagem
    private Rigidbody2D rig; //manipular a física
    private Vector2 direction; //direção do personagem

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //pegas as direções x e y da movimentação
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    //utilizar para quando for mexer com a fisica
    private void FixedUpdate()
    {
        //move o personagem 
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
    }
}
