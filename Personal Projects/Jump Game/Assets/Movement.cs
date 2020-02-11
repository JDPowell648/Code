using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 mousePos;
    private LineRenderer LineRender;
    private Rigidbody2D rbody;
    [SerializeField] private LayerMask layers;

    private enum mouseDatas
    {
        inRange, drawing, notInRange, neutral
    }

    private enum jumpStates
    {
        grounded, jumpedOnce, jumpedTwice, neutral
    }

    [SerializeField] mouseDatas mouseData;
    [SerializeField] jumpStates jumpState;
    void Start()
    {
        LineRender = GetComponent<LineRenderer>();
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);
        manageMouse();
        isGrounded();
        if (Input.GetMouseButton(0) && (jumpState == jumpStates.grounded || jumpState == jumpStates.jumpedOnce))
        {
            if (mouseData == mouseDatas.inRange)
            {
                mouseData = mouseDatas.drawing;
            }
        }
        else
        {
            mouseData = mouseDatas.neutral;
        }
        if (mouseData == mouseDatas.drawing)
        {
            drawLine();
        }
        if (Input.GetMouseButtonUp(0))
        {
            move();
        }
    }

    private void drawLine()
    {
        LineRender.SetPosition(0, transform.position);
        LineRender.SetPosition(1, mousePos);
    }

    private void manageMouse()
    {
        if (Vector3.Distance(mousePos, transform.position) <= .1f || Vector3.Distance(mousePos, LineRender.GetPosition(1)) <= .05f)
        {
            mouseData = mouseDatas.inRange;
        }
        else if(mouseData != mouseDatas.drawing)
        {
            mouseData = mouseDatas.notInRange;
        }
    }

    private void move()
    {
        if (jumpState == jumpStates.jumpedOnce)
        {
            jumpState = jumpStates.jumpedTwice;
        }
        else if (jumpState != jumpStates.jumpedOnce && jumpState != jumpStates.jumpedTwice)
        {
            jumpState = jumpStates.jumpedOnce;
        }
        Vector2 dir = LineRender.GetPosition(0) - LineRender.GetPosition(1);
        rbody.AddForce(dir * 10);
        LineRender.SetPosition(0, new Vector3());
        LineRender.SetPosition(1, new Vector3());
        mouseData = mouseDatas.neutral;
    }

    private void isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .2f, layers);
        Debug.DrawRay(transform.position, Vector2.down * .2f, Color.blue);
        if(hit.collider != null)
        {
            jumpState = jumpStates.grounded;
        }
        else if(jumpState != jumpStates.jumpedTwice)
        {
            jumpState = jumpStates.jumpedOnce;
        }
    }
}
