using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro Label;
    Vector2Int coordinates=new Vector2Int();
    WayPoint waypoint;

    void Awake()
    {
        Label = GetComponent<TextMeshPro>();
        Label.enabled = false;
        updatecoordinate();

        waypoint = GetComponentInParent<WayPoint>();
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            updatecoordinate();
            updateobjectname();
        }

        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Label.enabled = !Label.IsActive();
        }
    }


    void SetLabelColor()
    {
        if (waypoint.Isplaceable)
        {
            Label.color = defaultColor;
        }
        else
        {
            Label.color = blockedColor;
        }
    }


    void updatecoordinate()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/UnityEditor.EditorSnapSettings.move.z);

        Label.text = coordinates.x+","+coordinates.y;
    }

    void updateobjectname()
    {
        transform.parent.name = coordinates.ToString();
    }
}
