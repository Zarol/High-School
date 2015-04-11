using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Byte_Hunter_3D
{
    class SkyBox : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Model skyBox;
        TextureCube skyBoxTexture;
        Effect skyBoxEffect;

        static Matrix viewMatrix; 
        Matrix projectionMatrix;

        GraphicsDeviceManager graphics;

        static Vector3 cameraPosition;
        float size = 50f;
        float angle = 0f;
        static float distance = 20f;

        public SkyBox(Game game, GraphicsDeviceManager graphics, ContentManager content, string skyboxTexture, Matrix viewMatrix_, Matrix projectionMatrix)
            : base(game)
        {
            this.skyBox = content.Load<Model>("Skybox/Skybox");
            this.skyBoxTexture = content.Load<TextureCube>(skyboxTexture);
            this.skyBoxEffect = content.Load<Effect>("Skybox/SkyboxEffect");
            viewMatrix = viewMatrix_;
            this.projectionMatrix = projectionMatrix;
            this.graphics = graphics;

            cameraPosition = new Vector3(0f, 0f, 0f);
        }

        public static void setCameraPosition(Vector3 camPosition, Vector3 targetPosition)
        {
            cameraPosition = distance * camPosition;
            viewMatrix = Matrix.CreateLookAt(cameraPosition, new Vector3(0, 0, 0), Vector3.UnitY);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            angle += 0.002f;
            cameraPosition = distance * new Vector3((float)Math.Sin(angle), 0, (float)Math.Cos(angle));
            //cameraPosition = distance * new Vector3((float)Math.Sin(angle), (float)Math.Sin(angle), (float)Math.Cos(angle));
            viewMatrix = Matrix.CreateLookAt(cameraPosition, new Vector3(0, 0, 0), Vector3.UnitY);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //graphics.GraphicsDevice.RenderState.DepthBufferWriteEnable = false;
            graphics.GraphicsDevice.DepthStencilState = DepthStencilState.None;
            //graphics.GraphicsDevice.RenderState.CullMode = CullMode.CullClockwiseFace
            graphics.GraphicsDevice.RasterizerState = RasterizerState.CullClockwise;

            foreach (EffectPass pass in skyBoxEffect.CurrentTechnique.Passes)
            {
                foreach (ModelMesh mesh in skyBox.Meshes)
                {
                    foreach (ModelMeshPart part in mesh.MeshParts)
                    {
                        part.Effect = skyBoxEffect;
                        part.Effect.Parameters["World"].SetValue(Matrix.CreateScale(size) * Matrix.CreateTranslation(cameraPosition));
                        part.Effect.Parameters["View"].SetValue(viewMatrix);
                        part.Effect.Parameters["Projection"].SetValue(projectionMatrix);
                        part.Effect.Parameters["SkyBoxTexture"].SetValue(skyBoxTexture);
                        part.Effect.Parameters["CameraPosition"].SetValue(cameraPosition);
                    }
                    mesh.Draw();
                }
            }
            //graphics.GraphicsDevice.RenderState.CullMode = CullMode.CullCounterClockwiseFace
            graphics.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
            //graphics.GraphicsDevice.RenderState.DepthBufferWriteEnable = true;
            graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            base.Draw(gameTime);
        }
    }
}
