using UnityEngine;

namespace Valorant.Player
{

    public class PlayerModel
    {
        private float _moveSpeed = 5f;
        private float _verticalVelocity = 0f;
        private bool _isSprinting = false;

        public float Gravity { get; } = 9.8f;
        public float JumpHeight { get; } = 2f;
        public float SprintSpeed { get; } = 10f;
        public float SprintSpeedTransition { get; } = 5f;
        public float BaseSpeed { get; } = 5f;

        public float MoveSpeed
        {
            get => _moveSpeed;
            set => _moveSpeed = Mathf.Clamp(value, 0, SprintSpeed);
        }

        public float VerticalVelocity
        {
            get => _verticalVelocity;
            set => _verticalVelocity = value;
        }

        public bool IsSprinting
        {
            get => _isSprinting;
            set => _isSprinting = value;
        }
    }
}