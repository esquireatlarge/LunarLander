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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace _Matt_Sguerri_LunarLander
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class StartScreen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        //GraphicsDeviceManager graphics;
        SpriteFont hudFont;
        ContentManager Content;
        Color deselected;
        Color selected;
        Vector2 center;
        String play;
        String options;
        String quit;
        int selection = 1;
        KeyboardState prevState;
        AudioEngine ae;
        WaveBank wb;
        SoundBank sb;
        //http://xna-uk.net/blogs/offbyone/archive/2010/01/21/sound-in-xna-3-1-part-i.aspx
        Cue cue;

        public StartScreen(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            Content = game.Content;
            
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            center = new Vector2(Game.Window.ClientBounds.Width/2, Game.Window.ClientBounds.Height/2);
            selected = Color.Yellow;
            deselected = Color.Red;
            play = "Play";
            quit = "Quit";
            options = "Options";
            selection = 1;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            hudFont = Content.Load<SpriteFont>(@"hudFont");
            ae = new AudioEngine(@"Content\mainMenu.xgs");
            wb = new WaveBank(ae, @"Content\Wave Bank.xwb");
            sb = new SoundBank(ae, @"Content\Sound Bank.xsb");
            ae.Update();
            cue = sb.GetCue("levapolka");
            cue.Play();
            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.Up) && prevState.IsKeyUp(Keys.Up))
            {
                selection--;
            }
            if (kState.IsKeyDown(Keys.Down) && prevState.IsKeyUp(Keys.Down))
            {
                selection++;
            }
            if (kState.IsKeyDown(Keys.Enter))
            {
                if (selection == 1)
                {
                    //play
                    Enabled = false;
                    Visible = false;
                    ((DrawableGameComponent)Game.Components.ElementAt(1)).Enabled = true;
                    ((DrawableGameComponent)Game.Components.ElementAt(1)).Visible = true;
                }
                else if (selection == 2)
                {
                    //option
                    //sb.GetCue("levapolka").Stop(AudioStopOptions.Immediate);
                    //sb.GetCue("levapolka").Pause();
                    //cue.Pause();
                    //Enabled = false;
                    options = "No";
                }
                else
                {
                    //exit
                    Game.Exit();
                }
            }
            if (selection < 1)
                selection = 3;
            if(selection > 3)
                selection = 1;

            prevState = kState;
            ae.Update();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            if (selection == 1)
            {
                spriteBatch.DrawString(hudFont, play, center - new Vector2(20, 2)+ new Vector2(0, -20), selected);
                spriteBatch.DrawString(hudFont, options, center - new Vector2(20, 2), deselected);
                spriteBatch.DrawString(hudFont, quit, center - new Vector2(20, 2) + new Vector2(0, 20), deselected);
            }
            else if (selection == 2)
            {
                spriteBatch.DrawString(hudFont, play, center - new Vector2(20, 2) + new Vector2(0,-20), deselected);
                spriteBatch.DrawString(hudFont, options, center - new Vector2(20, 2), selected);
                spriteBatch.DrawString(hudFont, quit, center - new Vector2(20, 2) + new Vector2(0, 20), deselected);
            }
            else if (selection == 3)
            {
                spriteBatch.DrawString(hudFont, play, center - new Vector2(20, 2) + new Vector2(0, -20), deselected);
                spriteBatch.DrawString(hudFont, options, center - new Vector2(20, 2), deselected);
                spriteBatch.DrawString(hudFont, quit, center - new Vector2(20, 2) + new Vector2(0, 20), selected);
            }
            spriteBatch.DrawString(hudFont, "Lunar Lander", center - new Vector2(20, 60), Color.HotPink);
            spriteBatch.DrawString(hudFont, "by Matt Sguerri", center - new Vector2(20, 2) + new Vector2(0, 80), Color.Green);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}