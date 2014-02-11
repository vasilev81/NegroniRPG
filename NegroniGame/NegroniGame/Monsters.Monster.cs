﻿namespace NegroniGame.Monsters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Graphics;

    public class Monster : Interfaces.IMonster
    {
        public Monster(List<Texture2D> mobTextures, Rectangle spawnPosition)
        {
            this.Delay = 200f;
            this.Frames = 0;
            this.MonsterTextures = mobTextures;
            this.MonsterAnim = MonsterTextures[3];
            this.MonsterPosition = spawnPosition;
        }

        public void Move(GameTime gameTime)
        {
            // some logic for movement

            //int direction = randomGenerator.Next(1, 4);
            //int positions = randomGenerator.Next(10, 400);

            //if (direction == 1)
            //{
            //    // right
            //}

            // this.MonsterPosition.X += 2f;
            // this.MonsterPosition.Y += 2f;
            // this.MonsterAnim = this.MonsterTextures[0];
            this.SourcePosition = Animate(gameTime);

            //this.SourcePosition = new Rectangle(64, 0, 64, 64);
            // this.DestinationPosition = new Rectangle((int)this.MonsterPosition.X, (int)this.MonsterPosition.Y, 64, 64);

        }
        private Rectangle Animate(GameTime gameTime)
        {
            this.Elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (this.Elapsed >= this.Delay)
            {
                if (this.Frames >= 2)
                {
                    this.Frames = 0;
                }
                else
                {
                    this.Frames++;
                }
                this.Elapsed = 0;
            }

            // if on frame 0 - top up position 0
            return new Rectangle(32 * Frames, 0, 32, 32);
        }

        public void Draw(SpriteBatch sb)
        {
            new SystemFunctions.Sprite(this.MonsterAnim, this.MonsterPosition, this.SourcePosition).DrawBoxAnim(sb);
        }

        public Rectangle MonsterPosition { get; private set; }
        public string Name { get; private set; }
        public List<Texture2D> MonsterTextures { get; private set; }
        public float Elapsed { get; private set; }
        public float Delay { get; private set; }
        public int Frames { get; private set; }
        public Texture2D MonsterAnim { get; private set; }
        public Rectangle SourcePosition { get; private set; }
        // public Rectangle DestinationPosition { get; private set; }

        // public Vector2  MonsterPosition { get; private set; } <- TO DO
    }
}
