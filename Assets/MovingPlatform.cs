using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] GameObject pointA;
    [SerializeField] GameObject pointB;
    [SerializeField] float speed = 10f;
    [SerializeField] float delay = 1f;
    [SerializeField] GameObject platform;

    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        platform.transform.position = pointA.transform.position;
        targetPos = pointB.transform.position;
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform() 
    {
        while (true) 
        {
            while ((targetPos - platform.transform.position).sqrMagnitude > 0.01f) 
            {
                platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetPos, speed * Time.deltaTime);
                yield return null;
            }

            targetPos = targetPos == pointA.transform.position ? pointB.transform.position : pointA.transform.position;
            yield return new WaitForSeconds(delay);
        }   
    }
}
