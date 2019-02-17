using System;
using UnityEngine;

namespace Game
{
    public static class Extensions
    {
        public static float Distance(Vector3 first, Vector3 second)
        {
            Vector3 heading;
            float distance;
            float distanceSquared;

            heading.x = first.x - second.x;
            heading.y = first.y - second.y;
            heading.z = first.z - second.z;

            distanceSquared = heading.x * heading.x + heading.y * heading.y + heading.z * heading.z;
            distance = Mathf.Sqrt(distanceSquared);
            return distance;
        }
        public static bool InRage(Vector3 first, Vector3 second, float range)
        {
            Vector3 heading;
            float distanceSquared;

            heading.x = first.x - second.x;
            heading.y = first.y - second.y;
            heading.z = first.z - second.z;

            distanceSquared = heading.x * heading.x + heading.y * heading.y + heading.z * heading.z;
            return distanceSquared <= range * range;
        }
        public static Vector3 DirectionFromAngle(float angleInDeg, float selfRotation = 0)
        {
            var angleInRad = (angleInDeg + selfRotation) * Mathf.Deg2Rad;
            return new Vector3(Mathf.Sin(angleInRad), 0, Mathf.Cos(angleInRad));
        }
    }
}
    
