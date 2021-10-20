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
        public Actor _target;

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

        public Enemy(char icon, float x, float y, float speed, Actor target, Color color, string name = "Enemy")
            : base(icon, x, y, color, name)
        {
            _target = target;
            _speed = speed;
        }

        public override void Update(float deltaTime)
        {
            //Create a vector that stores the move input
            Vector2 moveDirection = (_target.Position - Position).Normalized;

            Velocity = moveDirection * Speed * deltaTime;

            if(GetTargetInSight())
                Position += Velocity;

            

            base.Update(deltaTime);
        }

        public bool GetTargetInSight()
        {
            Vector2 directionOfTarget = (_target.Position - Position).Normalized;

            float distanceOfTarget = Vector2.Distance(_target.Position, Position);
           
            return Math.Acos(Vector2.DotProduct(directionOfTarget, Forward)) * (180 / Math.PI) > 45 &&  distanceOfTarget < 200;

        }

        public override void OnCollision(Actor actor)
        {
            Console.WriteLine("Collision Occurred");
        }
    }
}
