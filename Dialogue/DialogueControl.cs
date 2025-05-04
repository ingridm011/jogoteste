using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj; //janela do dialogo
    public Image profileSprite; //sprite do perfil
    public Text speechText; //texto da fala
    public Text actorNameText; //nome do npc

    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    //variaveis de controle
    private bool isShowing; // se a janela está visivel
    private int index; //contar as sentenças 
    private string[] sentence;

    public static DialogueControl instance;

    //awake é chamado antes de todos os Start()
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }


    void Update()
    {

    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentence[index].ToCharArray()) //ler letra por letra
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //pular para proxima fala
    public void NextSentence()
    {

    }

    //chamar a fala do NPC
    public void Speech(string[] txt)
    {
        if (!isShowing) //ver se ta falando
        {
            dialogueObj.SetActive(true); //ativa a fala
            sentence = txt; //passa a fala para o sentence que esta na corrotina
            StartCoroutine(TypeSentence()); //inicia a corrotina 
            isShowing = true; //npc falando

        }
    }
}
