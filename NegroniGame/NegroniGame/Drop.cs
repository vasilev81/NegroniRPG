﻿namespace NegroniGame
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Drop
    {
        public const float SECONDS_TO_DISAPPEARING = 20;

        public Drop(Rectangle mobPosition)
        {
            RandomGenerator = new Random();
            int numberOfTexture = RandomGenerator.Next(0, 0);

            this.DropTextures = Screens.GameScreen.Instance.DropTextures;
            this.CurrentTexture = DropTextures[numberOfTexture];

            this.DropPosition = mobPosition;
        }
        public bool Update(GameTime gameTime)
        {
            this.ElapsedTimeDrop += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (ElapsedTimeDrop >= SECONDS_TO_DISAPPEARING)
            {
                return true;
            }
            return false;
        }

        public void Draw(SpriteBatch sb)
        {
            new SystemFunctions.Sprite(CurrentTexture, DropPosition).DrawBox(sb);
        }

        public Texture2D CurrentTexture { get; private set; }
        public List<Texture2D> DropTextures { get; private set; }
        public Rectangle DropPosition { get; private set; }
        public float ElapsedTimeDrop { get; private set; }
        // public float InitialTimeDrop { get; private set; }
        public Random RandomGenerator { get; private set; }
    }
}
