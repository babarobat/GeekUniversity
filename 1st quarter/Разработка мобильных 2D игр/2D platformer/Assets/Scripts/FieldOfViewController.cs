using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    /// <summary>
    /// Содержит логику и параметры зрения персонажа
    /// </summary>
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class FieldOfViewController : BaseComponentController
    {
        /// <summary>
        /// Layer обьекта цель
        /// </summary>
        [SerializeField]
        [Tooltip("Layer обьекта, которого нужно обнаружить")]
        private LayerMask _targetLayerMask;
        /// <summary>
        /// Layer препятсвий для зрения
        /// </summary>
        [SerializeField]
        [Tooltip("Layer препятсвий для зрения")]
        private LayerMask _wallsMask;
        /// <summary>
        /// Качество меша.
        /// </summary>
        private const float _meshResolution = 1f;
        /// <summary>
        /// Радиус обзора
        /// </summary>
        [SerializeField]
        [Tooltip("Радиус обзора")]
        private float _viewRadious;
        /// <summary>
        /// Радиус обзора
        /// </summary>
        public float ViewRadius
        {
            get => _viewRadious;
            set => _viewRadious = value < 0 ? 0 : value; 
        }
        

        /// <summary>
        /// Угол обзора
        /// </summary>
        [SerializeField]
        [Tooltip("Угол обзора")]
        [Range(0, 360)]
        private float _viewAngle;
        /// <summary>
        /// ссылка на компонент MeshFilter
        /// </summary>
        private MeshFilter _viewMeshFilter;
        /// <summary>
        /// ссылка на компонент Mesh
        /// </summary>
        private Mesh _viewMesh;
        /// <summary>
        /// Скорость сканирования территории
        /// </summary>
        private const float _searchSpeed = 0.2f;

        //public Transform Test;
        public Transform Target { get; private set; }

        protected override void Start()
        {
            base.Start();
            _viewMeshFilter = GetComponent<MeshFilter>();
            _viewMesh = new Mesh() { name = "View mesh" };
            _viewMeshFilter.mesh = _viewMesh;
            //Test = Target;


            StartCoroutine(FindTargetWhithDelay(_searchSpeed));
        }
        private void Update()
        {
            //print(Target);
            //print(Test);
            DrawFieldOfView();
        }
        /// <summary>
        /// Возвращает напрваление ввиде Vector 2 относительно заданного угла
        /// </summary>
        /// <param name="angleDegrees">заданный угол</param>
        /// <param name="angleIsGlobal">заданный угол глобальный?</param>
        /// <returns></returns>
        public Vector2 DirFromAngle(float angleDegrees, bool angleIsGlobal)
        {
            var z = transform.rotation.eulerAngles.y == 180 ? -1 : 1;
            if (!angleIsGlobal)
            {
                angleDegrees += transform.eulerAngles.z;
            }
            return new Vector2(z * Mathf.Cos(angleDegrees * Mathf.Deg2Rad), Mathf.Sin(angleDegrees * Mathf.Deg2Rad));
        }
        /// <summary>
        /// Находит цель в поле зрения
        /// </summary>
        private void FindVisibleTarget()
        {
            Target = null;
            Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, _viewRadious, _targetLayerMask);
            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Transform target = targetsInViewRadius[i].transform;
                Vector2 dirToTarget = (target.position - transform.position).normalized;
                if (Vector2.Angle(transform.right, dirToTarget) < _viewAngle / 2)
                {
                    float distTotarget = Vector2.Distance(transform.position, target.position);
                    if (!Physics2D.Raycast(transform.position, dirToTarget, distTotarget, _wallsMask))
                    {
                        Target = target;

                    }
                    
                    
                }
            }
            
        }
        /// <summary>
        /// Обновляет данные о цели с заданной переодичностью
        /// </summary>
        /// <param name="delay">частота вызова метода</param>
        /// <returns></returns>
        IEnumerator FindTargetWhithDelay(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                FindVisibleTarget();

            }
        }
        /// <summary>
        /// Визульное отображение зрения персонажа при помощи Mesh
        /// </summary>
        void DrawFieldOfView()
        {
            int stepCount = Mathf.RoundToInt(_viewAngle * _meshResolution);
            float stepAngleSize = _viewAngle / stepCount;
            List<Vector3> viewPoints = new List<Vector3>();
            for (int i = 0; i < stepCount; i++)
            {

                float angle = transform.rotation.eulerAngles.z - _viewAngle / 2 + stepAngleSize * i;
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
                    if (transform.eulerAngles.y == 180)
                    {
                        
                        triangles[i * 3] = 0;
                        triangles[i * 3 + 1] = i + 1;
                        triangles[i * 3 + 2] = i + 2;
                    }
                    if (transform.eulerAngles.y == 0)
                    {
                        
                        triangles[i * 3] = 0;
                        triangles[i * 3 + 1] = i + 2;
                        triangles[i * 3 + 2] = i + 1;
                    }
                    
                    
                }
            }
            _viewMesh.Clear();
            _viewMesh.vertices = vertices;
            _viewMesh.triangles = triangles;
            _viewMesh.RecalculateNormals();
        }
        /// <summary>
        /// Запускает луч в напралении заданного угла и возвращает ViewCastInfo с информацией о попадании
        /// </summary>
        /// <param name="globalAngle"></param>
        /// <returns></returns>
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
                return new ViewCastInfo(false, transform.position + dir * _viewRadious, _viewRadious, globalAngle);
            }

        }
        /// <summary>
        /// Отображает в режиме редактора парамтры зрения 
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, ViewRadius);
            Vector3 viewAngleA = DirFromAngle(-_viewAngle / 2, false);

            Vector3 viewAngleB = DirFromAngle(_viewAngle / 2, false);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + viewAngleA * ViewRadius);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, transform.position + viewAngleB * ViewRadius);
        }
        public void LookAtTarget(Transform target)
        {
            
            if (target != null)
            {
                
                transform.right = target.position - transform.position;
            }
            
        }
        
        
    }
}