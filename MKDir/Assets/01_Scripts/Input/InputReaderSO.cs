using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MKDir.InputBind
{
    [CreateAssetMenu(menuName = "SO/InputReader")]
    public class InputReaderSO : ScriptableObject, Controls.IPlayerActions
    {
        private Controls _controls;
        public Vector3 Movement { get; private set; } = Vector3.zero;

        public event Action OnJumpEvent;

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new Controls();
            }

            _controls.Enable();
            _controls.Player.SetCallbacks(this);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnJumpEvent?.Invoke();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            Vector2 movement = context.ReadValue<Vector2>();
            Movement = new Vector3(movement.x, 0, movement.y);
        }
    }
}
