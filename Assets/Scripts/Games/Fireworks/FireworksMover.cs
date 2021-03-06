using UniRx;
using UnityEngine;

namespace Fireworks
{
    public class FireworksMover : MonoBehaviour
    {
        [SerializeField] private FireworksCore core;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float speed;

        private void Start()
        {
            core.IsExploded.Subscribe(_ => { speed = 0; }).AddTo(this);
        }

        private void FixedUpdate()
        {
            var pos = _rigidbody2D.position;
            pos.x -= speed * Time.fixedDeltaTime;
            _rigidbody2D.position = pos;
        }
    }
}