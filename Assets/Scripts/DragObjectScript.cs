using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectScript : MonoBehaviour
{

    private Vector3 m_Offset;

    void OnMouseDown()
    {
        m_Offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        Vector3 pos = GetMouseWorldPosition() + m_Offset;
        transform.position = LimitedPlane(pos);
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 0;
        mousePoint = Camera.main.ScreenToWorldPoint(mousePoint);
        mousePoint.z = 0;
        return mousePoint;
    }

    public Vector3 LimitedPlane(Vector3 mousePos)
    {
        if (GameManager.stageNumber >= 1 && GameManager.stageNumber <= 4)
        {
            if (mousePos.x < -8.1)
            {
                mousePos.x = -8.1f;
                if (mousePos.y < -3.75)
                {
                    mousePos.y = -3.75f;
                }
                else if (mousePos.y > 3.75)
                {
                    mousePos.y = 3.75f;
                }
            }
            else if (mousePos.x > 0.2)
            {
                mousePos.x = 0.2f;
                if (mousePos.y < -3.75)
                {
                    mousePos.y = -3.75f;
                }
                else if (mousePos.y > 3.75)
                {
                    mousePos.y = 3.75f;
                }
            }
            else if (mousePos.y > 3.75)
            {
                mousePos.y = 3.75f;
                if (mousePos.x < -8.1)
                {
                    mousePos.x = -8.1f;
                }
                else if (mousePos.x > 0.2)
                {
                    mousePos.x = 0.2f;
                }
            }
            else if (mousePos.y < -3.75)
            {
                mousePos.y = -3.75f;
                if (mousePos.x < -8.1)
                {
                    mousePos.x = -8.1f;
                }
                else if (mousePos.x > 0.2)
                {
                    mousePos.x = 0.2f;
                }
            }
        }
        else if (GameManager.stageNumber >= 5 && GameManager.stageNumber <= 8)
        {
            if (mousePos.x < -7.95)
            {
                mousePos.x = -7.95f;
                if (mousePos.y < -3.84)
                {
                    mousePos.y = -3.84f;
                }
                else if (mousePos.y > 3.84)
                {
                    mousePos.y = 3.84f;
                }
            }
            else if (mousePos.x > -4.57)
            {
                mousePos.x = -4.57f;
                if (mousePos.y < -3.84)
                {
                    mousePos.y = -3.84f;
                }
                else if (mousePos.y > 3.84)
                {
                    mousePos.y = 3.84f;
                }
            }
            else if (mousePos.y > 3.84)
            {
                mousePos.y = 3.84f;
                if (mousePos.x < -7.95)
                {
                    mousePos.x = -7.95f;
                }
                else if (mousePos.x > -4.57)
                {
                    mousePos.x = -4.57f;
                }
            }
            else if (mousePos.y < -3.84)
            {
                mousePos.y = -3.84f;
                if (mousePos.x < -7.95)
                {
                    mousePos.x = -7.95f;
                }
                else if (mousePos.x > -4.57)
                {
                    mousePos.x = -4.57f;
                }
            }
        }
        else if (GameManager.stageNumber >= 9 && GameManager.stageNumber <= 12)
        {
            if (mousePos.x < -3.57)
            {
                mousePos.x = -3.57f;
                if (mousePos.y < -1.7)
                {
                    mousePos.y = -1.7f;
                }
                else if (mousePos.y > 1.7)
                {
                    mousePos.y = 1.7f;
                }
            }
            else if (mousePos.x > 4.24)
            {
                mousePos.x = 4.24f;
                if (mousePos.y < -1.7)
                {
                    mousePos.y = -1.7f;
                }
                else if (mousePos.y > 1.7)
                {
                    mousePos.y = 1.7f;
                }
            }
            else if (mousePos.y > 1.7)
            {
                mousePos.y = 1.7f;
                if (mousePos.x < -3.57)
                {
                    mousePos.x = -3.57f;
                }
                else if (mousePos.x > 4.24)
                {
                    mousePos.x = 4.24f;
                }
            }
            else if (mousePos.y < -1.7)
            {
                mousePos.y = -1.7f;
                if (mousePos.x < -3.57)
                {
                    mousePos.x = -3.57f;
                }
                else if (mousePos.x > 4.24)
                {
                    mousePos.x = 4.24f;
                }
            }
        }
        else if (GameManager.stageNumber >= 13 && GameManager.stageNumber <= 14)
        {
            if (mousePos.x < -8.76)
            {
                mousePos.x = -8.76f;
                if (mousePos.y < -4.04)
                {
                    mousePos.y = -4.04f;
                }
                else if (mousePos.y > 4.04)
                {
                    mousePos.y = 4.04f;
                }
            }
            else if (mousePos.x > -3.48)
            {
                mousePos.x = -3.48f;
                if (mousePos.y < -4.04)
                {
                    mousePos.y = -4.04f;
                }
                else if (mousePos.y > 4.04)
                {
                    mousePos.y = 4.04f;
                }
            }
            else if (mousePos.y > 4.04)
            {
                mousePos.y = 4.04f;
                if (mousePos.x < -8.76)
                {
                    mousePos.x = -8.76f;
                }
                else if (mousePos.x > -3.48)
                {
                    mousePos.x = -3.48f;
                }
            }
            else if (mousePos.y < -4.04)
            {
                mousePos.y = -4.04f;
                if (mousePos.x < -8.76)
                {
                    mousePos.x = -8.76f;
                }
                else if (mousePos.x > -3.48)
                {
                    mousePos.x = -3.48f;
                }
            }
        }
        return mousePos;
    }
}

