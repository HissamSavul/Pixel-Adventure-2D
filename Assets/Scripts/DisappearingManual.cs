using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingManual : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D coll) {
        Invoke("DestrouManualScreen", 10f);
    }

    private void DestrouManualScreen(){
        Destroy(gameObject);
    }
}
