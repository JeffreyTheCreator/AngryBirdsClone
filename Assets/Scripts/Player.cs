using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb; 
    public Rigidbody2D hook;
    public float releasTime = 0.15f;
    public float maxDragDistance = 2f;
    public GameObject nextBirdPrefab;
    private bool isPressed = false;

  
    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance) {
            
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;

            } else
            {
                rb.position = mousePos;
            }
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());

    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releasTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        // TODO nächsten vogel anlegen

    }

}