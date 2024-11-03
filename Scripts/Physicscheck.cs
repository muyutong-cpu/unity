using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("������")]
    public Vector2 bottomOffset;
    public float checkRaduis;
    public LayerMask groudLayer;
    public Vector2 leftOffset;
    public Vector2 rightOffset;

    [Header("״̬")]
    public bool onGround;
    public bool touchLeftwall;
    public bool touchRightwall;
    private void Update()
    {
        Check();
    }
    public void Check()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, checkRaduis, groudLayer);
        //������

        //���ǽ��
        touchLeftwall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, checkRaduis, groudLayer);
        touchRightwall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, checkRaduis, groudLayer);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, checkRaduis);                
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, checkRaduis);
    }
}
