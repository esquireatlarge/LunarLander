using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;


namespace _Matt_Sguerri_LunarLander
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GamePlay : Microsoft.Xna.Framework.DrawableGameComponent
    {

        BasicEffect be;
        VertexBuffer vb;
        VertexDeclaration vd;
        //http://bobobobo.wordpress.com/2009/02/16/drawing-primitives-in-xna-from-a-vertex-buffer/
        VertexPositionColor[] vpc;

        public GamePlay(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            Enabled = false;
            Visible = false;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            be = new BasicEffect(Game.GraphicsDevice);
            be.VertexColorEnabled = true; //Weird color terrain mehbe?
            vpc = new VertexPositionColor[10];
            vpc[0] = new VertexPositionColor(new Vector3(30.0f, 10.0f, 0.0f), Color.Red);
            vpc[1] = new VertexPositionColor(new Vector3(40.0f, 40.0f, 0.0f), Color.Red);
            vpc[2] = new VertexPositionColor(new Vector3(80.0f, 60.0f, 0.0f), Color.Red);
            vpc[3] = new VertexPositionColor(new Vector3(300.0f, 150.0f, 0.0f), Color.Red);
            vpc[4] = new VertexPositionColor(new Vector3(90.0f, 400.0f, 0.0f), Color.Red);
            vpc[5] = new VertexPositionColor(new Vector3(450.0f, 123.0f, 0.0f), Color.Red);
            vpc[6] = new VertexPositionColor(new Vector3(670.0f, 632.0f, 0.0f), Color.Red);
            vpc[7] = new VertexPositionColor(new Vector3(231.0f, 333.0f, 0.0f), Color.Red);
            vpc[8] = new VertexPositionColor(new Vector3(60.0f, 60.0f, 0.0f), Color.Red);
            vpc[9] = new VertexPositionColor(new Vector3(70.0f, 700.0f, 0.0f), Color.Red);
            vb = new VertexBuffer(Game.GraphicsDevice, VertexPositionColor.VertexDeclaration, 10, BufferUsage.None);
            vb.SetData<VertexPositionColor>(vpc);
            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            foreach (EffectPass p in be.CurrentTechnique.Passes)
            {
                p.Apply();
                GraphicsDevice.SetVertexBuffer(vb);
                GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 9);
                //http://blogs.msdn.com/b/shawnhar/archive/2010/04/19/vertex-data-in-xna-game-studio-4-0.aspx
            }
            //GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 9);
            //GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, vpc, 0, 9, VertexPositionColor.VertexDeclaration);
            //GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vpc, 0, 1, VertexPositionColor.VertexDeclaration);

            base.Draw(gameTime);
        }
    }
}
