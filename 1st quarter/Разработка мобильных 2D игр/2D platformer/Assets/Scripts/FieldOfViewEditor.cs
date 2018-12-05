using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Game.Controllers;

namespace Game
{
    [CustomEditor(typeof(FieldOfViewController))]
    class FieldOfViewEditor : Editor
    {
        private void OnSceneGUI()
        {
            FieldOfViewController fow = (FieldOfViewController)target;
            Handles.color = Color.white;
            Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.up,360,fow._viewRadious);
            Vector3 viewAngleA = fow.DirFromAngle(-fow._viewAngle / 2, false);
            Vector3 viewAngleB = fow.DirFromAngle(fow._viewAngle / 2, false);
            Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow._viewRadious);
            Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow._viewRadious);

        }
       
    }
}
