using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformerAppear : MonoBehaviour
{
    [SerializeField] private GameObject[] fallingPlatfroms;
    private void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.CompareTag("Player")){
            for (int i = 0; i < fallingPlatfroms.Length; i++)
            {
                fallingPlatfroms[i].gameObject.SetActive(true);
            }
        }
    }
}
