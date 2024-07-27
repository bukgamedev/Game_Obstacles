using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    public Vector3[] Points;
    public int Point_Number = 0;
    private Vector3 Current_Target;
    public float tolerance;
    public float speed;
    public float Delay_Time;
    private float delay_Start;
    public bool automatic;
    public void Start()
    {
        if (Points.Length > 0)
        {
            Current_Target = Points[0];
        }
        tolerance = speed * Time.deltaTime;
    }
    public void Update()
    {
        if (transform.position != Current_Target)
        {
            MovePlatform();
        }
        else
        {
            UpdateTarget();
        }
    }
    void MovePlatform()
    {
        Vector3 heading = Current_Target - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if (heading.magnitude < tolerance)
        {
            transform.position = Current_Target;
            delay_Start = Time.time;
        }
    }
    void UpdateTarget()
    {
        if (automatic)
        {
            if (Time.time - delay_Start > Delay_Time)
            {
                NextPlatform();
            }
        }
    }
    void NextPlatform()
    {
        Point_Number++;
        if (Point_Number >= Points.Length)
        {
            Point_Number = 0;
        }
        Current_Target = Points[Point_Number];
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform; //Eðer karakter box collider'a girerse karakteri bu objenin child'ý yap.
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
