using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateIguana : MonoBehaviour
{
    //public BoxCollider boxCollider;
    public List<Vector3> posPoints;
    public float speed;
    Animator iguanaAnimator;
    int i = 0;
    bool moveUp = false;
    bool moveDown = false;

    private void Start()
    {
        iguanaAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (i < posPoints.Count && moveUp)
        {
            iguanaAnimator.SetBool("MoveFoward", true);
            iguanaAnimator.SetBool("MoveBack", false);
            Vector3 partialPoint = Vector3.MoveTowards(transform.localPosition, posPoints[i], speed);
            transform.localPosition = partialPoint;
            Debug.Log(partialPoint);
            if (Vector3.Distance(transform.localPosition, posPoints[i]) < 0.1f) i++;
        }
        else if (i > -1 && moveDown)
        {
            iguanaAnimator.SetBool("MoveBack", true);
            iguanaAnimator.SetBool("MoveFoward", false);
            Vector3 partialPoint = Vector3.MoveTowards(transform.localPosition, posPoints[i], speed);
            transform.localPosition = partialPoint;
            Debug.Log(partialPoint);
            if (Vector3.Distance(transform.localPosition, posPoints[i]) < 0.1f) i--;
        }
        else
        {
            iguanaAnimator.SetBool("MoveFoward", false);
            iguanaAnimator.SetBool("MoveBack", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            i++;
            moveUp = true;
            moveDown = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            i--;
            moveUp = false;
            moveDown = true;
        }
    }
}
