using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialgue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    private int restIndexStart;
    private Animator anim; 

    void Start()
    {
        anim = GetComponent<Animator>();
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void Update() {
        if (Input.GetButtonDown("Jump")){
            StopAllCoroutines();
            textComponent.text = lines[index];
            Invoke("disappearingDialogueBox", 2f);
        }
    }

    void disappearingDialogueBox(){
        anim.SetTrigger("disappear");
    }

    void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }


    void EndDialogue(){
        Destroy(gameObject);
    }

    IEnumerator TypeLine(){
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            restIndexStart = index;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
