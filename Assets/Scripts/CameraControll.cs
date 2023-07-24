using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Vector3 targetPosition;
    public float moveSpeed = 0.125f;

    public GameObject firstPart;
    public GameObject secondPart;
    public GameObject maincamera;

    private bool isMoving = false;

    void Update()
    {

        if (secondPart.activeSelf == true)
        {
            StartCoroutine(MoveToTarget());
        }
    }

    IEnumerator MoveToTarget()
    {
        isMoving = true;

        targetPosition = new Vector3(-26, 16, 15);

        float distance = Vector3.Distance(maincamera.transform.position, targetPosition);

        while (distance > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            distance = Vector3.Distance(transform.position, targetPosition);

            yield return null;
        }

        transform.position = targetPosition;

        isMoving = false;
    }
}
