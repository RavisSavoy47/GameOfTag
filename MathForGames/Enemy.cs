using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary1;
using Raylib_cs;

namespace MathForGames
{
    class Enemy : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        public Player _player;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Enemy(char icon, float x, float y, float speed, Player player, Color color, string name = "Enemy")
            : base(icon, x, y, color, name)
        {
            _player = player;
            _speed = speed;
        }

        public override void Update(float deltaTime)
        {
            float xDirection = _player.Position.X - Position.X;
            float yDirection = _player.Position.Y - Position.Y;

            Vector2 moveDirection = new Vector2(xDirection, yDirection);

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            Position += Velocity;

            base.Update(deltaTime);
        }

        public override void OnCollision(Actor actor)
        {
            Console.WriteLine("Collision Occurred");
        }
    }
}
