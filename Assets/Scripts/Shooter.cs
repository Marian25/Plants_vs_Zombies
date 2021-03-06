﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    private void Start()
    {
        animator = FindObjectOfType<Animator>();

        // Create a parent if necessary
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent) {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerAheadInLane()) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
    }

    // Look through all spawners, and set myLaneSpawner if found
    private void SetMyLaneSpawner() {
        Spawner[] allSpawners = FindObjectsOfType<Spawner>();

        foreach(Spawner thisSpawner in allSpawners) {
            if (Mathf.Abs(thisSpawner.transform.position.y - transform.position.y) < 0.00001f) {
                myLaneSpawner = thisSpawner;
                return;
            }
        }

        Debug.LogError(name + "can't find spawner in lane");
    }

    private bool IsAttackerAheadInLane() {
        // Exit if no attackers in lane
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        }

        // If there are attackers, are they ahead?
        foreach(Transform attacker in myLaneSpawner.transform) {
            if (attacker.transform.position.x > transform.position.x) {
                return true;
            }
        }

        // Attacker in lane, but behind
        return false;
    }

    private void Fire() {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
