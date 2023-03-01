using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class WalkController : MonoBehaviour
{
    private Action onWalkStart;
    public static Action onWalkEnd;

    [SerializeField] 
    private float speed = 10f;

    private Coroutine moveCoroutine;

    private Rigidbody rb;
    private Animator animator;
    
    public void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
        onWalkStart += StartWalk;
        onWalkEnd += EndWalk;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            onWalkStart?.Invoke();
        }
    }

    private void StartWalk()
    {
        moveCoroutine = StartCoroutine(Moving());
        animator.SetBool("isMoving", true);
    }

    private IEnumerator Moving()
    {
        while (true)
        {
            rb.AddForce(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            yield return null;
        }
    }

    private void EndWalk()
    {
        StopCoroutine(moveCoroutine);
        animator.SetBool("isMoving", false);
    }

    private void OnDestroy()
    {
        onWalkStart -= StartWalk;
        onWalkEnd -= EndWalk;
    }
}
