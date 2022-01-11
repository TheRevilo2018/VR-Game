using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PDollarGestureRecognizer;

public class RuneDrawHand
{
    private ParticleSystem particles;

    ParticleSystem.MinMaxCurve defaultSpeed;
    ParticleSystem.EmissionModule module;

    List<Point> points = new List<Point>();
    Vector3 circleCenter;

    int strokeCount = 0;

    public bool Creating
    {
        get;
        protected set;
    }

    public RuneDrawHand(ParticleSystem part)
    {
        particles = part;

        module = particles.emission;
        defaultSpeed = module.rateOverTime;
        module.rateOverTime = 0;
    }

    public void activate(Vector3 circle)
    {
        circleCenter = circle;
    }

    public void startCreating(int stroke = 0)
    {
        points.Clear();
        Creating = true;
        strokeCount = stroke;
        module.rateOverTime = defaultSpeed;
    }

    public List<Point> stopCreating()
    {
        Creating = false;
        module.rateOverTime = 0;
        return points;
    }

    public void collectPoint()
    {
        if (Creating)
        {
            points.Add(new Point(getAngle(particles.transform), particles.transform.position.y - circleCenter.y,
                                strokeCount));
        }
    }

    float getAngle(Transform particle)
    {
        return Mathf.Atan((particle.position.x - circleCenter.x) / (particle.position.z - circleCenter.z));
    }
}
