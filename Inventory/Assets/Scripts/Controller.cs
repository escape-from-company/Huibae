using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_RB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float fMoveHorizontal = Input.GetAxis("Horizontal");
        float fMoveVertical = Input.GetAxis("Vertical");

        Vector3 vMove = new Vector3(fMoveHorizontal, 0.0f, fMoveVertical);

        m_RB.AddForce(vMove * m_Speed);
    }

    public float m_Speed;

    private Rigidbody m_RB;
}
