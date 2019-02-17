using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Game;

namespace Game
{
    [CustomEditor(typeof(Enemy))]
    public class EnemyEditor : Editor
    {
        private void OnSceneGUI()
        {
            Enemy enemy = (Enemy)target;
            Handles.color = Color.white;
            Handles.DrawWireArc(enemy.transform.position, Vector3.up, Vector3.forward, 360, enemy.AgroRange);
            Vector3 viewAngleA = Extensions.DirectionFromAngle(-enemy.ViewAngle / 2, enemy.transform.localEulerAngles.y);
            Vector3 viewAngleB = Extensions.DirectionFromAngle(enemy.ViewAngle / 2, enemy.transform.localEulerAngles.y);

            Handles.DrawLine(enemy.transform.position, enemy.transform.position + viewAngleA * enemy.AgroRange);
            Handles.DrawLine(enemy.transform.position, enemy.transform.position + viewAngleB * enemy.AgroRange);

        }
        
    }
}

