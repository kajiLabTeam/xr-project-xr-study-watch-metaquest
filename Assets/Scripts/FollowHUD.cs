using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace raspberly.ovr
{
    public class FollowHUD : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float followMoveSpeed = 0.05f;
        [SerializeField] private float followRotateSpeed = 0.05f;
        [SerializeField] private float rotateSpeedThreshold = 0.9f;
        [SerializeField] private bool isImmediateMove;
        [SerializeField] private bool isLockX;
        [SerializeField] private bool isLockY;
        [SerializeField] private bool isLockZ;
        private Quaternion rot;
        private Quaternion rotDif;

        private void Start()
        {
            if (!target) target = Camera.main.transform;
        }

        private void LateUpdate()
        {
            if (isImmediateMove) transform.position = target.position;
            else
            {
                Vector3 direction = target.forward; // 追跡するオブジェクトの前方向ベクトルを取得
                Vector3 targetPosition = target.position + direction * 0.5f; // 前方向に0.5加えた位置を計算
                transform.position = Vector3.Lerp(transform.position, targetPosition, followMoveSpeed);
            }

            rotDif = target.rotation * Quaternion.Inverse(transform.rotation);
            rot = target.rotation;
            if (isLockX) rot.x = 0;
            if (isLockY) rot.y = 0;
            if (isLockZ) rot.z = 0;
            if (rotDif.w < rotateSpeedThreshold) transform.rotation = Quaternion.Lerp(transform.rotation, rot, followRotateSpeed * 4);
            else transform.rotation = Quaternion.Lerp(transform.rotation, rot, followRotateSpeed);
        }

        //強制的に同期させたい時
        public void ImmediateSync(Transform targetTransform)
        {
            transform.position = targetTransform.position;
            transform.rotation = targetTransform.rotation;
        }
    }
}