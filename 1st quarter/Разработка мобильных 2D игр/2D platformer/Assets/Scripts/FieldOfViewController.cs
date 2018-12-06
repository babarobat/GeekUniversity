using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    class FieldOfViewController:BaseComponentController
    {
        public LayerMask _targetLayerMask;
        public LayerMask _wallsMask;
        public float _viewRadious;

        public Transform Target;
        public float _meshResolution;

        [Range(0,360)]
        public float _viewAngle;

        public MeshFilter _viewMeshFilter;
        private Mesh _viewMesh;
        private float _searchSpeed = 1;
        
        private void Start()
        {
            _viewMesh = new Mesh() { name = "View mesh" };
            _viewMeshFilter.mesh = _viewMesh;

           
            StartCoroutine(FindTargetWhithDelay(0.2f));
        }
        private void Update()
        {
            DrawFieldOfView();
        }
        public Vector2 DirFromAngle(float angleDegrees, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
            {
                var z = transform.rotation.eulerAngles.y == 180 ? -1 : 1;
                angleDegrees += transform.eulerAngles.z*z +  transform.eulerAngles.y;
            }
            return new Vector2(Mathf.Cos(angleDegrees * Mathf.Deg2Rad), Mathf.Sin(angleDegrees * Mathf.Deg2Rad));
        }
        private void FindVisibleTargets()
        {
            Target = null;
            Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, _viewRadious, _targetLayerMask);
            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Transform target = targetsInViewRadius[i].transform;
                Vector2 dirToTarget = (target.position - transform.position).normalized;
                if (Vector2.Angle(transform.right,dirToTarget)<_viewAngle/2)
                {
                    float distTotarget = Vector2.Distance(transform.position, target.position);
                    if (!Physics2D.Raycast(transform.position,dirToTarget,distTotarget, _wallsMask))
                    {
                        Target = target;
                    }
                }
            }
        }

        IEnumerator FindTargetWhithDelay(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                FindVisibleTargets();
                
            }
        }
        void DrawFieldOfView()
        {
            int stepCount = Mathf.RoundToInt(_viewAngle * _meshResolution);
            float stepAngleSize = _viewAngle / stepCount;
            List<Vector3> viewPoints = new List<Vector3>();
            for (int i = 0; i < stepCount; i++)
            {
                var z = transform.rotation.eulerAngles.y == 180 ? -1 : 1;
                float angle = z*transform.rotation.eulerAngles.z + transform.rotation.eulerAngles.y - _viewAngle / 2 + stepAngleSize * i;
                ViewCastInfo viewCastInfo = ViewCast(angle);
                viewPoints.Add(viewCastInfo.point);
            }
            int vertexCount = viewPoints.Count + 1;
            Vector3[] vertices = new Vector3[vertexCount];
            int[] triangles = new int[(vertexCount - 2) * 3];
            vertices[0] = Vector3.zero;

            for (int i = 0; i < vertexCount - 1; i++)
            {
                vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);
                if (i < vertexCount - 2)
                {
                    triangles[i * 3] = 0;
                    triangles[i * 3 + 1] = i + 2;
                    triangles[i * 3 + 2] = i + 1;
                }
            }


            _viewMesh.Clear();
            _viewMesh.vertices = vertices;
            _viewMesh.triangles = triangles;
            _viewMesh.RecalculateNormals();
        }
        ViewCastInfo ViewCast(float globalAngle)
        {
            Vector3 dir = DirFromAngle(globalAngle, true);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, _viewRadious, _wallsMask);
            if (hit)
            {
                return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
            }
            else
            {
                return new ViewCastInfo(false, transform.position +dir*_viewRadious, _viewRadious, globalAngle);
            }

        }

        public struct ViewCastInfo
        {
            public bool hit;
            public Vector3 point;
            public float dst;
            public float angle;

            public ViewCastInfo(bool hit, Vector3 point, float dst, float angle)
            {
                this.hit = hit;
                this.point = point;
                this.dst = dst;
                this.angle = angle;

            }
        }
        public void LookAtTarget(Transform target)
        {
            transform.right = target.position - transform.position;
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Clamp(transform.eulerAngles.z, 0, 270));
            //GetComponent<Animator>().SetBool("Patroling", false);

        }
        public void SearchTarget()
        {
            GetComponent<Animator>().SetBool("Patroling", true);

        }
    }
}
