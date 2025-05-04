using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>(); //acessa valor da direção do player
        anim = GetComponent<Animator>(); //acessa valor da direção de transição colocado na animação
    }

    // Update is called once per frame
    void Update()
    {
        //se o player tiver ativa a animação de andar se não ativa a animação de idle 
        OnMove();
        OnRun();
    }

    #region Movement
    void OnMove()
    {
        if (player.Direction_anim.sqrMagnitude > 0) //ver se ta se movimentando
        {
            if (player.IsRolling) //ver se esta rolando se tiver coloca transition pra 3 = rolando
            {
                anim.SetTrigger("isRoll");
            }
            else // se não coloca pra 1 = andando
            {
                anim.SetInteger("transition", 1);
            }
        }
        else //se não for nehum dos dois coloca pra 0 = parado
        {
            anim.SetInteger("transition", 0);
        }

        if (player.Direction_anim.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.Direction_anim.x < 0)
        {
            //Rotaciona para o boneco não andar para tras
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnRun()
    {
        if (player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }

    }

    #endregion
}
