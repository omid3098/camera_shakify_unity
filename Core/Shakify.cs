using UnityEngine;
namespace Shakfy.Core
{
    public class Shakify : MonoBehaviour
    {
        // Reads data from ScriptableShakeData and applies it to the object
        [SerializeField] private ScriptableShakeData _shakeData;
        [SerializeField] float speed = 1f;
        [SerializeField] float strenght = 1f;
        private int lastTime;
        private Vector3 lastPosition;
        private Quaternion lastRotation;

        private void Awake()
        {
            // get the last frame of the animation
            lastTime = _shakeData.PosX.keys.Length - 1;
            lastPosition = Vector3.zero;
            lastRotation = Quaternion.identity;
        }
        private void Update()
        {
            // calculate the modulo so if time passes the lastTime of the animation it will loop back to the first time
            var time = (Time.time * _shakeData.FPS * speed) % lastTime;

            // add shakedata to the current position and rotation of the object
            // First more back to the last position
            transform.localPosition -= lastPosition;
            lastPosition = new Vector3(
                _shakeData.PosX.Evaluate(time) * strenght,
                _shakeData.PosY.Evaluate(time) * strenght,
                _shakeData.PosZ.Evaluate(time) * strenght
            );
            // move to the next position
            transform.localPosition += lastPosition;

            // rotate back to previous rotation
            transform.localRotation *= Quaternion.Inverse(lastRotation);
            lastRotation = Quaternion.Euler(
                _shakeData.RotX.Evaluate(time) * strenght,
                _shakeData.RotY.Evaluate(time) * strenght,
                _shakeData.RotZ.Evaluate(time) * strenght
            );
            // rotate to the next rotation
            transform.localRotation *= lastRotation;
        }
    }
}