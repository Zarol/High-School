using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpriteDemo
{
    class Camera
    {
        public Vector2 offset;
        public float zoom = 1f;
        public Vector2 viewportDimensions;
        public Vector2 drawOffset;

        public Camera(Vector2 viewportDimensions)
        {
            this.viewportDimensions = viewportDimensions;
        }

        public Matrix Projection
        {
            get
            {
                return Matrix.CreateOrthographic(viewportDimensions.X / zoom, viewportDimensions.Y / zoom, -32, 32);
            }
        }

        public Matrix View
        {
            get
            {
                return Matrix.CreateTranslation(offset.X, offset.Y, 0.0f);
            }
        }

        public Matrix World
        {
            get
            {
                return Matrix.Identity;
            }
        }
        public Matrix getTransformationMatrix()
        {
            Matrix transform =       // Thanks to o KB o for this solution
              Matrix.CreateTranslation(new Vector3(0, 0, 0)) *
                                         Matrix.CreateScale(new Vector3(zoom, zoom, 1)) *
                                         Matrix.CreateTranslation(offset.X, offset.Y, 0.0f);
            return transform;
        }
        //Transform a position from screen space to world space
        public Vector2 UnProject(Vector2 vec)
        {
            vec -= viewportDimensions / 2;
            vec.Y *= -1;
            vec /= zoom;
            vec -= offset;
            return vec;
        }

        public float UnProjectLength(float L)
        {
            return L / zoom;
        }

        //transforms a position from world space to screen space
        public Vector2 Project(Vector2 vec)
        {
            vec += offset;
            vec *= zoom;
            vec.Y *= -1;
            vec += viewportDimensions / 2;
            return vec;
        }
        public Vector2 toWorldPosition(Vector2 vec)
        {
            vec.Y *= -1;
            vec += new Vector2(-400, 240);
            vec -= drawOffset;
            return vec;
        }
    }
}
