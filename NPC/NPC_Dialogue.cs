﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;
    public bool interaction;
    public DialogueSettings dialogue;

    private NPC_movement npcMovement;
    private bool hasTalked = false;

    bool PlayerHit;

    private List<string> sentences = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        GetNPCInfo();
    }
    //chamado a cada frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && PlayerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    void GetNPCInfo()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.instance.language)
            {
                case DialogueControl.idiom.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;
                
                case DialogueControl.idiom.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;
                
                case DialogueControl.idiom.spa:
                    sentences.Add(dialogue.dialogues[i].sentence.spanish);
                    break;
            }
            
        } 
    }
    //usado pela fisica
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null)
        {
            PlayerHit = true;
        }
        else
        {
            PlayerHit = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
