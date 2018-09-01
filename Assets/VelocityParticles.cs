﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class VelocityParticles : MonoBehaviour
{
    private Rigidbody2D rb;

    private ParticleSystem ps;
    private ParticleSystem.MainModule mm;
    private ParticleSystem.EmissionModule em;

    public float minVelocity, maxVelocity;
    public float minEmission, maxEmission;
    public float minSize, maxSize;
    public float minLifeTime, maxLifeTime;

    public bool play;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
        mm = ps.main;
        em = ps.emission;
    }
	
	// Update is called once per frame
	void Update () {
        if (play && !ps.isPlaying)
        {
            ps.Play();
        } else if (!play && ps.isPlaying)
        {
            ps.Stop();
        }

        float velocity = rb.velocity.magnitude;

        em.rate = Util.ConvertScale(minVelocity, maxVelocity, minEmission, maxEmission, velocity);
        ps.startSize = Util.ConvertScale(minVelocity, maxVelocity, minSize, maxSize, velocity);
        ps.startLifetime = Util.ConvertScale(minVelocity, maxVelocity, minLifeTime, maxLifeTime, velocity);
    }
}