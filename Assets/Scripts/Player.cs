using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))]
public class Player : LivingEntity {

    public float moveSpeed = 5;

    public Crosshair crosshair;

    Camera viewCamera;
    PlayerController controller;
    GunController gunController;

    protected override void Start() {
        base.Start();
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;

    }

    void Update() {

        //Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        //Look input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.up * gunController.GunHeight);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance)) {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
            crosshair.transform.position = point;
            crosshair.DetectTargets(ray);
            if ((new Vector2(point.x, point.z) - new Vector2(transform.position.x, transform.position.z)).sqrMagnitude > 1) {
                gunController.Aim(point);
            }
        }

        //Weapon input

        if (Input.GetMouseButton(0)) {
            gunController.Shoot();
        }

    }
}
