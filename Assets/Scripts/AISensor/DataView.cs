using UnityEngine;

[System.Serializable]
public class DataView : DataViewBase
{
    public LayerMask occlusionlayers;

    public DataView()
    {

    }

    public override bool IsInSight(Transform obj)
    {
        if (obj == null) return false;

        // Check height
        Vector3 origin = Owner.transform.position;
        Vector3 dest = obj.transform.position;
        Vector3 direction = dest - origin;

        if (direction.y < 0 || direction.y > height)
            return false;

        // Check angle
        direction.y = 0;
        float deltaAngle = Vector3.Angle(direction, Owner.transform.forward);

        if (deltaAngle > angle)
            return false;

        // Check obstacle
        origin.y += height / 2;
        dest.y = origin.y;

        if (Physics.Linecast(origin, dest, occlusionlayers, QueryTriggerInteraction.Ignore))
            return false;

        return true;
    }
}
