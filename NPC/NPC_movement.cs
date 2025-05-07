using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_movement : MonoBehaviour
{
    public float speed;

    private int index;
    private float initialSpeed;
    private Animator anim;

    public List<Transform> paths = new List<Transform>();


    private void Start()
    {
        initialSpeed = speed;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (DialogueControl.instance.isShowing)
        {
            speed = 0f;
            anim.SetBool("isWalking", false);
        }

        else
        {
            speed = initialSpeed;
            anim.SetBool("isWalking", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime); // manda ele mover para o proximo path

        if (Vector2.Distance(transform.position, paths[index].position) < 0.1f) //verifica  se ta na area do path
        {
            if (index < paths.Count - 1) //verifica se ainda tem paths pro npc ir 
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }

        Vector2 direction = paths[index].position - transform.position; // se tive na direita retona o valor positivo

        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

}
