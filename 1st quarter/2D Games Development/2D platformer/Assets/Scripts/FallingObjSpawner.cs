
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Game
{
    class FallingObjSpawner:MonoBehaviour
    {
        [SerializeField]
        int _prefabsCount;
        [SerializeField]
        bool randomizeSprites;
        [SerializeField]
        bool _randomizePos;


        
        [SerializeField]
        private Sprite[] _sprites;
        [SerializeField]
        [Range(0,100)]
        private float _spawnerSizeX;
        [SerializeField]
        [Range(0, 100)]
        private float _spawnerSizeY;
        
        [SerializeField]
        private FallingObj brickPrefab;
        private FallingObj[] _objs;

        private void Start()
        {
            FindObjectOfType<Game.Controllers.Boss>().OnGrounded += DropBriks;
        }
        void DropBriks()
        {
            for (int i = 0; i < _prefabsCount; i++)
            {
                var x = Random.Range(transform.position.x - _spawnerSizeX / 2, transform.position.x + _spawnerSizeX / 2);
                var y = Random.Range(transform.position.y - _spawnerSizeX / 2, transform.position.y + _spawnerSizeX / 2);
                var spawnPos = new Vector2(x, y);
                var brick = Instantiate(brickPrefab, spawnPos, Quaternion.identity);
                Destroy(brick, 2f);

            }
        }
        private void OnDrawGizmosSelected()
        {
            var A = new Vector2(transform.position.x - _spawnerSizeX / 2, transform.position.y - _spawnerSizeY / 2);
            var B = new Vector2(transform.position.x + _spawnerSizeX / 2, transform.position.y + _spawnerSizeY / 2);
            Gizmos.DrawLine(A, new Vector2(B.x, A.y));
            Gizmos.DrawLine(A, new Vector2(A.x, B.y));
            Gizmos.DrawLine(B, new Vector2(B.x, A.y));
            Gizmos.DrawLine(B, new Vector2(A.x, B.y));

        }
    }
}
