using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Byte_Hunter_3D
{
    class MainGame : Screen
    {
        ContentManager content;
        SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;
        GraphicsDevice device;

        Viewport viewport;

        Matrix viewMatrix;
        Matrix projectionMatrix;
        Vector3 cameraPosition;
        Vector3 cameraUpDirection;
        Quaternion cameraRotation = Quaternion.Identity;

        #region Skybox Variables
        SkyBox skyBox;
        #endregion

        SpriteFont debugFont;

        public MainGame(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            device = GraphicsDevice;
            Initialize();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Loads the graphic content for this screen.
        /// This screen uses a local ContentManager.
        /// </summary>
        public override void LoadContent()
        {
            viewport = ScreenManager.GraphicsDevice.Viewport;
            spriteBatch = ScreenManager.SpriteBatch;
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");
            UpdateCamera();

            skyBox = new SkyBox(this, graphics, content, "Skyboxes/uvmoreStuff", viewMatrix, projectionMatrix);
            Components.Add(skyBox);

            debugFont = content.Load<SpriteFont>("DebugFont");
        }

        //private Model LoadXModel(string assetName, out Texture2D[] textures)
        //{
        //    Model newModel = content.Load<Model>(assetName);
        //    textures = new Texture2D[newModel.Meshes.Count];
        //    int i = 0;
        //    foreach (ModelMesh mesh in newModel.Meshes)
        //        foreach (BasicEffect currentEffect in mesh.Effects)
        //            textures[i++] = currentEffect.Texture;

        //    foreach (ModelMesh mesh in newModel.Meshes)
        //        foreach (ModelMeshPart meshPart in mesh.MeshParts)
        //            meshPart.Effect = effect.Clone();

        //    return newModel;
        //}

        /// <summary>
        /// Unloads the graphics content for this screen.
        /// </summary>
        public override void UnloadContent()
        {
            content.Unload();
        }

        public override void Update(GameTime gameTime, bool isActive, bool covered)
        {
            UpdateCamera();

            base.Update(gameTime, isActive, covered);
        }

        private void UpdateCamera()
        {
            //cameraRotation = Quaternion.Lerp(cameraRotation, xwingRotation, .1f);

            Vector3 campos = new Vector3(0, 0.13f, .8f);
            campos = Vector3.Transform(campos, Matrix.CreateFromQuaternion(cameraRotation));
            //campos += xwingPosition;

            Vector3 camup = new Vector3(0, 1, 0);
            camup = Vector3.Transform(camup, Matrix.CreateFromQuaternion(cameraRotation));

            viewMatrix = Matrix.CreateLookAt(campos, new Vector3(0f,50f,0f), camup);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, device.Viewport.AspectRatio, .2f, 500f);

            cameraPosition = campos;
            cameraUpDirection = camup;
        }

        public override void Draw(GameTime gameTime)
        {
            device.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.DrawString(debugFont, "Hello!", new Vector2(50, 50), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}