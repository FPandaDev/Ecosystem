using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensor : MonoBehaviour
{
    [Header("Sensor Settings")]
    public bool isViewGizmo;
    [Range(5f, 180f)] public float angle = 60f;
    public float distance = 30f;
    public float height = 1.0f;

    public Color meshColor = Color.red;

    public int scanFrequency = 30;
    public LayerMask layers;
    public LayerMask obstacle;

    //private List<GameObject> listObjects = new List<GameObject>();

    protected Collider[] colliders = new Collider[50];
    protected Mesh mesh;
    protected Animal animal;

    protected int count;
    protected float scanInterval;
    protected float scanTimer;

    public virtual void LoadComponent()
    {
        scanInterval = 1.0f / scanFrequency;
        animal = GetComponent<Animal>();
    }

    public virtual void Execute()
    {
        scanTimer -= Time.deltaTime;
        if (scanTimer < 0)
        {
            scanTimer += scanInterval;
            Scan();
        }
    }

    public virtual void Scan()
    {
        //count = Physics.OverlapSphereNonAlloc(transform.position, distance, colliders, layers, QueryTriggerInteraction.Collide);

        //listObjects.Clear();

        //for (int i = 0; i < count; ++i)
        //{
        //    GameObject obj = colliders[i].gameObject;

        //    if (IsInSight(obj))
        //    {
        //        listObjects.Add(obj);
        //    }
        //}
    }

    public virtual void CheckObjects(GameObject obj)
    {

    }

    public virtual bool IsInSight(GameObject obj)
    {
        // Check same obj
        if (obj.GetInstanceID() == this.gameObject.GetInstanceID())
            return false;

        // Check height
        Vector3 origin = transform.position;
        Vector3 dest = obj.transform.position;
        Vector3 direction = dest - origin;

        if (direction.y < -0.5f || direction.y > height)
            return false;

        // Check angle
        direction.y = 0;
        float deltaAngle = Vector3.Angle(direction, transform.forward);

        if (deltaAngle > angle)
            return false;

        // Check obstacle
        origin.y += height / 2;
        dest.y = origin.y;

        if (Physics.Linecast(origin, dest, obstacle, QueryTriggerInteraction.Ignore))
            return false;

        return true;
    }

    public virtual Mesh CreateWedgeMesh()
    {
        Mesh _mesh = new Mesh();

        int segments = 10;
        int numTriangles = (segments * 4) + 2 + 2;
        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;
        Vector3 bottomRight = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

        Vector3 topCenter = bottomCenter + Vector3.up * height;
        Vector3 topRight = bottomRight + Vector3.up * height;
        Vector3 topLeft = bottomLeft + Vector3.up * height;

        int vert = 0;

        // left side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomLeft;
        vertices[vert++] = topLeft;

        vertices[vert++] = topLeft;
        vertices[vert++] = topCenter;
        vertices[vert++] = bottomCenter;

        // right side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = topCenter;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = bottomRight;
        vertices[vert++] = bottomCenter;

        float currentAngle = -angle;
        float deltaAngle = (angle * 2) / segments;

        for (int i = 0; i < segments; ++i)
        {
            bottomLeft = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * distance;
            bottomRight = Quaternion.Euler(0, currentAngle + deltaAngle, 0) * Vector3.forward * distance;

            topRight = bottomRight + Vector3.up * height;
            topLeft = bottomLeft + Vector3.up * height;

            // far side
            vertices[vert++] = bottomLeft;
            vertices[vert++] = bottomRight;
            vertices[vert++] = topRight;

            vertices[vert++] = topRight;
            vertices[vert++] = topLeft;
            vertices[vert++] = bottomLeft;

            // top
            vertices[vert++] = topCenter;
            vertices[vert++] = topLeft;
            vertices[vert++] = topRight;

            // bottom
            vertices[vert++] = bottomCenter;
            vertices[vert++] = bottomRight;
            vertices[vert++] = bottomLeft;

            currentAngle += deltaAngle;
        }

        for (int i = 0; i < numVertices; ++i)
        {
            triangles[i] = i;
        }

        _mesh.vertices = vertices;
        _mesh.triangles = triangles;
        _mesh.RecalculateNormals();

        return _mesh;
    }

    private void OnValidate()
    {
        mesh = CreateWedgeMesh();
        scanInterval = 1.0f / scanFrequency;
    }

    private void OnDrawGizmos()
    {
        if (!isViewGizmo) { return; }

        if (mesh)
        {
            Gizmos.color = meshColor;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }

        Gizmos.DrawWireSphere(transform.position, distance);
        //for (int i = 0; i < count; ++i)
        //{
        //    Gizmos.DrawSphere(colliders[i].transform.position, 0.2f);
        //}

        //Gizmos.color = Color.green;
        //foreach (var obj in listObjects)
        //{
        //    Gizmos.DrawSphere(obj.transform.position, 0.2f);
        //}
    }
}
