using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingDialogueBox : MonoBehaviour
{
    [SerializeField] private GameObject DBox;
    private int numTimesAppear = 1;
    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.CompareTag("Player") && numTimesAppear == 1){
            DBox.SetActive(true);
            DBox.gameObject.GetComponent<Animator>().SetTrigger("appear");
            numTimesAppear--;
        }
    }
}
