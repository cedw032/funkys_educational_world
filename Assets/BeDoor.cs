using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeDoor : MonoBehaviour
{
    private enum State { closed, open, closing, opening };
    private State state;

    public float openDuration;
    public float speed;
    public float bottom;

    private enum Direction { up = 1, down = -1 };

    private float openedAt = 0;

    private bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        state = State.closed;   
    }

    private void Update()
    {
        switch(this.state) {
            case State.closed:
                return;

            case State.open:
                bool isTimeToClose = Time.time - this.openedAt >= this.openDuration;
                if (isTimeToClose && !this.isColliding)
                {
                    this.state = State.closing;
                }
                return;

            case State.opening:
                this.Move(Direction.down);
                if (this.IsOpen()) 
                {
                    this.state = State.open;
                    this.openedAt = Time.time;
                }
                return;

            case State.closing:
                this.Move(Direction.up);
                if (this.IsClosed()) {
                    this.state = State.closed;
                }
                return;
        }
    }

    private void Move(Direction direction) {
        float deltaY = this.speed * (float)direction * Time.deltaTime;
        transform.Translate(new Vector3(0f, deltaY, 0f));
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            this.isColliding = true;
            if (!this.IsOpen()) {
                state = State.opening;
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            this.isColliding = false;   
        }
    }
       
    private bool IsOpen() 
    {
        return transform.localPosition.y <= this.bottom;
    }

    private bool IsClosed() 
    {
        return transform.localPosition.y >= 0;
    }
}
