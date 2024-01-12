using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{   [SerializeField] private Text _text;
    
    void Start()
    {
        StartBlink();
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            switch (_text.color.a.ToString())
            {
                case "0":
                    _text.color = new Color(_text.color.r,_text.color.g,_text.color.b, 1);
                    yield return new WaitForSeconds(0.5f);
                    break;
                case "1":
                    _text.color = new Color(_text.color.r,_text.color.g,_text.color.b, 0);
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }

    private void StartBlink()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }
}
