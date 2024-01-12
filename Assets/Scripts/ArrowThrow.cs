using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowThrow : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int firstWaypointIndex = 0;
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if(Vector2.Distance(waypoints[1].transform.position, transform.position) < 0.1f){
            gameObject.SetActive(false);
            Invoke("reappearThrowingArrow", 1f);
        }
        transform.position = Vector2.MoveTowards(transform.position,waypoints[1].transform.position, Time.deltaTime*speed);
    }

    private void reappearThrowingArrow(){
        gameObject.SetActive(true);
        transform.position = waypoints[firstWaypointIndex].transform.position;
    }
}
