using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")] //cria um menu de opções no menu da unity
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();

}

[System.Serializable]
public class Sentences //frases pro npc
{
    public string actorName;
    public Sprite profile; 
    public Languages sentence;

}
[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR

[CustomEditor(typeof(DialogueSettings))]
public class BuiderEditor : Editor
{
    //sobrescreve o que esta dentro do metodo
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings ds = (DialogueSettings)target;
        Languages l = new Languages
        {
            portuguese = ds.sentence // toda vez que armazenar uma fala vai ser na lingua portuguesa
        };

        Sentences s = new Sentences
        {
            profile = ds.speakerSprite, // passa o sprite para o perfil
            sentence = l //passa a fala para o perfil
        };

        if (GUILayout.Button("Crate Dialogue"))
        {
            if (ds.sentence != "") //se tiver alguma fala 
            {
                ds.dialogues.Add(s); //adiciona um novo dialogo
                ds.speakerSprite = null;
                ds.sentence = "";
            }
        }
    }
}

#endif