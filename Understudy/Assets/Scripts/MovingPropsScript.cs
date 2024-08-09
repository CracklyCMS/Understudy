using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPropsScript : MonoBehaviour
{
    public bool canMove;
    public float moveSpeed;
    public Vector3 pointA;
    public Vector3 pointB;

    public float xCord;

    IEnumerator Start()
    {
        pointA = transform.position;
        pointB = transform.position;
        pointB.x = xCord;
        while (canMove)
        {
            yield return StartCoroutine(Waiter());
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, moveSpeed));
            yield return StartCoroutine(Waiter());
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, moveSpeed));
        }
    }

    public IEnumerator BeginMovement()
    {
        canMove = true;
        while (canMove)
        {
            yield return StartCoroutine(Waiter());
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, moveSpeed));
            yield return StartCoroutine(Waiter());
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, moveSpeed));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
    }
}
