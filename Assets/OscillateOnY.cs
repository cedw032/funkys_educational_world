using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillateOnY : MonoBehaviour
{
    public float amplitude;
    public float period;
    
    private Vector3 start;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        offset = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time == 0) { return; }

        float offset = this.amplitude * Mathf.Sin(Time.time * 2.0f * Mathf.PI / this.period);
        this.offset.y = offset;
        transform.position = this.start + this.offset;
    }
}
