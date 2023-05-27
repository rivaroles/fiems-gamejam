using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class ClickMovement : MonoBehaviour
{
   [SerializeField]
   private InputAction mouseClickAction;
   [SerializeField]
   private float playerSpeed = 10f;

   private Camera mainCamera;
   private Coroutine coroutine;
   private Vector3 targetPosition;

   private CharacterController characterController;

   private void Awake() {
    mainCamera = Camera.main;
    characterController = GetComponent<CharacterController>();
   }

   private void OnEnable() {
    mouseClickAction.Enable();
    mouseClickAction.performed += Move;
   }

   private void OnDisable() {
    mouseClickAction.performed -= Move;
    mouseClickAction.Disable();
   }

   private void Move(InputAction.CallbackContext context) {
    Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
    if (Physics.Raycast(ray: ray, hitInfo: out RaycastHit hit) && hit.collider) {
        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(PlayerMoveTowards(hit.point));
    }
   }

   private IEnumerator PlayerMoveTowards(Vector3 target) {
    float playerDistanceToFloor = transform.position.y - target.y;
    target.y += playerDistanceToFloor;
    while (Vector3.Distance(transform.position, target) > 0.1f) {
        // Ignora colisão
        Vector3 destination = Vector3.MoveTowards(transform.position, target, playerSpeed * Time.deltaTime);
        transform.position = destination;
        yield return null;
    }
   }
}
